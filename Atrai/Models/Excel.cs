using System;
using System.ComponentModel.DataAnnotations;

namespace Atrai.Models
{
    public class Excel
    {
        [Key]
        public int AccId { get; set; }
        [Required]
        public string AccName { get; set; }
        [Required]
        public string OP_Balance { get; set; }
        [Required]
        public DateTime OP_Date { get; set; } = DateTime.Now;
        [Required]
        public string Type { get; set; }
        [Required]
        public int Sl_No { get; set; }
    }
}
