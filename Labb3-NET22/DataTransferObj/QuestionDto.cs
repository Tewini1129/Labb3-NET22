using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labb3_NET22.DataModels.Question;

namespace Labb3_NET22.DataTransferObj
{
    public class QuestionDto
    {
        public string Statement { get; set; } = string.Empty;
        public string[] Answers { get; set; } = Array.Empty<string>();
        public int CorrectAnswer { get; set; }
        public Categories Category { get; set; }
        public string? ImageUrl { get; set; }

    }
}
