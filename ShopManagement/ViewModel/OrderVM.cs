using ShopManagement.Service;
using ShopManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ShopManagement.ViewModel
{
    public class OrderVM : BaseVM<Order>
    {
        public new OrderService Service;
        public CustomerService CustomerService;
        public ProductService ProductService;
        public BindingList<OrderDetail> OrderDetails { get; set; }
        public OrderVM(Order? order = null)
        {
            if (order != null)
            {
                Record = (Order)order.Clone();
                OrderDetails = new BindingList<OrderDetail>((IList<OrderDetail>)Record.OrderDetails);
                RecordWindow = new OrderRecordWindow(this);
                RecordWindow.Title = "Edit Order";
                IsEditing = true;
            }
            else
            {
                Record = new Order();
                OrderDetails = new BindingList<OrderDetail>();
                Record.CreatedDate = DateTime.Now;
                RecordWindow = new OrderRecordWindow(this);
                RecordWindow.Title = "New Order";
                IsEditing = false;
            }
            Service = new OrderService();
            CustomerService = new CustomerService();
            ProductService = new ProductService();
        }

        public void AddNewDetail()
        {
            OrderDetails.Add(new OrderDetail()
            {
                OrderId = Record.Id,
                Quantity = 1,
            });
        }

        public void UpdateOrAddWithDetails()
        {
            Service?.UpdateOrAddWithDetails(Record, OrderDetails);
            RecordWindow?.Close();
            RunOnDone();
        }

    }
}
