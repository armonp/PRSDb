using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRSDbLibrary.Models {
    public class RequestLine {

        [Key] public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        [Range(1, int.MaxValue)] public int Qty { get; set; } = 1;
        public virtual Product Product { get; set;}
        public virtual Request Request { get; set; }

        public RequestLine() { }
    }
}