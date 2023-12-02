using System;
using System.Collections.Generic;
using System.ComponentModel;
using ShopManagement.Service;

namespace ShopManagement;

public partial class Product : BaseEntity
{

    public string Name { get; set; } = null!;

    public double? Price { get; set; }

    public string? Image { get; set; }

    public int? ManufacturerId { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public int? Sold { get; set; }
    public int Stock
    {
        get
        {
            var q = Quantity != null ? Quantity : 0;
            var s = Sold != null ? Sold : 0;
            return (int)(q - s);
        }
    }

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
