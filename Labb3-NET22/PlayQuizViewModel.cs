using Labb3_NET22.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Labb3_NET22.View;


namespace Labb3_NET22
{
    public class PlayQuizViewModel: INotifyPropertyChanged
    {
        public Quiz quiz;
        public string QuizTitle => quiz.Title;

        public Question CurrentQuestion { get; set; }
        public string? ImageUrl
        {
            get => CurrentQuestion?.ImageUrl;
        }
        public int SelectedAnswer { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswers { get; set; }
        public int percent { get; set; }
        public List<Question> QuestionsInCategory
        {
            get
            {
                var QuestionsInCategory = quiz.Questions.Where(q => q.Category == quiz.ChosenCategory);
                return QuestionsInCategory.ToList();
            }
            set
            {

            }

        }
        public string ScoreText 
        {
            get 
            {
                int AmountOfQuestions;

                if (quiz.ChosenCategory != null)
                {
                    AmountOfQuestions = quiz.Questions.Where(q => q.Category == quiz.ChosenCategory).Count();
                }
                else
                {
                    AmountOfQuestions = quiz.Questions.Count();
                }


                if (TotalAnswers > 0)
                {
                    percent = (int)((double)CorrectAnswers / TotalAnswers * 100);
                }
                
                return $"Correct answers: {CorrectAnswers} out of {AmountOfQuestions}     {percent}% Right";
            }
            set 
            { 
            
            }
        }
        public string Percent 
        { 
            get => $"{percent}%"; 
        }
        public string FeedBack { get; set; }
        public string FinalScoreText
        {
            get => $"{CorrectAnswers}/{TotalAnswers}";

        }
        


        public PlayQuizViewModel(Quiz chosenQuiz)
        {
            quiz = chosenQuiz;
            SelectedAnswer = -1;
            CurrentQuestion = quiz.GetRandomQuestion();
            
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string name ="")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public string Judgement()
        {
            FeedBack = percent switch
            {
                0 => "you might wanna get your head checked...",
                <= 30 => "...did you even read the questions?",
                <= 50 => "You've been playing some dota havent you...",
                <= 70 => "Not great but not awful",
                <= 85 => "These are some high numbers buddy!",
                <= 95 => "Wow, almost perfect",
                _ => "Increadible! Have a redbull break, you deserve it!"
            };
            OnPropertyChanged(nameof(FeedBack));
            return FeedBack;
        }


        public void NextQuestion(int SelectedAnswer)
        {
            TotalAnswers++;
            if(CurrentQuestion.CorrectAnswer == SelectedAnswer)
            {
                CorrectAnswers++;

            }

            CurrentQuestion = quiz.GetRandomQuestion();
            

            do
            {

                if ((quiz.AnsweredQuestions.Count() == quiz.Questions.Count())||(quiz.AnsweredQuestions.Count() == QuestionsInCategory.Count()))
                {
                    quiz.Finished = true;
                }

                if ((quiz.AnsweredQuestions.Contains(CurrentQuestion))&&(quiz.Finished == false))
                {
                    CurrentQuestion = quiz.GetRandomQuestion();
                }


            } while ((quiz.AnsweredQuestions.Contains(CurrentQuestion)) && (quiz.Finished == false));
            

            OnPropertyChanged(nameof(ImageUrl));
            OnPropertyChanged(nameof(CurrentQuestion));
            OnPropertyChanged(nameof(ScoreText));
            OnPropertyChanged(nameof(FinalScoreText));
            OnPropertyChanged(nameof(Percent));
            OnPropertyChanged(nameof(FeedBack));
            OnPropertyChanged(nameof(quiz.ChosenCategory));

        }


        public void SetNewQuestion(Question q)
        {
            CurrentQuestion = q;
            OnPropertyChanged(nameof(CurrentQuestion));
            OnPropertyChanged(nameof(ImageUrl));
            OnPropertyChanged(nameof(ScoreText));

        }

    }
}
