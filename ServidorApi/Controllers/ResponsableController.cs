using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorApi.Service;
using ServidorApi.Model;



namespace ServidorApi.Controllers
{
    [Route("api/responsable")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
         
            // GET: users
            [HttpGet]
            public List<Responsable> Get()
            {
                ResponsableService objResponsableService = new ResponsableService();
                return (List<Responsable>)objResponsableService.GetAll();
            }

            // GET users/5
            [HttpGet("{id}")]
            public Responsable Get(int id)
            {
                ResponsableService objResponsableService = new ResponsableService();
                return objResponsableService.GetById(id);
            }

            // POST users
            [HttpPost]
            public void Post([FromBody] Responsable responsable)
            {
                ResponsableService objResponsableService = new ResponsableService();
                objResponsableService.Add(responsable);
            }

            // PUT users/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] Responsable responsable)
            {
                ResponsableService objResponsableService = new ResponsableService();
                objResponsableService.Update(responsable);
            }

            // DELETE users/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                ResponsableService objResponsableService = new ResponsableService();
                objResponsableService.Delete(id);
            }
        }
    }

