using OrderingSystem.Models.DbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.Models.ViewModel
{
    public class MeniItemViewModel
    {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public bool Availability { get; set; }
            public string ImageUrl { get; set; }
        }
}

