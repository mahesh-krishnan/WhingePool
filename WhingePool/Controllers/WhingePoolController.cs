using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WhingePoolController : ApiController
    {
        private static readonly List<WhingePool> WhingePools = new List<WhingePool>
        {
            new WhingePool
            {
                Id = "1",
                Title = "Work",
                Description = "Some Description",
                Members = 10
            },
            new WhingePool
            {
                Id = "2",
                Title = "Life",
                Description = "Some Description about life",
                Members = 10
            },
            new WhingePool
            {
                Id = "3",
                Title = "Telstra",
                Description = "Some Description about your favourite telecom company",
                Members = 10
            },
            new WhingePool
            {
                Id = "4",
                Title = "Others",
                Description = "Everythig else",
                Members = 10
            },
            new WhingePool
            {
                Id = "5",
                Title = "Telstra",
                Description = "Everythig else",
                Members = 10
            },
            new WhingePool
            {
                Id = "6",
                Title = "Politics",
                Description = "Everythig else",
                Members = 10
            },
        };

        public static readonly Dictionary<string, List<WhingePool>> UserWhingePools = new Dictionary
            <string, List<WhingePool>>
        {
            {"Mags", new List<WhingePool> {WhingePools[0], WhingePools[1], WhingePools[2], WhingePools[3]}}
        };

        // GET api/whingepool
        public IEnumerable<WhingePool> Get()
        {
            return WhingePools;
        }

        // GET api/whingepool/5
        public IEnumerable<WhingePool> Get(string id)
        {
            return UserWhingePools[id] ?? new List<WhingePool>();
        }

        // POST api/whingepool
        public void Post([FromBody] UserWhingePool value)
        {
            if (UserWhingePools[value.UserId] == null)
            {
                UserWhingePools[value.UserId] = new List<WhingePool>();
            }
            UserWhingePools[value.UserId].Add(new WhingePool { Title = value.WhingePool });
        }


    }
}