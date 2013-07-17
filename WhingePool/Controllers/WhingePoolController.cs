using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WhingePool.Core;
using WhingePool.Models;
using WhingePool.Repository;

namespace WhingePool.Controllers
{
    public class WhingePoolController : ApiController
    {
        //private static readonly List<Models.WhingePool> WhingePools = new List<Models.WhingePool>
        //{
        //    new Models.WhingePool
        //    {
        //        Id = "1",
        //        Title = "Work",
        //        Description = "Some Description",
        //        Members = 10
        //    },
        //    new Models.WhingePool
        //    {
        //        Id = "2",
        //        Title = "Life",
        //        Description = "Some Description about life",
        //        Members = 10
        //    },
        //    new Models.WhingePool
        //    {
        //        Id = "3",
        //        Title = "Telstra",
        //        Description = "Some Description about your favourite telecom company",
        //        Members = 10
        //    },
        //    new Models.WhingePool
        //    {
        //        Id = "4",
        //        Title = "Others",
        //        Description = "Everythig else",
        //        Members = 10
        //    },
        //    new Models.WhingePool
        //    {
        //        Id = "5",
        //        Title = "Telstra",
        //        Description = "Everythig else",
        //        Members = 10
        //    },
        //    new Models.WhingePool
        //    {
        //        Id = "6",
        //        Title = "Politics",
        //        Description = "Everythig else",
        //        Members = 10
        //    },
        //};

        //public static readonly Dictionary<string, List<Models.WhingePool>> UserWhingePools = new Dictionary
        //    <string, List<Models.WhingePool>>
        //{
        //    {"MaheshKrishnan", new List<Models.WhingePool> {WhingePools[0], WhingePools[1], WhingePools[2], WhingePools[3]}}
        //};

        // GET api/whingepool
        public IEnumerable<Models.WhingePool> Get()
        {
            var repository = new WhingeRepository();
            return repository.GetWhingePools();
        }

        // GET api/whingepool/5
        public IEnumerable<Whinge> Get(string id)
        {
            var repository = new WhingeRepository();
            return repository.GetWhingesInWhingePool(id);
        }

        // POST api/whingepool
        public void Post([FromBody] UserWhingePool value)
        {
            //if (UserWhingePools[value.UserId] == null)
            //{
            //    UserWhingePools[value.UserId] = new List<Models.WhingePool>();
            //}
            //UserWhingePools[value.UserId].Add(new Models.WhingePool { Title = value.WhingePool });
        }


    }
}