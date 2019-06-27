using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVehicleRentalSystem.Models
{
    public static class ItemDB
    {
        public static List<tblVehicle> GetAllRecentItem()
        {
            using (var context = new OnlineVehicleDBEntities())
            {
                return context.tblVehicles.Where(s => s.IsAvailable == "Special").Take(8).ToList();
            }
        }
        public static List<tblVehicle> GetAllFoodRecentItem()
        {
            using (var context = new OnlineVehicleDBEntities())
            {
                return context.tblVehicles.Take(8).ToList();
            }
        }

    }
}