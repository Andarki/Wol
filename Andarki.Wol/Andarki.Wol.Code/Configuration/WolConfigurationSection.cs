using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andarki.Wol
{
    public class WolConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Machines", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(MachineCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public MachineCollection Machines
        {
            get
            {
                return (MachineCollection)base["Machines"];
            }
        }
    }
}