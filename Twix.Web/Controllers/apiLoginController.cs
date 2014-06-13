using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twix.Web.Adapters.Adapters;
using Twix.Web.Adapters.Interfaces;
using Twix.Web.Models;

namespace Twix.Web.Controllers
{
    public class apiLoginController : ApiController
    {
        private IUser _adapter;
        public apiLoginController()
        {
            _adapter = new UserAdapter();
        }
        public IHttpActionResult Post(LoginAttempVM attempt)
        {
            UserLoggedInVM user = _adapter.FindUser(attempt);
            return Ok(user);
        }
    }
}
