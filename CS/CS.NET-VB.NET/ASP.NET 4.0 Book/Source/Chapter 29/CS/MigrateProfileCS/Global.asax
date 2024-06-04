<%@ Application Language="C#" %>

<script runat="server">

	
    void Profile_MigrateAnonymous(object s, ProfileMigrateEventArgs e)
    {
        ProfileCommon anonProfile = Profile.GetProfile(e.AnonymousID);
        Profile.CourseName = anonProfile.CourseName;
        Profile.CourseDuration = anonProfile.CourseDuration;
    }


    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
