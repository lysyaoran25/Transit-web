using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.DataAnnotations {
    /// <summary>
    /// If a DataAnnotation attribute requires an IWFValueProvider for the context of the current validation, this interface will allow the validation engine to provide it.
    /// </summary>
    public interface IWFRequireValueProviderContext {
        void SetValueProvider(IWFValueProvider provider);
    }
}
