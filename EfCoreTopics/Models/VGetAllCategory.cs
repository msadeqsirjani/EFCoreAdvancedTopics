﻿using System;
using System.Collections.Generic;

namespace EfCoreTopics.Models
{
    public partial class VGetAllCategory
    {
        public string ParentProductCategoryName { get; set; } = null!;
        public string? ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
