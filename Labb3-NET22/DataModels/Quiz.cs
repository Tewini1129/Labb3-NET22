using Labb3_NET22.View;
using System;
using System.Collections.Generic;
using System.Linq;
using static Labb3_NET22.DataModels.Question;
using static System.Net.WebRequestMethods;


namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public Categories? ChosenCategory { get; set; }



    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;
    public List<Question> updatedList { get; set; }
    public List<Question> AnsweredQuestions { get; set; } = new();
    public string? Background = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRU3BAgZSshroZzpHbBr-z5kLPZpJ-PDa3juA&s";
    public bool Finished { get; set; } = false;

    public Quiz(string title)
    {
        _title = title;
        _questions = new List<Question>();
    }

    
   

    public Question GetRandomQuestion()
    {
        Random random = new Random();
        int randomNr = random.Next(0, Questions.Count());
        while((ChosenCategory != null)&&(ChosenCategory != (Questions.ElementAt(randomNr)).Category))
        {
            
            randomNr = random.Next(0, Questions.Count());

        }
        return Questions.ElementAt(randomNr);
    }


    public void AddQuestion(Question q)
    {
        var Update = _questions.ToList();
        Update.Add(q);
        _questions = Update;
    }


    public void RemoveQuestion(int index)
    {
        updatedList = Questions.ToList();
        if((index >= 0)&&(index < updatedList.Count))
        {
            updatedList.RemoveAt(index);
        }
        _questions = updatedList;

        
    }


    public void RenameQuiz(string NewTitle)
    {
        _title = NewTitle;
    }


}