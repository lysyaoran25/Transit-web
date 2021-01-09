using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.DataAnnotations {
    public interface IWFClientValidatable {
        IEnumerable<WFModelClientValidationRule> GetClientValidationRules();

    }

}
