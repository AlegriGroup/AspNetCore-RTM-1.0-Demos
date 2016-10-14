using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MachineConfiguration_CoreFx.Configuration
{
    public class DatabaseConfig
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
    }
}
