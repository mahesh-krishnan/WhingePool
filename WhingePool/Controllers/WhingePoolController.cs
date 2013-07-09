using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WhingePoolController : ApiController
    {
        private static readonly List<WhingePool> WhingePools = new List<WhingePool>()
        {
            new WhingePool() {Id = "1", Title = "Work", Description = "Some Description", Members = 10},
            new WhingePool() {Id = "2", Title = "Life", Description = "Some Description about life", Members = 10},
            new WhingePool()
            {
                Id = "3",
                Title = "Telstra",
                Description = "Some Description about your favourite telecom company",
                Members = 10
            },
            new WhingePool() {Id = "4", Title = "Others", Description = "Everythig else", Members = 10},
        };
        // GET api/whingepool
        public IEnumerable<WhingePool> Get()
        {
            return WhingePools;
        }

        // GET api/whingepool/5
        public IEnumerable<WhingePool> Get(string id)
        {
            return WhingePools;
        }

        // POST api/whingepool
        public void Post([FromBody]WhingePool value)
        {
        }

        // PUT api/whingepool/5
        public void Put(int id, [FromBody]WhingePool value)
        {
        }

        // DELETE api/whingepool/5
        public void Delete(string id)
        {
        }
    }
}
