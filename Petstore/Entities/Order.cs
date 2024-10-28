﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Models
{
    [Table("Orders")]
    public class Order
    {
            public int OrderId {  get; set; }
            public int OrderNumber { get; set; }
            public DateTime OrderDate { get; set; }
            public ICollection<Product> Products { get; set; }
    }
}