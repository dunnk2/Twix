using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Twix.Data.Models;
using Twix.Web.Adapters.Adapters;
using Twix.Web.Adapters.Interfaces;
using Twix.Web.Models;

namespace Twix.Web.Controllers
{
    public class apiUserController : ApiController
    {
        private IUser _adapter;
        public apiUserController()
        {
            _adapter = new UserAdapter();
        }



        [HttpPost]
        public IHttpActionResult Post (User user)
        {
            _adapter.Create(user);
            return Ok();
        }

        public IHttpActionResult Get ()
        {
            List<UserLoggedInVM> userList = _adapter.GetUserList();
            return Ok(userList);
        }

        public IHttpActionResult Delete(int id)
        {
            _adapter.Delete(id);
            return Ok();
        }

    }
}
