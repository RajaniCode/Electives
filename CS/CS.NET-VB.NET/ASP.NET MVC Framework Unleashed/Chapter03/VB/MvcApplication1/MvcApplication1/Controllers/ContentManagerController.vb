Public Class ContentManagerController
    Inherits System.Web.Mvc.Controller


    Function Index()
        Return View()
    End Function

    Function Download() As ActionResult
        Return File("~/Content/CompanyPlans.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CompanyPlans.docx")
    End Function

End Class
