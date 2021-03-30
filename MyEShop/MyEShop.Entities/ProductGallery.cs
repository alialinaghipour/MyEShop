﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Entities
{
    public class ProductGallery
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
