using Labb3_NET22.DataTransferObj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Labb3_NET22.DataModels
{
    public static class QuizStorage
    {
        public static List<Quiz> AllQuizzes = new();
        public static readonly string appFolder =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                    ),
                "Labb3_NET22"
                );

        static QuizStorage()
        {
            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);
        }


        public static async Task SaveQuizAsync(Quiz quiz)
        {
            var Dto = new QuizDto
            {
                Title = quiz.Title,
                Questions = quiz.Questions.Select(q => new QuestionDto
                {
                    Statement = q.Statement,
                    Answers = q.Answers,
                    CorrectAnswer = q.CorrectAnswer,
                    Category = q.Category,
                    ImageUrl = q.ImageUrl

                }).ToList()
            };

            string json = JsonSerializer.Serialize(Dto, new JsonSerializerOptions { WriteIndented = true });
            string path = Path.Combine(appFolder, $"{quiz.Title}.json");

            await File.WriteAllTextAsync(path, json);

        }

        public static async Task<Quiz> LoadQuizAsync(string fileName)
        {
            string path = Path.Combine(appFolder, fileName);
            string json = await File.ReadAllTextAsync(path);

            var Dto = JsonSerializer.Deserialize<QuizDto>(json);

            if (Dto == null)
                throw new Exception("Could not load quiz data");
            var quiz = new Quiz(Dto.Title);
            foreach(var q in Dto.Questions)
            {
                var question = new Question(q.Category, q.Statement, q.Answers, q.CorrectAnswer)
                {
                    ImageUrl = q.ImageUrl
                };
                quiz.AddQuestion(question);
            }
            
            AllQuizzes.Add(quiz);
            

            return quiz;


        }

        public static IEnumerable<string> GetAllSavedQuizzes()
        {
            return Directory.GetFiles(appFolder, "*.json")
                .Select(Path.GetFileName);
        }


        public static void DeleteQuiz(Quiz NewQuiz)
        {
            string fileName = NewQuiz.Title.EndsWith(".json") ? NewQuiz.Title : NewQuiz.Title + ".json";
            string path = Path.Combine(appFolder, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                MessageBox.Show("Path not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            var result = MessageBox.Show("Are you sure you want to delete this quiz?",
                "Delete Quiz?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);



        }

    }
}
