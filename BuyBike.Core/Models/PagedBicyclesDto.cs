namespace BuyBike.Core.Models
{
    using System.Collections.Generic;

    public class PagedBicyclesDto
    {
        public int TotalBicycles { get; set; }

        public ICollection<BicycleModelDto> Bicycles { get; set; } = new List<BicycleModelDto>();
    }
}
