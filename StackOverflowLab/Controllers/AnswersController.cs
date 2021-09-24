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
    public class AnswersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAnswerForm(int question)
        {
            Question quest = DAL.GetQuestion(question);
            return View(quest);
        }
        public IActionResult AddAnswer(Answer answer)
        {
            answer.username = DAL.CurrentUser;
            answer.posted = DateTime.Now;
            answer.upvotes = 0;
            DAL.InsertAnswer(answer);
            return Redirect($"/Questions/ListAnswers?questid={answer.questionid}");
        }
        public IActionResult Upvote(int answerid)
        {
            Answer answer = DAL.GetAnswer(answerid);
            answer.upvotes++;
            DAL.UpdateAnswer(answer);
            return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
        }
        public IActionResult Downvote(int answerid)
        {
            Answer answer = DAL.GetAnswer(answerid);
            answer.upvotes--;
            DAL.UpdateAnswer(answer);
            return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
        }
        public IActionResult DeleteAnswer(int answerid)
        {
            Answer answer = DAL.GetAnswer(answerid);
            if (answer.username == DAL.CurrentUser || DAL.CurrentUser == "Admin")
            {
                DAL.DeleteAnswer(answerid);
                return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
            }
            else
            {
                TempData["DeleteAnswerUsername"] = "*You cannot delete somebody elses answer.";
                return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
            }
        }
        public IActionResult EditAnswerForm(int answerid)
        {
            Answer answer = DAL.GetAnswer(answerid);
            if (answer.username == DAL.CurrentUser || DAL.CurrentUser == "Admin")
            {
                return View(answer);
            }
            else
            {
                TempData["EditAnswerUsername"] = "*You cannot edit someone elses answer";
                return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
            }
        }
        public IActionResult SaveAnswer(Answer answer)
        {
            answer.username = DAL.CurrentUser;
            answer.posted = DateTime.Now;
            DAL.UpdateAnswer(answer);
            return Redirect($"/Questions/Listanswers?questid={answer.questionid}");
        }
    }
}
