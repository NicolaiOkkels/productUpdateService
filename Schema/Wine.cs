using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using product_update_service;

namespace product_update_service
{
    public class Wine : IProduct
    {
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Origin { get; set; }
        public float AlcoholPercentage { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}

