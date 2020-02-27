using PRSDbLibrary.Controllers;
using PRSDbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRSDb {
    class Program {
        static void Main(string[] args) {
            //var context = new AppDbContext();
            var UserCtrl = new UserController();
            var VendorCtrl = new VendorController();
            var ReqCtrl = new RequestController();
            var ReqLineCtrl = new RequestLineController();
            var ProdCtrl = new ProductController();
            #region User Tests
            //UserCtrl.AddUser("admin", "admin1", "Armon", "Porter", "9375130000", "email@email.com", true, true);
            //UserCtrl.AddUser("test", "test", "test", "this", "isgoing", "tobedeleted", false, false);
            //UserCtrl.DeleteUser(2);
            //UserCtrl.GetUserByPk(1);
            //UserCtrl.GetAllUsers();
            #endregion
            #region Vendor tests
            var microsoft = new Vendor {Code = "MICRO", Name = "Microsoft", City = "Redmond", State = "WA", Address = "12234 Some Street", Zip ="78904"};
            var kroger = new Vendor { Code = "KRGR", Name = "Kroger", City = "Cincinnati", State = "OH", Address = "5432 Vine Street", Zip = "45202"};
            //VendorCtrl.AddVendor(microsoft);
            //VendorCtrl.AddVendor(kroger);
            //microsoft = VendorCtrl.GetVendorByPk(1);
            //kroger = VendorCtrl.GetVendorByPk(2);
            //kroger.Email = "help@kroger.com";
            //VendorCtrl.UpdateVendor(2, kroger);
            //foreach (var v in VendorCtrl.GetAllVendors()) {
            //    Console.WriteLine($"{v.Id} / {v.Name} / {v.Code} / {v.Email}" );
            //}
            #endregion
            #region Product Tests
            //var prod = new Product { Name = "Dell Laptop", PartNbr = "dlllptp", Price = 1200, Unit = "ea", VendorId = 1};
            //var laptop = ProdCtrl.AddProduct(prod);

            //prod = new Product { VendorId = 1, Name = "IntelliMouse", PartNbr = "IMSE", Price = 20, Unit = "ea" };
            //var mouse = ProdCtrl.AddProduct(prod);

            //foreach (var p in ProdCtrl.GetAllProducts()) {
            //    Console.WriteLine($"{p.Name} | {p.Price}");
            //}
            #endregion
            #region Request Tests
            var request1 = new Request { Description = "Order 1", UserId = 1, Justification = "This is a test"};
            //ReqCtrl.AddRequest(request1);
            request1 = ReqCtrl.GetRequestById(1);
            //request1.Justification = "Updated Justification";
            //ReqCtrl.UpdateRequest(1, request1);
            //ReqCtrl.MarkReviewed(1);
            //ReqCtrl.MarkApproved(1);
            ReqCtrl.MarkRejected(1);

            foreach (var r in ReqCtrl.GetAllRequests()) {
                Console.WriteLine($"{r.Description} / {r.Justification} / {r.Status} / {r.UserId} / {r.RejectionReason} / {r.Total}");
            }
            #endregion
            
        }

    }
}
