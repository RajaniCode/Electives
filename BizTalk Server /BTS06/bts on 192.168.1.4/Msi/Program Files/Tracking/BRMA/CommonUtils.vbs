<!-- Copyright (c) Microsoft Corporation.  All rights reserved. -->
<!--  --> 
<!-- THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, -->  
<!-- WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED -->  
<!-- WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. -->  
<!-- THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE -->  
<!-- AND INFORMATION REMAINS WITH THE USER. --> 
<!--  -->

Function GetTypeName(obj) 
	GetTypeName = TypeName(obj) 
End Function 

Sub ptable1_CommandExecute(vCommand, fSucceeded)
    dim nRow
    dim nSelectedRowCount

    nRow = GetFirstSelectedRow()
    nSelectedRowCount = GetSelectedRowCount()

    if nRow >= 0 Then
		ExecuteCommand vCommand, nRow, nSelectedRowCount
    End If
End Sub

Sub ptable1_SelectionChange()
	caselist_SelectionChange
End Sub

Sub ptable1_BeforeScreenTip(screenTip, sender)
	dim oNavCtrl
	set oNavCtrl = document.CollapsibleCtrl
	
	screenTip.Value = oNavCtrl.TranslatePivotTableScreenTip(screenTip)
End Sub
