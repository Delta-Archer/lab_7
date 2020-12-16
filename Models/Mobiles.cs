using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab_6.Models
{ 
    public class Mobiles : IValidatableObject
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public Companies Company { get; set; }
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Ціна")]
        public int Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Model))
            {
                errors.Add(new ValidationResult("Треба ввести назву моделі"));
            }

            if (string.IsNullOrEmpty(this.Price.ToString()))
            {
                errors.Add(new ValidationResult("Треба ввести ціну"));
            }

            if (this.Price < 3500 || this.Price > 50000)
            {
                errors.Add(new ValidationResult("Неприпустима ціна"));
            }
            return errors;
        }
    }
}