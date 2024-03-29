﻿using bulkybkw.DataAccess.Repository.IRepository;
using bulkybkwp.DataAccess;
using bulkybkwp.DataAccess.Repository.IRepository;
using bulkybkwp.Models;
using bulkybkwp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bulkybkw.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
            
        }


        public IActionResult Index()
        {
            return View();
        }

        //GET Action Method for Upsert
        public IActionResult Upsert(int? id)
        {

            Company company = new();

            if (id == null || id == 0)
            {               
                return View(company);
            }
            else   
            {
                company = _unitOfWork.Company.GetFristOrDefault(u=>u.Id==id);
                return View(company);
            }               
        }

        //POST Action Method for Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company Create Successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company Updated Successfully";
                }
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFristOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
                        
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully" });


        }


        #endregion
    }

}

