using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleExamples.Models
{
    public class SortableListExampleViewModel
    {
        [DisplayName("Keywords")]
        public List<string> Keywords { get; set; }

        [DisplayName("Keywords")]
        public List<KeywordItem> Keywords1 { get; set; }

        public List<KeyValuePair<LambdaExpression, MVCControlsToolkit.Linq.OrderType>> KeywordsOrdering { get; set; }
    }
}