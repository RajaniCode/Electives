using System.Linq;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2
{
    // Article written for www.dotnetcurry.com
    public class SelectListModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the raw attempted value from the value provider
            var incomingData = bindingContext.ValueProvider.GetValue("cars").AttemptedValue;
            return incomingData.Split(new char[1] { ',' }).Select(data => Car.GetCars().FirstOrDefault(o => o.Id == int.Parse(data))).ToList();
        }
    }
}