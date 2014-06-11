using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twix.Data.Models;
using Twix.Web.Adapters.Adapters;
using Twix.Web.Adapters.Interfaces;

namespace Twix.Web.Controllers
{
    public class apiUserController : ApiController
    {
        private IUser _adapter;
        public apiUserController()
        {
            _adapter = new UserAdapter();
        }

        public IHttpActionResult Post (User user)
        {
            _adapter.Create(user);
            return Ok();
        }

        public IHttpActionResult Get (string username, string password)
        {
            User user = _adapter.GetUser(username, password);
            return Ok(user);
        }
    }
}
