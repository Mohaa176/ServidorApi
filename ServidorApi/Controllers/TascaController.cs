using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorApi.Service;
using ServidorApi.Model;  

namespace ServidorApi.Controllers
{
    [Route("api/tasca")]
    [ApiController]
    public class TascaController : ControllerBase
    {
        // GET: users
        [HttpGet]
        public List<Tasca> Get(string estat)
        {
            TascaService objTascaService = new TascaService();
            return (List<Tasca>)objTascaService.GetAll(estat);
        }

        // GET users/5
        [HttpGet("{id}")]
        public Tasca Get(int id)
        {
            TascaService objTascaService = new TascaService();
            return objTascaService.GetById(id);
        }

        // POST users
        [HttpPost]
        public void Post([FromBody] Tasca tasca)
        {
            TascaService objTascaService = new TascaService();
            objTascaService.Add(tasca);
        }

        // PUT users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tasca tasca, string estat)
        {
            TascaService objTascaService = new TascaService();
            objTascaService.Update(tasca);
        }

        // DELETE users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TascaService objTascaService = new TascaService();
            objTascaService.Delete(id);
        }
    }
}

