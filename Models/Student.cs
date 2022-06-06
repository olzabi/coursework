using System;
using System.Collections.Generic;

namespace coursework.Models
{
    public class Student
    {
        
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Department { get; set; }

        public virtual ICollection<TermPaper> TermPapers { get; set; }
    }
}