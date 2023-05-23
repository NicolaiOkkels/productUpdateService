using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using product_update_service;

namespace product_update_service.Entities
{
    public class Wine
    {
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        [GraphQLDescription("name of the wine")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Origin { get; set; } = null!;
        public float AlcoholPercentage { get; set; }
        public int Year { get; set; }
        public string Image { get; set; } = null!;
        public string Size { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}

