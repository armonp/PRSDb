using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PRSDbLibrary.Models;

namespace PRSDbLibrary.Controllers {
    public class ProductController {
        private AppDbContext context = new AppDbContext();

        public IEnumerable<Product> GetAllProducts() {
            return context.Products.ToList();
        }
        public Product GetProductById(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            var p = context.Products.Find(id);
            if ( p == null) throw new Exception("User Not Found");
            return p;
        }
        public Product AddProduct(Product product) {
            if (product == null) throw new Exception("Product cannot be null");
           context.Products.Add(product);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            Console.WriteLine($"Product {product.Name} added successfully !");
            return product;
        }
        public bool UpdateProduct(int id, Product product) {
            if (product == null) throw new Exception("Product cannot be null");
            if (id != product.Id) throw new Exception("Id must be same as Product.Id");
            context.Entry(product).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;

        }

        public bool DeleteProduct(int id) {
            var prod = GetProductById(id);
            return DeleteProduct(prod);
        }
        public bool DeleteProduct(Product product) {
            context.Products.Remove(product);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
            return true;
        }
    }
}
