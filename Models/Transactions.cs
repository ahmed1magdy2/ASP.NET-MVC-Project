﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace asp.net_project.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ShipId { get; set; }
        public Guid BerthId { get; set; }
        public Guid CargoId { get; set; }
        public DateTime Date { get; set; }
        public virtual Ships Ship { get; set; }
        public virtual Berths Berth { get; set; }
        public virtual ICollection <Cargo> Cargo { get;set; }
    }
}
