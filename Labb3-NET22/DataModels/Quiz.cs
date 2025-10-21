using System;
using System.Collections.Generic;
using System.Linq;
using Labb3_NET22.View;


namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;

    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;

    public Quiz(string titel)
    {
        _title = titel;
        _questions = new List<Question>();
    }


    public Question GetRandomQuestion()
    {
        Random random = new Random();
        int randomNr = random.Next(0, Questions.Count());
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
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }


    public void RenameQuiz(string NewTitle)
    {
        _title = NewTitle;
    }


}