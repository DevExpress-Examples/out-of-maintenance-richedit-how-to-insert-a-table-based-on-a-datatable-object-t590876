Imports DevExpress.Web.Mvc

Imports System.Web.Mvc
Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function

        Public Function RichEditPartial() As ActionResult
            Return PartialView("_RichEditPartial")
        End Function

        Public Function GetJsonData() As String
            Dim jsSerializer As JavaScriptSerializer = New JavaScriptSerializer()
            Dim parentRow As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
            Dim childRow As Dictionary(Of String, Object)
            Dim table As DataTable = MyModel.GetDT2()
            For Each row As DataRow In table.Rows
                childRow = New Dictionary(Of String, Object)()
                For Each col As DataColumn In table.Columns
                    childRow.Add(col.ColumnName, row(col))
                Next

                parentRow.Add(childRow)
            Next

            Return jsSerializer.Serialize(parentRow)
        End Function

        Public Function _RichEditPartial() As ActionResult
            Return PartialView("_RichEditPartial")
        End Function
    End Class
End Namespace