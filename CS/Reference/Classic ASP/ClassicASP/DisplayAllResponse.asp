
<%
'----------------------------------------------------------------------------------
' Purpose: It's Workaround Method for DisplayAll Responses
'          
' Inputs : Url to redirect the page
'----------------------------------------------------------------------------------
Function DisplayAllResponse(resArray )
                       
 For Each Key in resArray  
				
    Response.Write "<TR><TD ALIGN=LEFT>" & Key & "</TD>"&"<TD ALIGN=LEFT>" & resArray(Key)& "</TD></TR>" 
				
 Next
End Function

%>
