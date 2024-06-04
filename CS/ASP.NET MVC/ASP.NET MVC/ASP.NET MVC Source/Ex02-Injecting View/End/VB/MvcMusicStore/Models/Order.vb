' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

<MetadataType(GetType(Order.OrderMetadata))>
Partial Public Class Order
    'Validation rules for the Order class

    <Bind(Exclude:="OrderId")>
    Public Class OrderMetadata
        <Required(ErrorMessage:="First Name is required"), DisplayName("First Name"), StringLength(160)>
        Public Property FirstName As Object

        <Required(ErrorMessage:="Last Name is required"), DisplayName("Last Name"), StringLength(160)>
        Public Property LastName As Object

        <Required(ErrorMessage:="Address is required"), StringLength(70)>
        Public Property Address As Object

        <Required(ErrorMessage:="City is required"), StringLength(40)>
        Public Property City As Object

        <Required(ErrorMessage:="State is required"), StringLength(40)>
        Public Property State As Object

        <Required(ErrorMessage:="Postal Code is required"), DisplayName("Postal Code"), StringLength(10)>
        Public Property PostalCode As Object

        <Required(ErrorMessage:="Country is required"), StringLength(40)>
        Public Property Country As Object

        <Required(ErrorMessage:="Phone is required"), StringLength(24)>
        Public Property Phone As Object

        <Required(ErrorMessage:="Email Address is required"),
        DisplayName("Email Address"),
        RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage:="Email is is not valid."),
        DataType(DataType.EmailAddress)>
        Public Property Email As Object

        <ScaffoldColumn(False)>
        Public Property OrderId As Object

        <ScaffoldColumn(False)>
        Public Property OrderDate As Object

        <ScaffoldColumn(False)>
        Public Property Username As Object

        <ScaffoldColumn(False)>
        Public Property Total As Object
    End Class
End Class
