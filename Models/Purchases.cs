using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab_6.Models
{
    public class Purchases
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string PurchaseDate { get; set; }
        public string MobileId { get; set; }
        public int ShopId { get; set; }
    }
}