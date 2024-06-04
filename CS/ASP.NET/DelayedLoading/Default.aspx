<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DelayedContentLoading._Default" %>

<%@ Register Src="RSSFeed.ascx" TagName="RSSFeed" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Delayed Content Loading Demo Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="width:300px; float:left;">
            <uc1:RSSFeed id="RSSFeed1" runat="server"
                RSSTitle="MSDN: United States"
                URL="http://msdn.microsoft.com/globalrss/en-us/global-msdn-en-us.xml"  />
            <uc1:RSSFeed id="RSSFeed2" runat="server"
                RSSTitle="ASP.NET News" 
                URL="http://www.asp.net/News/rss.ashx" />
            <uc1:RSSFeed id="RSSFeed3" runat="server"
                RSSTitle="ASP.NET Daily Articles"
                URL="http://www.asp.net/modules/articleRss.aspx?count=5&mid=64" />
            <uc1:RSSFeed id="RSSFeed4" runat="server"
                RSSTitle="ASP.NET Team Blogs" timer="10000"
                URL="http://weblogs.asp.net/aspnet-team/rss.aspx" />
            <uc1:RSSFeed id="RSSFeed5" runat="server"
                RSSTitle="ASP.NET Community Blogs"
                URL="http://weblogs.asp.net/communityblogs/rss.aspx"  />
            <uc1:RSSFeed id="RSSFeed6" runat="server"
                RSSTitle="Example of An Invalid Feed" 
                URL="http://localhost" />
            <uc1:RSSFeed id="RSSFeed7" runat="server"
                RSSTitle="Example of A Missing URL"
                URL=""  />
         </div>
         <div style="float:left;">
             <h1>
                 Delayed Loading Example</h1>
             <p>
                 The point of this this demonstration is to allow the main part of the page to load first and fast and then load
                 the remaining page parts as they are processed. &nbsp;<strong>Refresh this page </strong>
                 and you will see that the main body always load first and fast before the RSS feed
                 headlines in the sidebar are loaded.</p>
             <p>
                 The column to the left is using the &lt;asp:timer/&gt; from the <a href="http://ajax.aspx.net">
                     AJAX.net framework</a>
                 to delay the loading of a user control until the rest of the page has loaded.&nbsp;
                 Each block of RSS headlines begins loading 1 millisecond after the page loads.&nbsp; For demonstration purposes, Dmitryr's ever-useful <a href="http://blogs.msdn.com/dmitryr/archive/2006/02/21/536552.aspx">
                     ASP.net RSS Toolkit </a>is being used to consume the feeds in a user control
                 but, this will work with other things like retrieving data from a web service or
                 when loading large amounts of information.</p>
             <p>
                 <strong>The usercontrols load serially</strong>.&nbsp; This is important to understand.&nbsp;
                 Triggering the timer on the first control will reset the timers for the remaining
                 controls.&nbsp; This means that the timers for subsequent controls begin after the
                 last control is loaded.&nbsp; You can load groups of controls together using a single
                 timer but, it is important to note how multiple timers are triggered on the page.&nbsp;
                 <strong>This example uses a separate timer for each RSS block</strong> so they load
                 sequentially.&nbsp;
             </p>
             <p>
                 If you wanted the RSS blocks to load as a group, you would remove the individual
                 timers out of the RSS usercontrol, make the "DisplayRSS" subroutine public, and
                 add a single timer to the parent page with the necessary instruction to load all
                 of the blocks.&nbsp; Its "OnTick" command would trigger all of the blocks at once--still
                 after the page loads.</p>
             <p>
                 The last two RSS feeds simply show what happens if the control fails to load.&nbsp;
                 In this case, one of the feeds has a bad URL and the other has a missing URL so,
                 a basic failure message is displayed.</p>
             <hr />
             <p>
                 Dolor sit amet, consectetuer adipiscing elit. Aliquam tempor enim eget nibh. Proin pulvinar pretium leo. Sed sit amet urna. Quisque non augue. Vivamus in ligula. Nulla facilisi. Sed dictum eros eleifend urna. Aliquam erat volutpat. Pellentesque sem sem, egestas non, volutpat vel, sagittis ac, ligula. Morbi ac erat. 

Nam vitae massa. Sed volutpat, elit nec molestie hendrerit, tellus leo egestas sapien, a molestie lectus ligula vel nulla. Quisque nunc. Aenean quis pede eu velit ultricies fermentum. 
             </p>
             <p>
             Maecenas justo. Nulla facilisi. Nulla mauris. Maecenas commodo est eu felis. Fusce tincidunt odio eget nunc. Aenean commodo. 

Nam sapien. Nam sit amet leo. Quisque rhoncus odio viverra libero. Sed sapien. Phasellus auctor urna ut risus. Vestibulum eleifend diam sed massa. Proin sit amet ipsum. Curabitur risus. Duis nec urna vitae lorem venenatis porttitor. Vestibulum posuere leo at ipsum. Vestibulum convallis leo et nisi. Pellentesque nec massa. 
             </p>
             <p>
             Praesent lacus odio, consectetuer at, eleifend quis, ullamcorper id, dui. 

