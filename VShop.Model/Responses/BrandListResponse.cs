﻿using System;

namespace VShop.Model
{
    public class BrandListResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}