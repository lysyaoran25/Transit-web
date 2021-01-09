using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebFormsUtilities
{
    /// <summary>
    /// For classes not deriving from WFPageBase or WFUserControlBase, this interface can be implemented.
    /// WFPageBase and WFUserControlBase already implement this class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWebFormsView<T>
    {
        T Model { get; set; }
        HtmlHelper<T> Html { get; }
    }
}
