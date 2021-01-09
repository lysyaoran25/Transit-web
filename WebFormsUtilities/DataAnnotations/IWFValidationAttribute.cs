using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.DataAnnotations
{
    public interface IWFValidationAttribute
    {
        Type GetValidatorType();
    }
}
