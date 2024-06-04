using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RouteDebugger.Routing;

namespace RouteDebugger.Views.RouteDebugger
{
    public class DebuggerView
    {
        private string _url;
        private string _selectedHttpVerb;
        private HttpContextBase _context;


        public DebuggerView(string url, string selectedHttpVerb, HttpContextBase context)
        {
            _url = url;
            _selectedHttpVerb = selectedHttpVerb;
            _context = context;
        }




        public string ExecuteResult()
        {
            var relativeUrl = _url;
            var httpVerbs = formatOptions(_selectedHttpVerb, Enum.GetNames(typeof(HttpVerbs)));
            var resultTable = GetResultTable(_context);
            return String.Format(htmlTemplate, relativeUrl, httpVerbs, resultTable);
        }


        private string formatOptions(string selected, string[] values)
        {
            var sb = new StringBuilder();
            foreach (string value in values)
            {
                var showSelected = String.Empty;
                if (value == selected)
                    showSelected = "selected='selected'";
                sb.AppendFormat("<option value='{0}' {1}>{0}</option>", value, showSelected);
            }
            return sb.ToString();
        }




        private string GetResultTable(HttpContextBase context)
        {
            var sb = new StringBuilder();
            foreach (NamedRoute route in RouteTable.Routes)
            {
                var rd = route.GetRouteData(context);
                // Get match
                var isMatch = false;
                var match = rd == null ? "No Match" : "Match";

                // Get values
                var values = "N/A";
                if (rd != null)
                {
                    isMatch = true;
                    values = formatValues(rd.Values);
                }

                // Get defaults
                var defaults = formatValues(route.Defaults);

                // Get constraints
                var constraints = formatValues(route.Constraints);

                // Get dataTokens
                var dataTokens = formatValues(route.DataTokens);

                // Create table row
                var row = formatRow(isMatch, match, route.Name, route.Url, defaults, constraints, dataTokens, values);
                sb.Append(row);
            }
            return sb.ToString();
        }

        private string formatValues(RouteValueDictionary values)
        {
            if (values == null)
                return "N/A";
            var col = new List<String>();
            foreach (string key in values.Keys)
            {
                object value = values[key] ?? "[null]";
                col.Add(key + "=" + value.ToString());
            }
            return String.Join(", ", col.ToArray());
        }

        private string formatRow(bool hilite, params string[] cells)
        {
            var sb = new StringBuilder();
            sb.Append(hilite ? "<tr class='hilite'>" : "<tr>");
            foreach (string cell in cells)
                sb.AppendFormat("<td>{0}</td>", cell);
            sb.Append("</tr>");
            return sb.ToString();
        }





        const string htmlTemplate = @"
            <html>
            <head>
                <title>Route Debugger</title>
                <style type='text/css'>
                table {{ border-collapse:collapse }}
                td
                {{
                    font:10pt Arial;
                    border: solid 1px black;
                    padding:3px; 
                }}
                .hilite {{background-color:lightgreen}}
                </style>
            </head>
            <body>
            
            <form action=''>
            <label for='url'>URL:</label>
            <input name='url' size='60' value='{0}' />
            <select name='httpVerb'>
            {1}
            </select>
            <input type='submit' value='Debug' />
            </form>

            <table>
            <caption>Routes</caption>
            <tr>
                <th>Matches</th>
                <th>Name</th>
                <th>Url</th>
                <th>Defaults</th>
                <th>Constraints</th>
                <th>DataTokens</th>
                <th>Values</th>
            </tr>
            {2}
            </table>

            </body>
            </html>

            ";



    }
}
