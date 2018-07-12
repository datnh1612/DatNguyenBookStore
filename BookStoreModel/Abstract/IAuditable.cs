using System;

namespace BookStoreModel.Abstract
{
    public interface IAuditable
    {
        /*
         * Attribute to implement date for product
         */

        DateTime? CreateDate { get; set; }

        string CreateBy { get; set; }

        DateTime? UpdateDate { get; set; }

        string UpdateBy { get; set; }

        /*
         * Attribute to implement SEO for project
         */

        string MetaKeyword { get; set; }

        string MetaDescription { get; set; }

        /*
         * Attribute to implement property Status
         */

        bool Status { get; set; }
    }
}
