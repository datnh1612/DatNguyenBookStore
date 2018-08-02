using BookStoreModel.Models;
using BookStoreServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreWeb.Infrastructure.Core
{
    public class APIControllerBase : ApiController
    {
        private IErrorService _errorService;

        public APIControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage,Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                // Call function input and return the response with type is a http message
                response = function.Invoke();
            }
            // Catch validation error
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                //response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            //Catch db Error
            catch (DbUpdateException dbEX)
            {
                LogError(dbEX);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEX.InnerException.Message);
            }
            catch(Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorService.Create(error);
                _errorService.Save();
            }catch
            {

            }
        }
    }
}