using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq.Expressions;

namespace WebFormsUtilities.TagProcessors {
    public interface IHtmlTagPreProcessor {
        //HtmlTag PreRenderProcess(HtmlTag tag, WFModelMetaData metadata, TagTypes tagType);
        HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType,
            string markupName, string reflectName, object model);
        
        HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType,
            string propertyName, PropertyInfo targetProperty, object model);
    }

}
