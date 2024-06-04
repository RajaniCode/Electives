using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace GridViewPathBinding
{
    public class NavigationBoundField : BoundField
    {
        protected override object GetValue(Control controlContainer)
        {
            object data = null;
            object dataItem = null;
            string boundField = DataField;

            if (controlContainer == null)
            {
                throw new HttpException("DataControlField_NoContainer");
            }

            // Get the DataItem from the container
            dataItem = DataBinder.GetDataItem(controlContainer);

            if (dataItem == null && !DesignMode)
            {
                throw new HttpException("DataItem_Not_Found");
            }

            // Get value of field in data item.
            if (!boundField.Equals(ThisExpression) && dataItem != null)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataItem);
                string propertyName = boundField;
                object currObject = dataItem;                   // Store current object here as we'll be traversing object graph.
                string[] propPath = propertyName.Split('.');  
                PropertyDescriptor property = null;
                // We're going to access the object graph from the root (dataItem)
                // property by property as specified in the BoundField.
                for (int i = 0; i < propPath.Length; ++i)
                {
                    string currProp = propPath[i];
                    property = properties.Find(currProp, false);

                    if (property == null)
                        throw new HttpException("Could not find property or subproperty " + currProp);

                    if (i < propPath.Length - 1)
                    {
                        //currObject = GetObjectValue(currObject, property.PropertyType, currProp); 
                        object newCurrObject = property.GetValue(currObject);
                        if (newCurrObject == null)
                        {
                            // Make binding silently fail to be consistent with ASP.NET databinding.
                            currObject = null;
                            break;
                            //throw new HttpException(
                            //    string.Format("Property or subproperty \"{0}\" in the path references a null object",
                            //                  currProp));
                        }
                        currObject = newCurrObject;
                        properties = TypeDescriptor.GetProperties(currObject);
                    }
                }

                data = currObject != null ? property.GetValue(currObject) : null;
            }
            else
            {
                // dataItem is null or we are binding againts the data source itself
                // by using the ThisExpression syntax.
                if (DesignMode)
                {
                    data = GetDesignTimeValue();
                }
                else
                {
                    data = dataItem;
                }
            }

            return data;

        }
    }
}
