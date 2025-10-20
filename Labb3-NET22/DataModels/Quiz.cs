using System;
using System.Collections.Generic;


namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;

    public Quiz()
    {
        _questions = new List<Question>();
    }

    public Question GetRandomQuestion()
    {
        throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        Console.WriteLine("----<=== Create Questions ===>----\n");

        Console.Write("\n\nQuestion Statement: ");
        //Question.Categories Category = (Console.ReadLine());

        Console.Write("\n\nQuestion Statement: ");
        string Statement = Console.ReadLine();

        Console.Write("\n\nAnswer 1: ");
        string A1 = Console.ReadLine();

        Console.Write("\n\nAnswer 2: ");
        string A2 = Console.ReadLine();

        Console.Write("\n\nAnswer 3: ");
        string A3 = Console.ReadLine();

        string[] Answers = [A1, A2, A3];

        Console.Write("\n\nWhich answer is the correct answer: ");
        int CorrectAnswer = int.Parse(Console.ReadLine());

        Question q = new Question(Question.Categories.History,Statement, Answers, CorrectAnswer);
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }


}