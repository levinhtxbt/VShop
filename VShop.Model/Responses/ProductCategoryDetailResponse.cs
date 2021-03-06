﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VShop.Model
{
    public class ProductCategoryDetailResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HotFlag { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }

        public virtual ProductCategoryDetailResponse Parent { get; set; }
    }
}
