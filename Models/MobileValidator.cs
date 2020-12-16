using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_6.Models
{
    public class MobileValidator : ModelValidator
    {
        public MobileValidator(ModelMetadata metadata, ControllerContext context) : base(metadata, context)
        { }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            Lab_6.Models.Mobiles b = (Lab_6.Models.Mobiles)Metadata.Model;
            List<ModelValidationResult> errors = new
            List<ModelValidationResult>();

            if (string.IsNullOrEmpty(b.Model))
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Треба ввести назву моделі"
                });
            }

            if (string.IsNullOrEmpty(b.Price.ToString()))
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Треба ввести ціну"
                });
            }

            if (b.Price < 4000 || b.Price > 50000)
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Неприпустима ціна"
                });
            }
            return errors;
        }
    }
}