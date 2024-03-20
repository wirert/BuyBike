namespace BuyBike.Core.Models
{
    using BuyBike.Infrastructure.Constants;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class BicycleDetailsDto
    {
        public Guid Id { get; set; }
               
        public decimal Price { get; set; }
                
        public string ImageUrl { get; set; } = null!;
               
        public int InStock { get; set; }
               
        public string Make { get; set; }       

        public string? Color { get; set; }

        public Dictionary<Guid, string> AvailabeColorsById { get; set; } = new Dictionary<Guid, string>();
       
        public Gender? Gender { get; set; }
               
        public string? Description { get; set; }
                
        public string Type { get; set; }

        public string Model { get; set; } = null!;
                
        public Size Size { get; set; }

        public Dictionary<Guid, string> AvailabeSizesById { get; set; } = new Dictionary<Guid, string>();

        public double TyreSize { get; set; }
    }
}
