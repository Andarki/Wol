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
    public class WakeUpController : ApiController
    {
        // POST api/wol
        /// <summary>
        /// Test Doc
        /// </summary>
        /// <param name="id">Et Id!</param>
        /// <returns>en maskine!</returns>
        public Machine Post(int id)
        {
            var machine = (from MachineConfig m in this.Machines()
                           where m.Id == id
                           select m).SingleOrDefault();

            if (machine == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Found no machine with id {0}", id)));

            WolClient.SendMagicPacket(machine.MacAddress, 
                (ConfigurationManager.GetSection("MachinesSection") as WolConfigurationSection).Port);

            return new Machine { Id = machine.Id, Name = machine.Name };
        }

        private IEnumerable<MachineConfig> Machines()
        {
            var wolConfigurationSection = ConfigurationManager.GetSection("MachinesSection") as WolConfigurationSection;

            return (from MachineConfig m in wolConfigurationSection.Machines
                    select m);//.AsQueryable();
        }
    }
}
