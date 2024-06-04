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

<MetadataType(GetType(Album.AlbumMetaData))>
Partial Public Class Album
    ' Validation rules for the Album class

    <Bind(Exclude:="AlbumId")>
    Public Class AlbumMetaData
        <ScaffoldColumn(False)>
        Public Property AlbumId As Object

        <DisplayName("Genre")>
        Public Property GenreId As Object

        <DisplayName("Artist")>
        Public Property ArtistId As Object

        <Required(ErrorMessage:="An Album Title is required"), StringLength(160)>
        Public Property Title As Object

        <DisplayName("Album Art URL"), StringLength(1024)>
        Public Property AlbumArtUrl As Object

        <Required(ErrorMessage:="Price is required"), Range(0.01, 100.0, ErrorMessage:="Price must be between 0.01 and 100.00")>
        Public Property Price As Object
    End Class
End Class
