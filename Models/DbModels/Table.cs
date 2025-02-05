using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    [Index(nameof(TableNumber), IsUnique = true)]
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public int TableNumber {get; set;}
        [Required]
        public int SeatingCapacity { get; set; }
        [MaxLength(50)]
        public TableAvabilityStatus AvabilityStatus { get; set; } = TableAvabilityStatus.Available;
        public ICollection<Reservations> Reservations { get; set; }
    }
}
