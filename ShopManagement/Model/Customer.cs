using System;
using System.Collections.Generic;

namespace ShopManagement;

public partial class Customer: BaseEntity
{

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
