Public Class MyModel
    Public Shared Function GetDT1() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Age", GetType(Integer))
        dt.Columns.Add("Position", GetType(String))
        dt.Rows.Add("Sumit", 21, "Manager")
        dt.Rows.Add("Amit", 23, "Developer")
        dt.Rows.Add("Sumit2", 31, "Manager")
        dt.Rows.Add("Amit2", 33, "Developer")
        Return dt
    End Function

    Public Shared Function GetDT2() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Product", GetType(String))
        dt.Columns.Add("Price", GetType(Integer))
        dt.Rows.Add("Product1", 21)
        dt.Rows.Add("Product2", 23)
        dt.Rows.Add("Product3", 25)
        Return dt
    End Function
End Class