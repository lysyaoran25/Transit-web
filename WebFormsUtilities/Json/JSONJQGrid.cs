using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.Script.Serialization;

namespace WebFormsUtilities.Json
{
    /// <summary>
    /// A class used to serialize a JSON object for use with jqGrid from a result set.
    /// </summary>
    public class JSONJQGrid
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<JSONJQGridRow> Rows { get; set; }

        public string Render()
        {

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //return jss.Serialize(new {
            //    totalpages = TotalPages,
            //    page = CurrentPage,
            //    totalrecords = TotalRecords,
            //    rows = Rows.ToList().Select(x =>
            //        new {
            //            i = x.Index,
            //            cell = x.Cell
            //        }).ToArray()
            //}).Replace("\r", "").Replace("\n", "");

            var jsonData = new JSONObject(
                new {
                    totalpages = TotalPages,
                    page = CurrentPage,
                    totalrecords = TotalRecords,
                    rows = Rows.ToList().Select(x =>
                        new JSONObject(new {
                            i = x.Index,
                            cell = x.Cell
                        })).ToArray()
                });
            return jsonData.Render().Replace("\r", "").Replace("\n", "");
        }

        /// <summary>
        /// Sanitize HTML for JSON consumption.
        /// </summary>
        /// <param name="jsonStr">The string that will be JSON serialized.</param>
        /// <returns>Returns a sanitized string (ie: removes linebreaks, escapes double-quotes and slashes)</returns>
        public string SanitizeFromHTML(string jsonStr)
        {
            return jsonStr.Replace("\r", "")
                .Replace("\n", "")
                .Replace("\"", "\\\"")
                .Replace("/", "\\/");
        }    
    }
    /// <summary>
    /// An individual row for JSONJQGrid.Rows
    /// </summary>
    public class JSONJQGridRow
    {
        public int Index { get; set; }
        public string[] Cell { get; set; }
    }
}
