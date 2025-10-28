using System;
using System.Windows.Media.Imaging;

namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }
    public enum Categories
    {
        History,
        Sports,
        Culture,
        Tv,
        Nature,
        PopCulture,
        Other
    };
    public Categories Category;
    public string? ImageUrl { get; set; }
    public BitmapImage? Image { get; set; }

    public Question(Categories category,string statement, string[] answers, int correctAnswer)
    {
        Category = category;
        Statement = statement;
        Answers = answers;
        CorrectAnswer = correctAnswer;
        
        
        if(!string.IsNullOrWhiteSpace(ImageUrl))
        {
            try
            {
                Image = new BitmapImage(new Uri(ImageUrl, UriKind.Absolute));
            }
            catch
            {

            }
        }





    }
    public override string ToString()
    {
        return Statement;
    }
}