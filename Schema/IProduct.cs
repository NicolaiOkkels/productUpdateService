using System;
using Microsoft.AspNetCore.Http;

namespace product_update_service
{
    public interface IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Origin { get; set; }
    }
}

