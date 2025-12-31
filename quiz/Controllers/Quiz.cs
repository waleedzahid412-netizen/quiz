using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz.Models.Entities;
using quiz.Models;

namespace quiz.Controllers
{
    public class Quiz : Controller
    {
        private readonly ApplicationDbContext _context;

        public Quiz(ApplicationDbContext context)
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
        public IActionResult Create(quiz.Models.Entities.Quiz question)
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
