﻿using System.ComponentModel.DataAnnotations;

namespace asp.net_project.Models
{
    public class Invoices
    {
        [Key]
        public Guid Id { get; set; }
        public RegisterAccount Account { get; set; }
        public Guid TransId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
