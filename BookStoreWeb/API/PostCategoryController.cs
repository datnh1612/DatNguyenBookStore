using BookStoreModel.Models;
using BookStoreServices;
using BookStoreWeb.Infrastructure.Core;
using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using BookStoreWeb.Models;
using BookStoreWeb.Infrastructure.Extensions;

namespace BookStoreWeb.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : APIControllerBase
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        // Create a http message to match with the response when you call api

        // Get = select (read)
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                //Get request does'nt need validate model.
                var listCategory = _postCategoryService.GetAll();

                var listCategoryViewModel = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryViewModel);

                return response;
            });
        }


        // Post = create
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryViewModel);
                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }

                return response;
            });
        }

        //put = Update
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updatePostCategory = _postCategoryService.GetByID(postCategoryViewModel.ID);
                    updatePostCategory.UpdatePostCategory(postCategoryViewModel);
                    _postCategoryService.Update(updatePostCategory);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        //Delete
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }


    }
}