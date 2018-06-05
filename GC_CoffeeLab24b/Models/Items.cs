using GC_CoffeeLab24b.Models;



    
namespace GC_CoffeeLab24b.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Items
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        //string Item.ItemID { get; set; }




        public virtual Item Item1 { get; set; }
    }
}