using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebFormsUtilities
{
    /// <summary>
    /// A temporary page used to hold controls that are rendered as plain text.<br/>
    /// This is not intended to be used directly and is invoked via RenderControl().
    /// </summary>
    public class WFPageHolder : Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        { /* Deliberately left blank */ }

        public object Model { get; set; }
    }
}
