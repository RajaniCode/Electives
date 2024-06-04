#region File Info
///
///[!output SAFE_NAMESPACE_NAME].[!output SAFE_CLASS_NAME]
///Property of <Your Company Name>
///Template Created by Muneeb R. Baig
///
///Created by <YOUR NAME HERE>
///On [!output CREATION_DATE]
///
#endregion File Info
#region File History
///$Revision: 												$
///$History:												$
///
///
#endregion File History


namespace [!output SAFE_NAMESPACE_NAME]
{
    using System;
    using System.Web.Services;
    using CrystalDecisions.Shared;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Web.Services;


    [ WebService( Namespace="http://crystaldecisions.com/reportwebservice/9.1/" ) ]
    public class [!output SAFE_CLASS_NAME] : ReportServiceBase
    {
        public [!output SAFE_CLASS_NAME]() 
        {
            this.ReportSource = new CachedWeb[!output SAFE_REPORT_CLASS_NAME]( this );
        }

        
        protected void  OnInitReport( object source, EventArgs args )
        {
        }


        public class CachedWeb[!output SAFE_REPORT_CLASS_NAME] : ICachedReport
        {
            protected [!output SAFE_CLASS_NAME]     webService = null;

            
            public CachedWeb[!output SAFE_REPORT_CLASS_NAME]
            (
                [!output SAFE_CLASS_NAME]   webServiceParam
            )
            {
                this.webService = webServiceParam;
            }

            public virtual bool IsCacheable
            {
                get { return ( true ); }
                set {}
            }

            public virtual bool  ShareDBLogonInfo
            {
                get { return ( false ); }
                set {}
            }

            public virtual TimeSpan  CacheTimeOut
            {
                get { return ( CachedReportConstants.DEFAULT_TIMEOUT ); }
                set {}
            }

            public virtual ReportDocument  CreateReport()
            {
                [!output SAFE_REPORT_CLASS_NAME]    report =
                        new [!output SAFE_REPORT_CLASS_NAME]();

                report.InitReport += new EventHandler( this.webService.OnInitReport );

                return ( report );
            }

            public virtual string  GetCustomizedCacheKey( RequestContext request )
            {
                string  key = null;

                return ( key );
            }
        } // CachedWeb[!output SAFE_REPORT_CLASS_NAME]
    } // [!output SAFE_CLASS_NAME]
} // [!output SAFE_NAMESPACE_NAME]

