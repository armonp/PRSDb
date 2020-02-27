using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PRSDbLibrary.Models;

namespace PRSDbLibrary.Controllers {
    public class RequestLineController {
        private AppDbContext context = new AppDbContext();

        public IEnumerable<RequestLine> GetAllReqLines() {
            return context.RequestLines.ToList();
        }
        public RequestLine GetReqLineById(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            var rl = context.RequestLines.Find(id);
            if ( rl == null) throw new Exception("RequestLine Not Found");
            return rl;
        }
        public RequestLine AddRequestLine(RequestLine reqline) {
            if (reqline == null) throw new Exception("RequestLine cannot be null");
            context.RequestLines.Add(reqline);
            context.SaveChanges();
            Console.WriteLine($"Line added to {reqline.Request} for {reqline.Qty} {reqline.Product} added successfully !");
            return reqline;
        }
        public bool UpdateRequestLine(int id, RequestLine reqline) {
            if (reqline == null) throw new Exception("RequestLine cannot be null");
            if (id != reqline.Id) throw new Exception("Id must be same as RequestLine.Id");
            context.Entry(reqline).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool DeleteRequestLine(int id) {
            var rl = GetReqLineById(id);
            return DeleteRequestLine(rl);
        }
        public bool DeleteRequestLine(RequestLine reqline) {
            context.RequestLines.Remove(reqline);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
            return true;
        }
    }
}
