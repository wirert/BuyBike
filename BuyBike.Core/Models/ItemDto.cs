﻿namespace BuyBike.Core.Models
{
    using System;

    /// <summary>
    /// Product item model
    /// </summary>
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Size { get; set; } = null!;

        public bool IsInStock { get; set; }

        public string Sku { get; set; } = null!;
    }
}
