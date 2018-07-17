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
    }
}