Imports CustomerClass

Public Class LinqtoSqlToXml

  Public Shared Function GetXML(ByVal customers As List(Of Customer)) As String
    Dim xmlLiteral = <Customers>
        <%= From cust In customers _
        Select <Customer CustomerID=<%= cust.CustomerID %>
               CompanyName=<%= cust.CompanyName %>
               ContactName=<%= cust.ContactName %>>
        <Address><%= cust.Address %></Address>
        <City><%= cust.City %></City>
        <State><%= cust.Region %></State>
        <ZipCode><%= cust.PostalCode %></ZipCode>
        </Customer> %>
      </Customers>

    Return xmlLiteral.ToString()

  End Function

End Class
