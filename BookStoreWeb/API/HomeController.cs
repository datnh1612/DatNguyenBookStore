﻿using BookStoreServices;
using BookStoreWeb.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreWeb.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : APIControllerBase
    {

        IErrorService _errorService;

        public HomeController(IErrorService errorService) :
            base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, Paladin member";
        }
    }
}