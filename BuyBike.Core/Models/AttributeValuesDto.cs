namespace BuyBike.Core.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class AttributeValuesDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<string> Values { get; set; } = Enumerable.Empty<string>();
    }
}
