using Books.Data.Consts;
using Books.Data.Enums;
using Books.Models;
using Books.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books.Controllers
{
    [AllowAnonymous]
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateAuthorsSelectList()
        {
            var data = _unitOfWork.Authors.GetAll();
            SelectList MyList = new SelectList(data, "Id", "Name");
            ViewBag.MyBag = MyList;
        }
        public IActionResult Index()
        {
            var data = _unitOfWork.Books.GetAll().ToList();
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            CreateAuthorsSelectList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Book data)
        {
            if (ModelState.IsValid)
            {
                var stream = new MemoryStream();
                data.clientFile.CopyTo(stream);
                data.dbImage = stream.ToArray();
                _unitOfWork.Books.Add(data);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            var data = _unitOfWork.Books.GetById(id);
            if (data == null)
                return NotFound(data);
            CreateAuthorsSelectList();
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Book data)
        {
            if (ModelState.IsValid)
            {
                var stream = new MemoryStream();
                data.clientFile.CopyTo(stream);
                data.dbImage = stream.ToArray();
                _unitOfWork.Books.Update(data);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            var data = _unitOfWork.Books.GetById(id);
            if (data == null)
                return NotFound(data);
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Book data)
        {
            _unitOfWork.Books.Delete(data);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }
        public IActionResult HorrorBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Horror && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult FantasyBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Fantasy && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult CrimeBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.CrimeFiction && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult MysteryBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Mystery && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult RomanceBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Romance && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult AdventureBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Adventure && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult HistoricalBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.HistoricalFiction && item.Type == BookType.English)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicHorrorBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Horror && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicFantasyBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Fantasy && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicCrimeBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.CrimeFiction && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicMysteryBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Mystery && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicRomanceBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Romance && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicAdventureBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.Adventure && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
        public IActionResult ArabicHistoricalBooks()
        {
            var data = _unitOfWork.Books.GetAll();
            var list = new List<Book>();
            foreach (var item in data)
            {
                if (item.Category == BooksCategory.HistoricalFiction && item.Type == BookType.Arabic)
                    list.Add(item);
            }
            return View(list);
        }
    }
}
