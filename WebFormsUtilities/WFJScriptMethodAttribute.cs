using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities
{
    /// <summary>
    /// Specify that this method is safe/intended to invoke via JavaScript.<br/>
    /// Call methods decorated with this attribute via JavaScript webfu.callPage(); function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class WFJScriptMethodAttribute : Attribute
    {
    }
}
