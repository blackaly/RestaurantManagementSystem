using System.ComponentModel.DataAnnotations;

namespace OrderingSystem.Models.DbModels
{
    
    public class GuestSpecialRequest
    {
        [Key]
        public int GuestSpecialRequestId { get; set; }
        public string Email { get; set; }
        public string? commment { get; set; }
    }
}
