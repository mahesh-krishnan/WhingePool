using System.Collections.Generic;
using System.Web.Http;
using WhingePool.Core.Entities;
using WhingePool.Repository;

namespace WhingePool.Controllers
{
    public class WhingePoolController : ApiController
    {
        // GET api/whingepool
        public IEnumerable<WhingePoolEntity> Get()
        {
            var repository = new WhingeRepository();
            return repository.GetWhingePools();
        }

        // GET api/whingepool/5
        public IEnumerable<WhingesByWhingePoolEntity> Get(string id)
        {
            var repository = new WhingeRepository();
            return repository.GetWhingesInWhingePool(id);
        }

    }
}