using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WebFormsUtilities.Json
{
    [DataContract]
    public class Field
    {
        [DataMember]
        public string FieldName { get; set; }
        [DataMember]
        public bool ReplaceValidationMessageContents { get; set; }
        [DataMember]
        public string ValidationMessageId { get; set; }
        [DataMember]
        public List<ValidationRule> ValidationRules { get; set; }
    }
}
