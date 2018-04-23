<script type="text/javascript">
        var insertedFieldIntervalStartPos = null;

        //document variable approach
        function OnClickInsertDocv(s, e) {
            MyRichEdit.selection.collapsed = true;
            MyRichEdit.commands.createField.execute();
            MyRichEdit.commands.insertText.execute("docvariable MyCustomInsertTableField");
            insertedFieldIntervalStartPos = MyRichEdit.selection.intervals[0].start;
            MyRichEdit.commands.updateField.execute(afterUpdate);
        }
        function afterUpdate() {
            var field = MyRichEdit.document.activeSubDocument.findFields(insertedFieldIntervalStartPos)[0];
            MyRichEdit.selection.intervals = [field.resultInterval];
            MyRichEdit.commands.copyContent.execute(field.interval.start + field.interval.length);
            MyRichEdit.selection.intervals = [field.interval];
            MyRichEdit.commands.backspace.execute();
        }

        //client-side table inserting approach
        function OnClickInsertJSON(s, e) {
            MyRichEdit.selection.collapsed = true;
            var selectionPos = MyRichEdit.selection.intervals[0].start;
            $.ajax({
                url: "Home/GetJsonData", success: function (result) {
                    var table = JSON.parse(result);
                    var rowsCount = table.length;
                    if (rowsCount > 0) {
                        var properties = Object.keys(table[0]);
                        var colCount = properties.length;
                        MyRichEdit.commands.insertTable.execute(colCount, rowsCount + 1);
                        var tableIndex = MyRichEdit.document.activeSubDocument.findTables(selectionPos+1)[0].index;
                        //add columns data
                        for (var i = 1; i < rowsCount + 1; i++) {
                            for (var j = 0; j < colCount; j++) {
                                var t = MyRichEdit.document.activeSubDocument.tablesInfo[tableIndex];
                                var startPos = t.rows[i].cells[j].start;
                                MyRichEdit.selection.intervals = [new ASPx.Interval(startPos, 0)];
                                MyRichEdit.commands.insertText.execute(table[i - 1][properties[j]] + "");
                            }
                        }
                        //add columns captions
                        for (var j = 0; j < colCount; j++) {
                            var t = MyRichEdit.document.activeSubDocument.tablesInfo[tableIndex];
                            var startPos = t.rows[0].cells[j].start;
                            MyRichEdit.selection.intervals = [new ASPx.Interval(startPos, 0)];
                            MyRichEdit.commands.insertText.execute([properties[j]] + "");
                        }
                    }

                }
            });
        }
</script>
@Using (Html.BeginForm())
    @Html.Action("_RichEditPartial")
    
@Html.DevExpress().Button(Sub(settings)
                              settings.Name = "InsertTable1"
                              settings.Text = "InsertByDocvariable"
                              settings.ClientSideEvents.Click = "OnClickInsertDocv"
                          End Sub).GetHtml()
    
@Html.DevExpress().Button(Sub(settings)
                              settings.Name = "InsertTable2"
                              settings.Text = "InsertUsingJSON"
                              settings.ClientSideEvents.Click = "OnClickInsertJSON"
                          End Sub).GetHtml()

End Using
