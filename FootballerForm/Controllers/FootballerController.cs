using FootballerForm.DataAccess.Repository.IRepository;
using FootballerForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballerForm.Controllers
{
    public class FootballerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FootballerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var footballers = _unitOfWork.Footballer.GetAll();
            return View(footballers);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Footballer.Add(footballer);
                _unitOfWork.Save();
                TempData["success"] = "Player Added Successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var footballer = _unitOfWork.Footballer.GetFirstOrDefault(x => x.Id == id);
            return View(footballer);
        }

        [HttpPost]
        public IActionResult Edit(Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                var footballerFromDb = _unitOfWork.Footballer.GetFirstOrDefault(x => x.Id == footballer.Id);
                footballerFromDb.Name = footballer.Name;
                footballerFromDb.Surname = footballer.Surname;
                footballerFromDb.Age = footballer.Age;
                footballerFromDb.Email = footballer.Email;
                _unitOfWork.Footballer.Update(footballerFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var footballer = _unitOfWork.Footballer.GetFirstOrDefault(x => x.Id == id);
            return View(footballer);
        }

        [HttpPost]
        public IActionResult Index(Footballer footballer)
        {
            var footballerFromDb = _unitOfWork.Footballer.GetFirstOrDefault(x => x.Id == footballer.Id);
            _unitOfWork.Footballer.Remove(footballerFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Player Deleted Successfully";
            return View(nameof(Index));
        }
    }
}
