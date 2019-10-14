using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data.Models;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class HeroesController : Controller
    {
        IHeroRepository repo;
        public HeroesController(IHeroRepository r)
        {
          
            repo = r;
        }
      

        // GET api/heroes/get/{id?}
        [HttpGet("{id}")]
        [Route("get/{id?}/")]
        public ActionResult<IEnumerable<Hero>> Get(int id)
        {
            List<Hero> l = new List<Hero>();

            Hero hero =  repo.Get(id);
            if (hero != null)
            {
                l.Add(hero);
                return l;
            }
            return repo.GetHeroes();
        }

        // POST api/heroes/upsert
        [Route("upsert/")]
        [HttpPost]
        public ActionResult Post( Hero hero)
        {
            if(hero == null)
            {
                return BadRequest();
            }
            repo.Create(hero);
            return Ok(hero);
        }

        // PUT api/heroes/upsert/{id?}
        [HttpPut("{id}")]
        [Route("upsert/{id?}/")]
        public void Update(Hero hero)
        {
            repo.Update(hero);
        }

        // DELETE api/heroes/delete/{id?}
        [HttpDelete("{id}")]
        [Route("delete/{id?}/")]
        public ActionResult<IEnumerable<Hero>> Delete(int id)
        {
            repo.Delete(id);
            return repo.GetHeroes();

        }
    }
}
