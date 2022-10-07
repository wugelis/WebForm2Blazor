using System;
using System.Collections.Generic;

namespace BlazorCusApp1.Server.Infrastructure.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
