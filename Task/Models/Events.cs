using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Task.Models
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Foreign Key
        [Required]
        public int CustomerId { get; set; }
        // Navigation property
        public Customer Customer { get; set; }
        public string Content { get; set; }
        public DateTime EventDateTime { get; set; }
        public bool IsOpen { get; set; }
    }
}
