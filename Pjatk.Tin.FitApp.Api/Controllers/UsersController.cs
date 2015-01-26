using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Pjatk.Tin.FitApp.Domain.Models;

namespace Pjatk.Tin.FitApp.Api.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : BaseApiController
    {
        [Route("")]
        public IEnumerable<User> Get()
        {
            return DocumentSession.Query<User>().ToList();
        }

        [Route("{id}")]
        public User Get(string id)
        {
            return DocumentSession.Load<User>(id);
        }

        [Route("")]
        public void Post(User user)
        {
            DocumentSession.Store(user);
        }

        [Route("{id}")]
        public void Delete(int id)
        {
            DocumentSession.Delete<User>(id);
        }
    }
}
