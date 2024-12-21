using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Models
{
    public class ExamHistory
    {
        public int HistoryID { get; set; }
        public int UserID { get; set; }
        public int ExamID { get; set; }
        public int Score { get; set; }
        public DateTime DateTaken { get; set; }
        public int TimeTaken { get; set; }
    }
}
