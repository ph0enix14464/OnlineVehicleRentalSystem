//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineVehicleRentalSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrderDetail
    {
        public int OrderDetailsId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
    
        public virtual tblOrder tblOrder { get; set; }
        public virtual tblVehicle tblVehicle { get; set; }
    }
}
