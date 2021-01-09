using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WebFormsUtilities.Json
{
    [DataContract]
    public class ValidationRule
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ValidationParameters { get; set; }
        [DataMember]
        public string ValidationType { get; set; }
    }
}
