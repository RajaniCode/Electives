using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(SimpleExamples.App_Start.MySuperPackage), "PreStart")]

namespace SimpleExamples.App_Start {
    public static class MySuperPackage {
        public static void PreStart() {
            MVCControlsToolkit.Core.Extensions.Register();
            System.Web.Mvc.GlobalFilters.Filters.Add(new MVCControlsToolkit.ActionFilters.PlaceJavascriptAttribute());
        }
    }
}