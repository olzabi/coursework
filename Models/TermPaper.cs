using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{


    public class TermPaper
    {
        public int TermPaperID { get; set; }
        public int StudentId { get; set; }
        public int AdvisorId { get; set; }
        public DateTime Taken { get; set; }
        public DateTime Due { get; set; }

        public string Grade { get; set; }

        public bool IsPassed { get; set; }


        public virtual Student Student { get; set; }
        public virtual Advisor Advisor { get; set; }

      

    }


}

