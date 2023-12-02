using System;
using System.Collections.Generic;

namespace ShopManagement;

public partial class Manufacturer: BaseEntity
{

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
