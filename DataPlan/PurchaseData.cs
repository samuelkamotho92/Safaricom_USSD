using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaricom_USSD.DataPlan
{
    internal class PurchaseData
    {
        public int Airtime = 0;
        List<DataplanDTO> dataPlans = new List<DataplanDTO>();
        DisplayPlans validation = new DisplayPlans();

        //constructor
        public PurchaseData()
        {
            //get a list of DTOS
            dataPlans = new DataService().GetDataPlan();
        }
        public void Purchase(int selectedId) {
            var selectedPlan = dataPlans.Find(x => x.Id == selectedId);
            Console.WriteLine($"purchasing data {selectedPlan.PlanDescription}");
            Console.WriteLine("Confirm purchase");
            Console.WriteLine("1 Yes");
            Console.WriteLine("2 No");
            //check input value
            var answ = Console.ReadLine();
            //validate
         var answInput =  validation.validateInput(answ, 3);
            if(answInput !=0 && answInput < 2)
            {
                Console.WriteLine($"Enter Amount : {selectedPlan.Price}");
                checkAirtime(selectedPlan.Id);
            }
            else
            {
                Console.WriteLine("Back to Home Page");
                validation.showPlanCategory();
            }
        }
       public void checkAirtime(int id)
        {
             var selectedPlan = dataPlans.Find(x => x.Id == id);
            if(selectedPlan.Price > Airtime)
            {
                Console.WriteLine("Purchased successfully");
            }
            else
            {
                topUpAirTime(id);
            }
        }
        public void topUpAirTime(int id)
        {
            var selectedPlan = dataPlans.Find(x => x.Id == id);
            Console.WriteLine("Add Airtime");
            var amount = Console.ReadLine();
            //enter amount
           var outputVal = validation.validateInput(amount,1000);
            if(outputVal != 0)
            {
                Airtime = outputVal;
                Purchase(id);
            }

        }

    }
}
