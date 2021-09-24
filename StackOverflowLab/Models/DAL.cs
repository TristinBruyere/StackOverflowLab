using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using Dapper;

namespace StackOverflowLab.Models
{
    public class DAL
    {
        //public static MySqlConnection DB = new MySqlConnection("Server=localhost;Database=FoCstackoverflow;Uid=root;Password=abc123");

        public static MySqlConnection DB;

        // Current user

        public static string CurrentUser = null;

        // Questions "CRUD"

        // Questions "R"
        public static List<Question> GetAllQuestions()
        {
            return DB.GetAll<Question>().ToList();
        }
        public static Question GetQuestion(int id)
        {
            return DB.Get<Question>(id);
        }


        // Questions "C"
        public static void InsertQuestion(Question quest)
        {
            DB.Insert(quest);
        }

        // Questions "U"
        public static void UpdateQuestion(Question quest)
        {
            DB.Update(quest);
        }

        // Questions "D"
        public static void DeleteQuestion(int id)
        {
            Question quest = new Question() { id = id };
            DB.Delete(quest);
        }

        // Answers "CRUD"

        // Answers "R"
        //public static List<Answer> GetQuestionAnswers(int questionId)
        //{
        //    List<Answer> answers = new List<Answer>();
        //    foreach(Answer answer in DB.GetAll<Answer>())
        //    {
        //        if (answer.questionid == questionId)
        //        {
        //            answers.Add(answer);
        //        }
        //    }
        //    return answers;
        //}

        public static QuestionAnswers GetAllForQuestion(int theQuestId)
        {
            var keyvalues = new { questId = theQuestId };
            string sql = "select * from answers where questionid = @questId";
            QuestionAnswers qa = new QuestionAnswers();
            qa.answers = DB.Query<Answer>(sql, keyvalues).ToList();
            qa.quest = DAL.GetQuestion(theQuestId);
            return qa;
        }

        public static Answer GetAnswer(int id)
        {
            return DB.Get<Answer>(id);
        }

        // Answers "C"
        public static void InsertAnswer(Answer answer)
        {
            DB.Insert(answer);
        }

        // Answers "U"
        public static void UpdateAnswer(Answer answer)
        {
            DB.Update(answer);
        }

        //Answer "D"
        public static void DeleteAnswer(int id)
        {
            Answer answer = new Answer();
            answer.id = id;
            DB.Delete<Answer>(answer);
        }

        public static List<Question> SearchQuestions(string str)
        {
            var keyvaluepair = new { search = $"%{str}%" };
            string sql = "select * from questions where title like @search;";
            return DB.Query<Question>(sql, keyvaluepair).ToList();
        }
    }
}
