using Andarki.Wol.Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Andarki.Wol.Web.Controllers
{
    public class WolController : ApiController
    {
        // GET api/wol
        public IEnumerable<MachineConfig> Get()
        {
            return (from MachineConfig m in this.Machines()
                    select m).ToList();

        }

        // POST api/wol
        public void Post([FromBody]int id)
        {
            MachineConfig machine = (from MachineConfig m in this.Machines()
                                     where m.Id == id
                                     select m).Single();

            WolClient.SendMagicPacket(machine.MacAddress);
        }

        private IEnumerable<MachineConfig> Machines()
        {
            var wolConfigurationSection = ConfigurationManager.GetSection("MachinesSection") as WolConfigurationSection;

            return (from MachineConfig m in wolConfigurationSection.Machines
                    select m);//.AsQueryable();
        }
    }
}
