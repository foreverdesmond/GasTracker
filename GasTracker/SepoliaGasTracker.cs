using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasTrackerTool
{
    public class SepoliaGasTracker : ETHGasTracker
    {
        public SepoliaGasTracker()
        {
            infuraUrl = new ConfigHelper().ReadConfig("infuraUrlSepolia");
        }
    }
}