Vestibulum quam dui, pretium placerat, pharetra eget, posuere ut, dui. Cras eros enim, hendrerit in, gravida vitae, semper congue, nisi. Pellentesque iaculis interdum ligula. Nunc ipsum massa, bibendum ut, ultrices a, tincidunt quis, erat. Nunc sapien nisi, venenatis nec, eleifend at, eleifend in, lectus. Donec egestas justo nec eros. Sed dictum aliquam lorem. Nulla mi mi, pretium at, accumsan id, aliquet eu, libero. Praesent mollis mauris id justo. Sed enim purus, feugiat vel, placerat eu, sagittis quis, odio. Ut faucibus felis vel purus. Etiam non magna sit amet erat vehicula luctus. 
             </p>
             <p>
             Cras dictum. 

Donec rutrum eros non risus. Quisque egestas cursus arcu. Aliquam tincidunt. Cras elit nisi, sagittis nec, commodo nec, dapibus eget, elit. Aliquam eleifend massa eu pede. Suspendisse euismod. Etiam at eros eu turpis accumsan lacinia. Morbi fermentum convallis elit. Mauris ut nibh. Fusce nulla quam, bibendum eget, pretium sit amet, imperdiet a, nibh. Pellentesque orci dolor, vestibulum eu, blandit in, tincidunt id, urna. Donec id orci. Curabitur volutpat tempus sapien. Nulla erat felis, scelerisque eu, aliquet vel, ultrices sit amet, ipsum. Proin scelerisque, leo quis adipiscing pretium, elit nisl molestie velit, non laoreet dolor sem ac tellus. Nam facilisis fringilla ligula. Quisque lacus massa, volutpat aliquet, fringilla at, aliquet malesuada, felis. Proin sem purus, suscipit nec, lobortis facilisis, adipiscing a, nibh. Suspendisse id nisl. Nulla magna turpis, gravida at, aliquet ut, ornare vitae, magna. 

Pellentesque congue diam quis dolor commodo cursus. Duis fringilla. Integer placerat dui a metus. Pellentesque pretium, turpis sit amet lobortis hendrerit, diam ante mollis odio, nec egestas felis leo eu ligula. Fusce sed est in mi dapibus ullamcorper. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Aenean a orci. Praesent tortor. Sed aliquam, risus sit amet ullamcorper porttitor, urna sem imperdiet velit, ut tristique ligula sem sit amet magna. Aliquam ultricies enim in pede. Donec lacus. Maecenas ac dui. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce ligula quam, placerat et, mollis a, nonummy vel, dolor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; 

Proin venenatis urna eu sem convallis malesuada. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Ut vulputate ultrices orci. Fusce tortor ligula, scelerisque nec, porttitor ac, sollicitudin ut, nulla. Aenean odio. In tortor. Cras suscipit egestas dui. Etiam odio nisi, dignissim in, laoreet a, sagittis eget, tortor. Aenean mollis orci eget sapien. Cras eleifend, lacus tempor bibendum rutrum, justo enim malesuada quam, non volutpat odio eros in est. In hac habitasse platea dictumst. Donec elementum. Etiam elementum mollis lectus. Maecenas condimentum tellus non quam. Aenean odio turpis, ullamcorper eget, iaculis sed, tempus nec, dui. Donec molestie tincidunt ligula. Ut massa purus, cursus sed, interdum sit amet, dignissim quis, elit. 

Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Praesent et libero. In convallis condimentum enim. Phasellus pede. Duis in leo. Sed porttitor sapien vel neque. 
             </p>
             <p>
                 Nulla vel risus id turpis tempor viverra. Sed metus. Aliquam erat volutpat. Quisque pede elit, consectetuer et, viverra sed, fermentum quis, risus. Vivamus pulvinar malesuada velit. Pellentesque porta mauris eu neque. Maecenas eu lorem a diam elementum nonummy. Suspendisse ligula. Donec varius eros eu quam. Vivamus convallis velit sed felis consectetuer fringilla. Morbi enim felis, euismod vel, dapibus ac, rutrum at, risus. 

Vivamus vestibulum lectus a diam. Nullam eu nulla sit amet massa nonummy dapibus. Vestibulum iaculis. Integer eu diam ut justo vehicula eleifend. Duis eu elit. Aenean a urna sit amet enim consequat placerat. Nulla facilisi. Mauris placerat nunc eget erat. Integer sed sapien. Ut vel mauris. In a justo sed ante iaculis feugiat. Integer sapien mi, commodo et, varius nec, placerat ac, nisi. Maecenas vehicula augue id quam. Duis nec est sit amet est vulputate scelerisque. Aenean turpis risus, convallis a, tempor in, tempus et, arcu. 

Vestibulum et nisl vel sem dapibus vestibulum. Aenean egestas porttitor libero. In hac habitasse platea dictumst. Donec sodales nonummy leo. Curabitur posuere purus fermentum diam. Vivamus adipiscing posuere nisi. Nullam nonummy, ipsum in elementum consectetuer, nisi magna porttitor felis, consectetuer hendrerit felis nunc nec metus. Ut vestibulum, massa at gravida sagittis, tellus pede consequat mauris, ac mollis sem massa vitae nibh. Curabitur placerat, lectus et feugiat tristique, dui orci mattis augue, vel bibendum velit purus ut lacus. Sed vitae nulla vel mauris tempor placerat. Maecenas interdum dictum tellus. Mauris posuere, lacus non aliquet sagittis, nunc pede facilisis eros, ut feugiat urna enim sed mauris. Phasellus euismod vestibulum eros. Curabitur vitae justo ac ipsum vehicula nonummy. Aliquam erat volutpat. Duis varius auctor orci. Suspendisse eros erat, auctor ac, accumsan sit amet, convallis vel, leo. Sed vel orci at nulla euismod lobortis. 
             </p>


         </div>
    </form>
</body>
</html>
