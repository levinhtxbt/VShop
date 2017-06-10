﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VShop.Model
{
    public class SlideViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeyword { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}