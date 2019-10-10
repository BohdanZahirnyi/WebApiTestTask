using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data.Models;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : Controller
    {
        IHeroRepository repo;
        public HeroesController(IHeroRepository r)
        {
          
            repo = r;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Hero>> Get()
        {
           
            return repo.GetHeroes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Hero> Get(int id)
        {
           
            return repo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Hero hero)
        {
            if(hero == null)
            {
                return BadRequest();
            }
            repo.Create(hero);
            return Ok(hero);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
