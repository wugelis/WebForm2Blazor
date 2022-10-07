using System;
using System.Collections.Generic;

namespace BlazorCusApp1.Server.Infrastructure.Models
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
