using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WebFormsUtilities.Json
{
    public class JSONFlexiGrid
    {
        private List<JSONObject> _Rows = new List<JSONObject>();

        public List<JSONObject> Rows
        {
            get { return _Rows; }
            set 
            {
                _Rows = value;
            }
        }

        public List<JSONFlexiColumn> ColModel = new List<JSONFlexiColumn>();

        public void AddRow(string id, string[] cellData)
        {
            Rows.Add(new JSONObject(new { id = id, cell = cellData }));
        }
        public void AddRow(string id, List<string> cellData)
        {
            AddRow(id, cellData.ToArray());
        }

        /// <summary>
        /// First populate ColModel. This output can be assigned to the colModel property of the .flexigrid() call.
        /// Using this functionality is optional but can be helpful for dynamically generating colModel JSON from C#.
        /// </summary>
        /// <returns></returns>
        public string RenderFlexDefinition()
        {
            var jsonObj = new JSONObject()
            {
                Value = ColModel.Select(c =>
                    new JSONObject(new
                    {
                        display = c.display,
                        name = c.name,
                        width = c.width,
                        sortable = c.sortable,
                        align = c.align
                    })).ToArray()
            };
            return jsonObj.Render();
        }

        /// <summary>
        /// Renders JSON data that can be added on the client side using .flexAddData()
        /// Rows must first be populated.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public string RenderFlexData(int page)
        {
            var jsonObj = new JSONObject(new { page = page.ToString(), total = Rows.Count.ToString(), rows = Rows });
            return jsonObj.Render();
        }

        public JSONFlexiGrid()
        {

        }
    }

    public class JSONFlexiColumn
    {
        public string display { get; set; }
        public string name { get; set; }
        public int width { get; set; }
        public bool sortable { get; set; }
        public string align { get; set; }
        public JSONFlexiColumn()
        {
            display = "";
            name = "";
            width = 50;
            sortable = true;
            align = "left";
        }
    }
}
