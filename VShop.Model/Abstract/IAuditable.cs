using System;

namespace VShop.Model
{
    public interface IAuditable
    {
        string MetaDescription { get; set; }
        string MetaKeyword { get; set; }
        DateTime CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }
        bool Status { get; set; }
    }
}