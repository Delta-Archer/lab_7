using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_6.Models
{
    public class MyValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator>
        GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(Lab_6.Models.Mobiles))
            {
                return new ModelValidator[] { new MobilePropertyValidator(metadata, context) };
            }

            if (metadata.ModelType == typeof(Lab_6.Models.Mobiles))
            {
                return new ModelValidator[] { new MobileValidator(metadata, context) };
            }
            return Enumerable.Empty<ModelValidator>();
        }
    }
}