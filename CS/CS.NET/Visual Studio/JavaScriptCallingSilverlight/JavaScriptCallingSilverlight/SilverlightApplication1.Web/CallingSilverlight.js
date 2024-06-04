
function loadPicturesSilverlight() {
    // Get the silverlight server control
    var slPlugin = document.getElementById("Xaml1");     
    var content = slPlugin.Content;

    var postCode = document.getElementById("txtPostCode").value;
    if (postCode.match(/^\d{4}$/)) 
    {
        // Use the SilverlightPostCode that was exposed by the HtmlPage.RegisterScriptableObject method
        // Call SearchPostCode as this is the ScriptAlias for the method.
        content.SilverlightPostCode.SearchPostCode(postCode);
    }
    else {
        alert("Enter a 4 digit postcode");
    }
}  

