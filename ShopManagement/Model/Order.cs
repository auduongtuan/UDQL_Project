using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace ShopManagement;

public partial class Order: BaseEntity
{

    public int CustomerId { get; set; }


    public DateTime? ShippedDate { get; set; }

    public string? ReceiptAddress { get; set; }
    public string? Address
    {
        get
        {
            if(ReceiptAddress.IsNullOrEmpty() && Customer != null)
            {
                return Customer.Address;
            } else
            {
                return ReceiptAddress;
            }
        }
    }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
