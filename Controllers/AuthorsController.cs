using Books.Data.Consts;
using Books.Models;
using Books.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var data = _unitOfWork.Authors.GetAll().ToList();
            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(Author data)
        {
            if (ModelState.IsValid)
            {
                var stream = new MemoryStream();
                data.clientFile.CopyTo(stream);
                data.dbImage = stream.ToArray();
                _unitOfWork.Authors.Add(data);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            var data = _unitOfWork.Authors.GetById(id);
            if (data == null)
                return NotFound(data);
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Author data)
        {
            if (ModelState.IsValid)
            {
                var stream = new MemoryStream();
                data.clientFile.CopyTo(stream);
                data.dbImage = stream.ToArray();
                _unitOfWork.Authors.Update(data);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            var data = _unitOfWork.Authors.GetById(id);
            if (data == null)
                return NotFound(data);
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Author data)
        {
            _unitOfWork.Authors.Delete(data);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
