using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hmt.Models
{
    public class Cart
    {
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public string pro_image { get; set; }
        public string pro_description { get; set; }
        public int pro_price { get; set; }
        public int pro_stock { get; set; }
        public int cat_id { get; set; }
    }
}