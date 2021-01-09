using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WebFormsUtilities.DataAnnotations {
    public class DisplayAttribute : DisplayNameAttribute {
        public DisplayAttribute(Type resourceManagerProvider, string resourceKey)
        : base(WFUtilities.GetResourceValueFromTypeName(resourceManagerProvider, resourceKey)) {
        }
    }
}
