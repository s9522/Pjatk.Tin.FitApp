using System.Collections.Generic;
using System.Web.Http;

namespace Pjatk.Tin.FitApp.Api.Controllers
{
    [RoutePrefix("/products")]
    public class FoodProductsController : BaseApiController
    {
        // GET: api/FoodProducts
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FoodProducts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FoodProducts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FoodProducts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FoodProducts/5
        public void Delete(int id)
        {
        }
    }
}
