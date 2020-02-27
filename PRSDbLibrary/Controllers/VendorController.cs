using Microsoft.EntityFrameworkCore;
using PRSDbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSDbLibrary.Controllers {
    public class VendorController {
        private AppDbContext context = new AppDbContext();

        //GetAllVendors
        public IEnumerable<Vendor> GetAllVendors () {
            return context.Vendors.ToList();
        }
        //GetVendorByPK
        public Vendor GetVendorByPk(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var vendor = context.Vendors.Find(id);
            if (vendor == null) throw new Exception("Vendor not found");
            return vendor;
        }
        //AddVendor
        public Vendor AddVendor(Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            context.Vendors.Add(vendor);
            try { 
            context.SaveChanges();
            } catch(DbUpdateException ex) {
                throw new Exception("Vendor code must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
Console.WriteLine($"Vendor {vendor.Name} added succesfully");
            return vendor;
        }

        //UpdateVendor
        public bool UpdateVendor(int id, Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            if (id != vendor.Id) throw new Exception("Id and vendor.Id must match");
            context.Entry(vendor).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Vendor Code must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        //DeleteVendor
        public bool DeleteVendor(Vendor vendor) {
            context.Vendors.Remove(vendor);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
            return true;
        }
        public bool DeleteVendor(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var vendor = context.Vendors.Find(id);
            if (vendor == null) throw new Exception("Vendor not found");
            return DeleteVendor(vendor);
        }
    
    }
}
