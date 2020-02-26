using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRSDbLibrary.Models {
    public class Request {
        [Key] public int Id { get; set; }
        [Required] [StringLength(80)] public string Description { get; set; }
        [Required] [StringLength(80)] public string Justification { get; set; }
        public string RejectionReason { get; set; }
        [Required] [StringLength(20)] public string DeliveryMode { get; set; } = "Pickup";
        [Required] [StringLength(10)] public string Status { get; set; } = "NEW";
        [Required] public decimal Total { get; set; } = 0;
        [Required] public int UserId { get; set; } 

        public virtual User User { get; set; }

        public virtual List<RequestLine> RequestLines { get; set; }



        public Request() { }
    }
}
