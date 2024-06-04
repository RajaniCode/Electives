using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleExamples.Models
{
    public class ClientBlocksViewModel
    {
        [DisplayName("Keywords")]
        public List<string> ClientKeywords { get; set; }
    }
}