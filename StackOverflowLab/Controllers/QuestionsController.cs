using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverflowLab.Models;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace StackOverflowLab.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index()
        {
            List<Question> quest = DAL.GetAllQuestions().ToList();
            return View(quest);
        }

        public IActionResult ListAnswers(int questid)
        {
            QuestionAnswers question = DAL.GetAllForQuestion(questid);
            return View(question);
        }

        public IActionResult ListAnswer(int questid)
        {
            QuestionAnswers question = DAL.GetAllForQuestion(questid);
            return View(question);
        }

        public IActionResult AddQuestionForm()
        {
            return View();
        }

        public IActionResult AddQuestion(Question question)
        {
            question.username = DAL.CurrentUser;
            question.posted = DateTime.Now;
            DAL.InsertQuestion(question);
            return Redirect("/Questions/index");
        }

        public IActionResult DeleteQuestion(int questid)
        {
            Question question = DAL.GetQuestion(questid);
            if (question.username == DAL.CurrentUser || DAL.CurrentUser == "Admin")
            {
                DAL.DeleteQuestion(questid);
                return Redirect("/Questions");
            }
            else
            {
                TempData["DeleteQuestionUsername"] = "*You cannot delete somebody elses question.";
                return Redirect("/Questions");
            }
        }
        public IActionResult EditQuestionForm(int questid)
        {
            Question question = DAL.GetQuestion(questid);
            if (question.username == DAL.CurrentUser || DAL.CurrentUser == "Admin")
            {
                return View(question);
            }
            else
            {
                TempData["EditQuestionUsername"] = "*You cannot edit somebody elses question.";
                return Redirect("/Questions");
            }
        }
        public IActionResult SaveQuestion(Question question)
        {
            question.username = DAL.CurrentUser;
            question.posted = DateTime.Now;
            DAL.UpdateQuestion(question);
            return Redirect("/Questions/index");
        }
        public IActionResult Search(string str)
        {
            List<Question> questions = DAL.SearchQuestions(str);
            return View(questions);
        }
    }
}
