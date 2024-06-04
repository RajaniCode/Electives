<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        p 
        {
        	width:300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" 
            ActiveStepIndex="0">
            <StartNavigationTemplate>
                <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" 
                    Text="Next" />
            </StartNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep runat="server" Title="Page 1">
                    <p>
                        Sed lacus. Donec lectus. Nullam pretium nibh ut turpis. Nam bibendum. In nulla tortor,
                        elementum vel, tempor at, varius non, purus. Mauris vitae nisl nec consectetuer.
                        Donec ipsum. Proin imperdiet est. Phasellus dapibus semper urna. Pellentesque ornare,
                        orci in consectetuer hendrerit, urna elit eleifend nunc, ut consectetuer nisl felis
                        ac diam. Etiam non felis. Donec ut ante. In id eros.                       
                    </p>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Page 2">
                    <p>
                        Mauris vitae nisl nec metus placerat consectetuer. Donec ipsum. Proin imperdiet
                        est. Sed lacus. Donec lectus. Nullam pretium nibh ut turpis. Nam bibendum. In nulla
                        tortor, elementum vel, tempor at, varius non, purus. Mauris vitae nisl nec metus
                        placerat consectetuer. Donec ipsum. Proin imperdiet est. Phasellus dapibus semper
                        urna. Pellentesque ornare, orci in consectetuer hendrerit, urna elit eleifend nunc,
                        ut consectetuer nisl felis ac diam.
                    </p>
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Finally">
                    <p>
                        Sed lacus. Donec lectus. Nullam pretium nibh ut turpis. Nam bibendum. In nulla tortor,
                        elementum ipsum. Proin imperdiet est. Phasellus dapibus semper urna. Pellentesque
                        ornare, orci in felis. Donec ut ante. In id eros. Suspendisse lacus turpis, cursus
                        egestas at sem.Sed lacus.</p>
                </asp:WizardStep>
            </WizardSteps>
            <FinishNavigationTemplate>
                <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" 
                    CommandName="MovePrevious" Text="Previous" />
                <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" 
                    Text="Finish" />
            </FinishNavigationTemplate>
            <HeaderTemplate>
                Wizard Example
            </HeaderTemplate>
            <StepNavigationTemplate>
                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    Text="Previous" />
                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" />
            </StepNavigationTemplate>
        </asp:Wizard>
    </div>
    </form>
</body>
</html>
