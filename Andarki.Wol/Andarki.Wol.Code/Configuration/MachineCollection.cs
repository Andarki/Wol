using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andarki.Wol
{
    public class MachineCollection : ConfigurationElementCollection
    {
        public MachineConfig this[int index]
        {
            get { return (MachineConfig)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(MachineConfig machineConfig)
        {
            BaseAdd(machineConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MachineConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MachineConfig)element).Id;
        }

        public void Remove(MachineConfig machineConfig)
        {
            BaseRemove(machineConfig.Id);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
