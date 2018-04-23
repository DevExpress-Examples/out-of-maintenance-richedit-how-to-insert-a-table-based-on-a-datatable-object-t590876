
@Html.DevExpress().RichEdit(Sub(settings)
                                settings.Name = "MyRichEdit"
                                settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "_RichEditPartial"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.Height = 500
                                settings.ReadOnly = False
                                settings.RibbonMode = RichEditRibbonMode.Ribbon
                                settings.Settings.Behavior.Save = DevExpress.XtraRichEdit.DocumentCapability.Hidden
                                settings.Settings.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Hidden
                                settings.Settings.Behavior.Open = DevExpress.XtraRichEdit.DocumentCapability.Hidden
                                settings.CalculateDocumentVariable = Sub(s, e)
                                                                         Dim rich As MVCxRichEdit = DirectCast(s, MVCxRichEdit)
                                                                         If e.VariableName = "MyCustomInsertTableField" Then
                                                                             Dim dataTable As System.Data.DataTable = T589084_VB.MyModel.GetDT1()
                                                                             Dim docServer As New DevExpress.XtraRichEdit.RichEditDocumentServer()
                                                                             Dim dataTableRows As Integer = dataTable.Rows.Count
                                                                             Dim dataTableColumns As Integer = dataTable.Columns.Count
                                                                             Dim table As DevExpress.XtraRichEdit.API.Native.Table = docServer.Document.Tables.Create(docServer.Document.Range.[End], dataTableRows + 1, dataTableColumns)
                                                                             Dim i As Integer = 0
                                                                             While i < dataTableColumns
                                                                                 docServer.Document.InsertText(table(0, i).Range.Start, dataTable.Columns(i).ColumnName)
                                                                                 System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                                                                             End While

                                                                             table.ForEachCell(Sub(cell, rowIndex, cellIndex) If rowIndex > 0 Then docServer.Document.InsertText(cell.Range.Start, dataTable.Rows(rowIndex - 1).Item(dataTable.Columns(cellIndex).ColumnName).ToString()))
                                                                             e.Value = docServer.Document
                                                                             e.Handled = True
                                                                         End If
                                                                     End Sub
                            End Sub).GetHtml()