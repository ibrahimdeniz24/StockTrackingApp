﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Dtos.Categories
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
    }
}
