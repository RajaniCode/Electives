using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MsdnMvcWebGrid.Domain
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        public class ProductMetadata
        {
            [DisplayName("List Price")]
            public object ListPrice { get; set; }
        }
    }
}