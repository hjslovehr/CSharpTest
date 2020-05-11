using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPostData
{

    public class VehicleList
    {
        public string fMethod { get; set; } = "GateOpeningVehicleList";
        //public string fMethod { get; set; } = "PresentVehicleList";
        public string fStartTime { get; set; }
        public string fEndTime { get; set; }
        public string fPlateCode { get; set; } = string.Empty;
        public string fChnlNo { get; set; } = string.Empty;
        public int fPageIndex { get; set; } = 1;
        public int fPageSize { get; set; } = 10;
        public bool fIsPresent { get; set; } = false;
    }
}
