function ShortcutKeys() 
{
        //alert(event.keyCode);
        
        // No. 1 Pressed For Page1
        if (event.keyCode == 49)
        {
            document.getElementById('ctl00_ContentPlaceHolder1_lbPage1').click();
        }
        
        // No. 2 Pressed For Page2
        if (event.keyCode == 50)
        {
            document.getElementById('ctl00_ContentPlaceHolder1_lbPage2').click();
        }
        
        // No. 3 Pressed For Page3
        if (event.keyCode == 51)
        {            
            document.getElementById('ctl00_ContentPlaceHolder1_lbPage3').click();
        }       
}

function HomeKey()
{
    if(event.keyCode == 72)
    {
        document.getElementById('ctl00_ContentPlaceHolder1_btnHome').click();
    }
}


