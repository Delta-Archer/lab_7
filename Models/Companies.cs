using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_6.Models
{
    public class Companies
    {
        public int Id { get; set; }
        [Display(Name = "Компанія")]
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string CEO { get; set; }
        public IEnumerable<Mobiles> Mobiles { get; set; }

    }
}