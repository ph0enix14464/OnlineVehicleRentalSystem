using OnlineVehicleRentalSystem.Models;
using OnlineVehicleRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVehicleRentalSystem.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        [Authorize(Roles = "Admin")]
        public ActionResult ManageItem()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (OnlineVehicleDBEntities db = new OnlineVehicleDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<ItemViewModel> lstitem = new List<ItemViewModel>();
                var lst = db.tblVehicles.ToList();
                foreach (var item in lst)
                {
                    lstitem.Add(new ItemViewModel() { ItemId = item.VehicleId, Title = item.Title, Price = item.Price, Description = item.Description, SmallImage = item.SmallImage, LargeImage = item.LargeImage, IsAvailable = item.IsAvailable });
                }
                return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (OnlineVehicleDBEntities db = new OnlineVehicleDBEntities())
                {
                    ViewBag.SubMenus = db.tblSubMenus.ToList();
                    ViewBag.Action = "Create New Item";
                    return View(new ItemViewModel());
                }
            }
            else
            {
                using (OnlineVehicleDBEntities db = new OnlineVehicleDBEntities())
                {
                    ViewBag.Action = "Edit Item";
                    ViewBag.Menus = db.tblSubMenus.ToList();
                    tblVehicle item = db.tblVehicles.Where(i => i.VehicleId == id).FirstOrDefault();
                    ItemViewModel itemvm = new ItemViewModel();
                    itemvm.ItemId = item.VehicleId;
                    itemvm.SubMenuId = Convert.ToInt32(item.SubmenuId);
                    itemvm.Title = item.Title;
                    itemvm.Price = item.Price;
                    itemvm.Description = item.Description;
                    itemvm.SmallImage = item.SmallImage;
                    itemvm.LargeImage = item.LargeImage;
                    //HttpPostedFileBase fup = Request.Files["SmallImage"];
                    //if(fup!=null)
                    //{
                    //    if(fup.FileName!="")
                    //    {
                    //        fup.SaveAs(Server.MapPath("~/img/dogaccessories" + fup.FileName));

                    //    }
                    //}

                    //HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    //if (fup1 != null)
                    //{
                    //    if (fup1.FileName != "")
                    //    {
                    //        fup1.SaveAs(Server.MapPath("~/img/dogaccessories" + fup1.FileName));
                    //        itemvm.LargeImage = item.LargeImage;
                    //    }
                    //}



                    itemvm.IsAvailable = "Available";

                    ViewBag.SubMenus = db.tblSubMenus.ToList();

                    return View(itemvm);
                }
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(ItemViewModel ivm)
        {
            using (OnlineVehicleDBEntities db = new OnlineVehicleDBEntities())
            {
                if (ivm.ItemId == 0)
                {
                    tblVehicle itm = new tblVehicle();

                    itm.SubmenuId = Convert.ToInt32(ivm.SubMenuId);
                    itm.Title = ivm.Title;
                    itm.Price = ivm.Price;
                    itm.Description = ivm.Description;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/images/ItemImages/" + fup.FileName));
                            itm.SmallImage = fup.FileName;
                        }
                    }

                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/images/ItemImages/" + fup1.FileName));
                            itm.LargeImage = fup1.FileName;
                        }
                    }
                    itm.IsAvailable = "Available";
                    db.tblVehicles.Add(itm);
                    db.SaveChanges();
                    ViewBag.Message = "Updated Successfully";
                }
                else
                {
                    tblVehicle itm = db.tblVehicles.Where(i => i.VehicleId == ivm.ItemId).FirstOrDefault();
                    itm.SubmenuId = Convert.ToInt32(ivm.SubMenuId);
                    itm.Title = ivm.Title;
                    itm.Price = ivm.Price;
                    itm.Description = ivm.Description;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/images/ItemImages/" + fup.FileName));
                            itm.SmallImage = fup.FileName;
                        }
                    }

                    HttpPostedFileBase fup1 = Request.Files["LargeImage"];
                    if (fup1 != null)
                    {
                        if (fup1.FileName != "")
                        {
                            fup1.SaveAs(Server.MapPath("~/images/ItemImages/" + fup1.FileName));
                            itm.LargeImage = fup1.FileName;
                        }
                    }


                    db.SaveChanges();
                    ViewBag.Message = "Updated Successfully";

                }
                ViewBag.SubMenus = db.tblSubMenus.ToList();
                return View(new ItemViewModel());

            }


        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            using (OnlineVehicleDBEntities db = new OnlineVehicleDBEntities())
            {
                tblVehicle sm = db.tblVehicles.Where(x => x.VehicleId == id).FirstOrDefault();
                db.tblVehicles.Remove(sm);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}