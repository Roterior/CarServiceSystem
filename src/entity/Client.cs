using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceSystem.src.entity
{
    [Table("Client")]
    public class Client
    {
        public Client() { }

        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        [ForeignKey("ClientId")] public List<CarClient> CarClientList { get; set; }

        [ForeignKey("ClientId")] public List<OrderRepair> OrderRepairList { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int? Inn { get; set; }

        public int? PassportNumber { get; set; }

        public int? PassportSeries { get; set; }
    }
}
