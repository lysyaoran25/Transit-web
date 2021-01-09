using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.WebControls {
    /// <summary>
    /// Server controls that wish to use ApplyModelToPage() or DataAnnotations can implement this interface.
    /// </summary>
    public interface IWFControlValue {
        void SetControlValue(object value);
        object GetControlValue();
    }
}
