//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_webapp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int ServiceID { get; set; }
        public int RoomNum { get; set; }
        public double ServicePrice { get; set; }
        public Nullable<System.DateTime> FirstDay { get; set; }
        public Nullable<System.DateTime> LastDay { get; set; }
        public Nullable<int> Quantity { get; set; }
        public double OrderPrice { get; set; }
        public Nullable<int> CarID { get; set; }
        public Nullable<int> LoundryID { get; set; }
    
        public virtual Laundry Laundry { get; set; }
        public virtual RentCar RentCar { get; set; }
        public virtual Room Room { get; set; }
    }
}
