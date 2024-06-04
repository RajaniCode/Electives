<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ModalModel>" %>
<%@ Import Namespace="ModalPop.Models" %>
<div id="RandomModal">
    <h1>
        This is a random popup!</h1>
    <div style="margin-top: 10px;">
        <%= Html.Encode(Model.SomeString) %>
    </div>
</div>
