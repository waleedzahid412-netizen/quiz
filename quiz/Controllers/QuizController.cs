using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz.Models.Entities;
using quiz.Models;

namespace quiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Quizzes = _context.StudentQuizzes
            .Select(q => q.QuizTitle)
            .Distinct()
            .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Quiz question)
        {
            if (ModelState.IsValid)
            {

                _context.StudentQuizzes.Add(question);  
                _context.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(question);
        }
    }
}
