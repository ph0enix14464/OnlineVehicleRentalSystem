using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVehicleRentalSystem.Models
{
    public class MyMenu
    {
        public static List<tblSubMenu> GetMenus()
        {
            using (var context = new OnlineVehicleDBEntities())
            {
                return context.tblSubMenus.ToList();
            }
        }
        public static List<tblSubMenu> GetSubMenus(int menuid)
        {
            using (var context = new OnlineVehicleDBEntities())
            {
                return context.tblSubMenus.Where(u => u.SubMenuId == menuid).ToList();
            }
        }
    }
}