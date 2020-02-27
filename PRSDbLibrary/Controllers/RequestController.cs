using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PRSDbLibrary.Models;

namespace PRSDbLibrary.Controllers {
    public class RequestController {
        private AppDbContext context = new AppDbContext();

        public IEnumerable<Request> GetAllRequests() {
            return context.Requests.ToList();
        }
        public Request GetRequestById(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            var req = context.Requests.Find(id);
            if ( req == null) throw new Exception("Request Not Found");
            return req;
        }
        public Request AddRequest(Request request) {
            if (request == null) throw new Exception("Request cannot be null");
            context.Requests.Add(request);
            context.SaveChanges();
            Console.WriteLine($"Request {request.Description} added successfully !");
            return request;
        }
        public bool UpdateRequest(int id, Request request) {
            if (request == null) throw new Exception("Request cannot be null");
            if (id != request.Id) throw new Exception("Id must be same as Request.Id");
            context.Entry(request).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool DeleteRequest(int id) {
            var req = GetRequestById(id);
            return DeleteRequest(req);
        }
        public bool DeleteRequest(Request request) {
            context.Requests.Remove(request);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
            return true;
        }
        
        public bool MarkReviewed(int id) {
            GetRequestById(id).Status = "REVIEW";
            context.SaveChanges();
            return true;
        }
        public bool MarkApproved(int id) {
            GetRequestById(id).Status = "APPROVED";
            context.SaveChanges();
            return true;
        }
        public bool MarkRejected(int id) {
            GetRequestById(id).Status = "REJECTED";
            if (GetRequestById(id).RejectionReason.Length < 10) throw new Exception("Rejection Reason must be included with rejected requests");
            context.SaveChanges();
            return true;
        }
    }
}
