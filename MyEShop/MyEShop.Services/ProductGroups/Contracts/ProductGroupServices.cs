﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGroups.Contracts
{
    public interface ProductGroupServices
    {
        Task<int> Add(AddProductGroupDto dto);
    }
}