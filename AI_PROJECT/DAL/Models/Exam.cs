using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; } // Thời gian làm bài tính bằng phút
        public DateTime CreatedDate { get; set; }
    }
}
