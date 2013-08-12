using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andarki.Wol
{
    public class MachineConfig : ConfigurationElement
    {
        public MachineConfig() { }

        public MachineConfig(int id, string name, string mac)
        {
            this.Id = id;
            this.Name = name;
            this.MacAddress = mac;
        }

        [ConfigurationProperty("Id", IsRequired = true, IsKey = true)]
        public int Id
        {
            get { return (int)this["Id"]; }
            set { this["Id"] = value; }
        }

        [ConfigurationProperty("Name", IsRequired = true, IsKey = false)]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("MacAddress", IsRequired = true, IsKey = false)]
        public string MacAddress
        {
            get { return (string)this["MacAddress"]; }
            set { this["MacAddress"] = value; }
        }

        [ConfigurationProperty("Port", IsRequired = false, IsKey = false)]
        public int? Port
        {
            get { return (int?)this["Port"]; }
            set { this["Port"] = value; }
        }
    }
}
