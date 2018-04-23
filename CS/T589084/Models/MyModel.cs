using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace T589084.Models
{
    public class MyModel
    {
        public static DataTable GetDT1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Position", typeof(string));

            dt.Rows.Add("Sumit", 21, "Manager");
            dt.Rows.Add("Amit", 23, "Developer");
            dt.Rows.Add("Sumit2", 31, "Manager");
            dt.Rows.Add("Amit2", 33, "Developer");
            return dt;
        }
        public static DataTable GetDT2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Price", typeof(int));
            dt.Rows.Add("Product1", 21);
            dt.Rows.Add("Product2", 23);
            dt.Rows.Add("Product3", 25);
            return dt;
        }
    }
}