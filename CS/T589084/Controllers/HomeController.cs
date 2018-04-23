using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using T589084.Models;

namespace T589084.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();    
        }
        public ActionResult RichEditPartial()
        {
            return PartialView("_RichEditPartial");
        }
        public string GetJsonData()
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            DataTable table = MyModel.GetDT2();
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
    }
}