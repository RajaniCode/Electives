using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AjaxUpdatesDemo.Models
{
    public class DemoModel
    {

        [Required(ErrorMessage = "username is required")]
       public  string userName { get; set; }
        [Required(ErrorMessage = "address is required")]
       public string address { get; set; }

    }
}