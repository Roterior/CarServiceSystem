using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceSystem.src.entity
{
    [Table("CarClient")]
    public class CarClient
    {
        public CarClient() { }

        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public int? HorsePower { get; set; }

        public int? FuelConsuption { get; set; }

        public int? MaxSpeed { get; set; }

        public int? ReleaseYear { get; set; }

        public string Color { get; set; }

        public string Model { get; set; }

        public string Maker { get; set; }

        public string BodyType { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }
    }
}
