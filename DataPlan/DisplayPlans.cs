using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaricom_USSD.DataPlan
{
    public class DisplayPlans
    {
        List<DataplanDTO> dataPlans = new List<DataplanDTO>();

        //constructor
        public DisplayPlans()
        {
            //get a list of DTOS
            dataPlans = new DataService().GetDataPlan();
        }
        //display category
        public void showPlanCategory()
        {
            foreach(var plan in dataPlans.Select(x=>x.Plans).Distinct())
            {
                Console.WriteLine(plan);
            }
        }
    }
}
