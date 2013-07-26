using Andarki.Wol.Code;
using Andarki.Wol.Code.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Andarki.Wol.Web.Controllers
{
    public class MachineController : ApiController
    {
        // GET api/wol
        public IEnumerable<Machine> Get()
        {
            return (from MachineConfig m in this.Machines()
                    select new Machine(){ Id = m.Id, Name = m.Name} ).ToList();
        }

        // GET api/wol/123
        public Machine Get(int id)
        {
            Machine machine =(from MachineConfig m in this.Machines()
                    where m.Id == id
                    select new Machine() { Id = m.Id, Name = m.Name }).SingleOrDefault();

            if (machine == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Found no machine with id {0}", id)));

            return machine;
        }

        private IEnumerable<MachineConfig> Machines()
        {
            var wolConfigurationSection = ConfigurationManager.GetSection("MachinesSection") as WolConfigurationSection;

            return (from MachineConfig m in wolConfigurationSection.Machines
                    select m);//.AsQueryable();
        }
    }
}
