using System.ComponentModel.DataAnnotations;

namespace walkers_assessment.Models
{
    public class ListDataModel
    {
      
        public string ViewPath { get; set; }

        [Required]
        [Range(1,200,ErrorMessage="Enter a number between 1 and 200")]
        public int Entries { get; set; }

        public int PageOffset { get; set; }

        public bool isMonday { get; set; }

        public string Mondayify(string val)
        {
            if (isMonday)
            {
                val += "-m";
            }
            return val;
        }
    }
}
