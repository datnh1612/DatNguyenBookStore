using BookStoreModel.Models;
using BookStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Infrastructure.Extensions
{
    //This class is useful when you mapping a data model to view model
    //there will be some extension and you will write methods extension into this namespace
    public static class EntityExtension
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.CreateDate = postCategoryViewModel.CreateDate;
            postCategory.CreateBy = postCategoryViewModel.CreateBy;
            postCategory.UpdateDate = postCategoryViewModel.UpdateDate;
            postCategory.UpdateBy = postCategoryViewModel.UpdateBy;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.Image = productCategoryViewModel.Image;
            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.CreateDate = productCategoryViewModel.CreateDate;
            productCategory.CreateBy = productCategoryViewModel.CreateBy;
            productCategory.UpdateDate = productCategoryViewModel.UpdateDate;
            productCategory.UpdateBy = productCategoryViewModel.UpdateBy;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.Status = productCategoryViewModel.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Description = postViewModel.Description;
            post.Alias = postViewModel.Alias;
            post.Image = postViewModel.Image;
            post.HomeFlag = postViewModel.HomeFlag;
            post.ViewCount = postViewModel.ViewCount;
            post.CreateDate = postViewModel.CreateDate;
            post.CreateBy = postViewModel.CreateBy;
            post.UpdateDate = postViewModel.UpdateDate;
            post.UpdateBy = postViewModel.UpdateBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.CategoryID = productViewModel.CategoryID;
            product.Description = productViewModel.Description;
            product.Alias = productViewModel.Alias;
            product.Image = productViewModel.Image;
            product.MoreImages = productViewModel.MoreImages;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Content = productViewModel.Content;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.CreateDate = productViewModel.CreateDate;
            product.CreateBy = productViewModel.CreateBy;
            product.UpdateDate = productViewModel.UpdateDate;
            product.UpdateBy = productViewModel.UpdateBy;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Status = productViewModel.Status;
            product.Tags = productViewModel.Tags;
        }
    }
}