using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Pjatk.Tin.FitApp.Domain.Models;
namespace Pjatk.Tin.FitApp.Api.Controllers
{
    [RoutePrefix("products")]
    public class FoodProductsController : BaseApiController
    {
        [Route("")]
        public IEnumerable<FoodProduct> Get()
        {
            return DocumentSession.Query<FoodProduct>().ToList();
        }

        [Route("{id}")]
        public FoodProduct Get(string id)
        {
            return DocumentSession.Load<FoodProduct>(id);
        }

        [Route("")]
        public void Post(FoodProduct product)
        {
            DocumentSession.Store(product);
        }

        [Route("{id}")]
        public void Delete(int id)
        {
            DocumentSession.Delete<FoodProduct>(id);
        }

        [Route("test")]
        [HttpGet]
        public void Test()
        {
            GenerateTestData();
        }

        private void GenerateTestData()
        {
            using (var bulkInsert = DocumentSession.Advanced.DocumentStore.BulkInsert())
            {
                for (int i= 1; i < 11; i++)
                {
                    var p = new FoodProduct
                    {
                        CaloriesPerGram = (uint) i*100,
                        ProteinPerGram = (uint) i*10,
                        CarbsPerGram = (uint) i*10,
                        FatPerGram = (uint) i*10,
                        Name = "Food Product " + i
                    };
                    bulkInsert.Store(p);
                }
            }
        }
    }
}
