<%@ Page Language="C#" MasterPageFile="~/Default.master" Title="Automated ColorPicker" CodeFile="~/ColorPicker.aspx.cs"
    Inherits="Automated_ColorPicker" Culture="en-US" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- harness -->
    <asp:TextBox runat="server" ID="Text" />
    <ajaxToolkit:ColorPickerExtender runat="Server" BehaviorID="ColorPicker" TargetControlID="Text" />
    <asp:Button runat="server" ID="Button" OnClientClick="return false;" />
    <script type="text/javascript">

        // (c) Copyright Microsoft Corporation.
        // This source is subject to the Microsoft Permissive License.
        // See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
        // All other rights reserved.

        // Script objects that should be loaded before we run
        var typeDependencies = ['AjaxControlToolkit.ColorPickerBehavior'];
        
        function registerTests(harness) {
            var text = harness.getElement('<%= Text.ClientID %>');
            var colorPicker = harness.getObject('ColorPicker');
            var button = harness.getElement('<%= Button.ClientID %>');
            var test = null;
            
            test = harness.addTest('Show on focus');
            test.addStep(function() { 
                harness.fireEvent(text, "onfocus");
                harness.assertTrue(colorPicker._isOpen);
            });

            test = harness.addTest('Hide on blur');
            test.addStep(function() { 
                harness.fireEvent(text, "onfocus");
                harness.fireEvent(text, "onblur");
            }, 100, function() { return !colorPicker._isOpen; });
            
            test = harness.addTest('Parse color');
            test.addStep(function() {
                text.value = 'ccff99';
                harness.fireEvent(text, "onfocus");
                harness.fireEvent(text, "onchange");
                harness.assertEqual('ccff99', colorPicker.get_selectedColor());
            });           
        }
    </script>

</asp:Content>

