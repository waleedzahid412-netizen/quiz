using Microsoft.AspNetCore.Mvc;
using quiz.Models;
using quiz.Models.Entities;

namespace quiz.Controllers
{
    public class Students : Controller
    {
        private readonly ApplicationDbContext _context;

        public Students(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TakeQuiz(string quizTitle)
        {
            var questions = _context.StudentQuizzes
                .Where(q => q.QuizTitle == quizTitle)
                .ToList();

            ViewBag.QuizTitle = quizTitle;
            return View(questions);
        }

        [HttpPost]
        public IActionResult SubmitQuiz(string studentName, string quizTitle, Dictionary<int, string> answers)
        {
            int score = 0;

            foreach (var answer in answers)
            {
                var question = _context.StudentQuizzes.Find(answer.Key);
                if (question.CorrectOption == int.Parse(answer.Value))
                {
                    score++;
                }
            }
            var result = new Models.Entities.Students 
            {
                StudentName = studentName,
                QuizTitle = quizTitle,
                Score = score
            };




            _context.student.Add(result);
            _context.SaveChanges();

            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            return View(_context.StudentQuizzes.ToList());
        }
    }

}
