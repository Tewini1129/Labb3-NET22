using System;
using Labb3_NET22.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22.DataTransferObj
{
    public class QuizDto
    {
        public string Title { get; set; } = string.Empty;
        public List<QuestionDto> Questions { get; set; } = new();
    }
}
