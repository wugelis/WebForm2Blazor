using System;
using System.Collections.Generic;

namespace BlazorCusApp1.Server.Infrastructure.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
