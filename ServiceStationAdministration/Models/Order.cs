using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStationAdministration.Models
{
    public enum OrderStatus
    {
        inProgress, completed, canceled
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int CarID { get; set; }
        [Required]
        [Display(Name = "Order date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Order amount")]
        [DataType(DataType.Currency), Range(0.0, 1000.0, ErrorMessage ="Order amount should be in range 0 - 1000 US$" )]
        public decimal OrderAmount { get; set; }
        [Required]
        [Display(Name="Order status")]
        public OrderStatus OrderStatus { get; set; }

        public virtual Car Car { get; set; }


    }
}