using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adgtechAssesment.Models
{
    public class incident_model
    {
        public string Incident_No { get; set; }
        public string Incident_Desc { get; set; }
        public string Incident_Priority { get; set; }
    }

    public class incident_model_lsit
    {
        public List<incident_model> incidents { get; set; }

        public int totalcount { get; set; }
    }
}