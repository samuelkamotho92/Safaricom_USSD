using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaricom_USSD.DataPlan
{
    public class DataService
    {

        public List<DataplanDTO> GetDataPlan()
        {

            List<DataplanDTO> list = new List<DataplanDTO>() {
        new DataplanDTO(){Id=1,PlanDescription="15 MBS",Price = 5,Plans =Plans.Daily },
        new DataplanDTO(){Id=2,PlanDescription="20 MBS",Price = 10,Plans =Plans.Daily },
        new DataplanDTO(){Id=3,PlanDescription="30 MBS",Price = 15,Plans =Plans.Daily },
        new DataplanDTO(){Id=4,PlanDescription="200 MBS",Price = 50,Plans =Plans.Weekly},
        new DataplanDTO(){Id=5,PlanDescription="250 MBS",Price = 60,Plans =Plans.Weekly },
        new DataplanDTO(){Id=6,PlanDescription="500 MBS",Price = 100,Plans =Plans.Weekly },
        new DataplanDTO(){Id=7,PlanDescription="1 GB",Price = 500,Plans =Plans.Monthly },
        new DataplanDTO(){Id=8,PlanDescription="5 GB",Price = 1000,Plans =Plans.Monthly },
        new DataplanDTO(){Id=9,PlanDescription="10GB",Price = 2000,Plans =Plans.Monthly}
        };
            return list;
        }
    }
}
