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
        ShowsAndMovies,
        Nature,
        PopCulture,
        Other
    };
    public Categories Category;

    public Question(Categories category,string statement, string[] answers, int correctAnswer)
    {
        Category = category;
        Statement = statement;
        Answers = answers;
        CorrectAnswer = correctAnswer;


    }
    public override string ToString()
    {
        return Statement;
    }
}