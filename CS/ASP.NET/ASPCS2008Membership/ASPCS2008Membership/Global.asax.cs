using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

using System.Web.Profile;

namespace ASPCS2008Membership
{
    public class Global : System.Web.HttpApplication
    {

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

        void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs pe)
        {
            ProfileCommon anonProfile = Profile.GetProfile(pe.AnonymousID);

            if (anonProfile.UserInfo.Name != null || anonProfile.UserInfo.Name != "")
            {
                Profile.UserInfo = anonProfile.UserInfo;
            }

            System.Web.Profile.ProfileManager.DeleteProfile(pe.AnonymousID);

            AnonymousIdentificationModule.ClearAnonymousIdentifier();
        }
    }
}