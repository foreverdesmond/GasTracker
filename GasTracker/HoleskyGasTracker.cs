using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasTrackerTool
{
    public class HoleskyGasTracker : ETHGasTracker
    {
        public HoleskyGasTracker()
        {
            infuraUrl = new ConfigHelper().ReadConfig("infuraUrlHolesky");
        }
    }
}
