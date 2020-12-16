using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_6.Models
{
    public class MobilePropertyValidator : ModelValidator
    {
        public MobilePropertyValidator(ModelMetadata metadata, ControllerContext context) : base(metadata, context) { }
        public override IEnumerable<ModelValidationResult> Validate(object container)

        {
            Lab_6.Models.Mobiles b = container as Lab_6.Models.Mobiles;
            if (b != null)
            {

            }
            return Enumerable.Empty<ModelValidationResult>();
        }

    }
}