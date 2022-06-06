using System.Collections.Generic;

namespace coursework.Models
{
    public class Advisor
    {
        public int AdvisorId { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstMidName { get; set; }
        
        public string Position { get; set; }

        public virtual ICollection<TermPaper> TermPapers { get; set; }
    }
}
