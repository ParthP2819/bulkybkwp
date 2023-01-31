using bulkybkw.DataAccess.Repository.IRepository;
using bulkybkwp.DataAccess;
using bulkybkwp.DataAccess.Repository.IRepository;
using bulkybkwp.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkybkw.Areas.Admin.Controllers

{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //GET Action Method for Create
        public IActionResult Create()
        {

            return View();
        }

        //POST Action Method for Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {           
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Action Method for Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
             //var categoryFromDb = _db.categories.Find(id);
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFristOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(u=>u.Id==id);

            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(CoverTypeFromDbFirst);
        }

        //POST Action Method for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Update Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Action Method for Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFristOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(u=>u.Id==id);

            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(CoverTypeFromDbFirst);
        }

        //POST Action Method for Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFristOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

