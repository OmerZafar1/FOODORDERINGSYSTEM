using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOderingSys.Models
{
    public class OrderDetails
    {
        public CustomerTbl CustomerD { get; set; }
        public OrderTbl OrderD { get; set; }
        public ProductTbl ProductD { get; set; }
    }
}