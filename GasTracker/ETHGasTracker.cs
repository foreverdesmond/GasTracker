using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasTrackerTool
{
    public class ETHGasTracker : GasTracker
    {
        public ETHGasTracker()
        {
            infuraUrl = new ConfigHelper().ReadConfig("infuraUrlEHT");
        }
    }
}