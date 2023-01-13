
Imports System.Xml

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Get the values of number1, number2, and api_key from the query string
        Dim number1 As Integer = Integer.Parse(Request.QueryString("number1"))
        Dim number2 As Integer = Integer.Parse(Request.QueryString("number2"))
        Dim api_key As String = Request.QueryString("api_key")

        ' Verify that the api_key is valid
        If Not IsValidAPIKey(api_key) Then
            Response.StatusCode = 403 ' Forbidden
            Response.End()
        End If

        ' Perform the calculation and get the result
        Dim result As Integer = number1 + number2

        ' Create the XML document
        Dim doc As New XmlDocument()
        Dim root As XmlElement = doc.CreateElement("result")
        root.InnerText = result.ToString()
        doc.AppendChild(root)

        ' Set the content type to XML and write the document to the response
        Response.ContentType = "text/xml"
        doc.Save(Response.Output)
        Response.End()
    End Sub

    Private Function IsValidAPIKey(api_key As String) As Boolean
        ' Replace this with your own logic for validating the API key
        Return api_key = "secret_key"
    End Function
End Class
