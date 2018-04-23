# RichEdit - How to insert a table based on a DataTable object


<p>This example demonstrates two possible approaches that allow you to insert a table inside the RichEdit document content based on data of a DataTable object.<br><br>The first approach adds a custom "DOCVARIABLE" field to the document content on the client side, fills it with a required table in the server-side event handler, and removes this field after inserting the table on the client side. The table is inserted into the document by using the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditDocumentServertopic">RichEditDocumentServer</a> component - our non-visual document processing engine. See the <a href="https://www.devexpress.com/Support/Center/p/E3664">Table API - How to display a DataTable</a> example for more information.<br><br>The second approach initiates an AJAX request to get the table data in the JSON format on the client side. Then, the required table is created and filled with data on the client by using the <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.MVC.Scripts.MVCxClientRichEdit.members">RichEdit client-side API</a>.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T591012">ASPxRichEdit - How to insert a table based on a DataTable object</a></p>

<br/>


