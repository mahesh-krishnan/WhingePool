using System.Collections.Generic;
using System.Web.Http;
using WhingePool.Core.Entities;
using WhingePool.Repository;

namespace WhingePool.Controllers
{
    public class WhingeController : ApiController
    {

        // GET api/whinge/5
        public IEnumerable<WhingesByWhingerEntity> Get(string id)
        {
            var repository = new WhingeRepository();
            return repository.GetWhinges(id);
        }

        // POST api/whinge
        public void Post(WhingeEntity whinge)
        {
            var repository = new WhingeRepository();
            repository.Whinge(whinge);

        }


    }
}