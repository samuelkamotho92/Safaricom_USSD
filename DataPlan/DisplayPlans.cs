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
            //foreach(var plan in dataPlans.Select(x=>x.Plans).Distinct())
            //{

            //}
            Console.WriteLine((int)Plans.Daily + "  " + Plans.Daily);
            Console.WriteLine((int)Plans.Weekly + "  " + Plans.Weekly);
            Console.WriteLine((int)Plans.Monthly + "  " + Plans.Monthly);
            Console.WriteLine("Select Category");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            var optionSelected = Console.ReadLine();
            var selectedCatInput = validateInput(optionSelected,4);
            if (selectedCatInput != 0)
            {
                Console.WriteLine(selectedCatInput);
                //filter based on value input
                filterBasedCategory(selectedCatInput);
            }
            else
            {
                Console.WriteLine("invalid inputs");
                showPlanCategory();
            }
        }
        public void filterBasedCategory(int category)
        {
           var filtered = dataPlans.FindAll(x => (int)x.Plans == category);
            Console.WriteLine($"{dataPlans.Count}");
            foreach (var item in filtered)
            {
                Console.WriteLine($"{item.Id} : {item.PlanDescription} at {item.Price}");
             
            }
            Console.WriteLine("select option to buy");
            var optionSelectd = Console.ReadLine();
            var selectedInput = validateInput(optionSelectd, dataPlans.Count + 1);
            Console.WriteLine(selectedInput);
            PurchaseData purchase = new PurchaseData();
            purchase.Purchase(selectedInput);
        }


        public int validateInput(string category,int limit)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Invalid choice pick a plan");
                showPlanCategory();
            }
            else
            {
                bool canConverted = int.TryParse(category, out int converted);
                if (canConverted && converted > 0 && converted < limit)
                {
                    return converted;
                }
               
                return 0;
            }
            showPlanCategory();
            return 0;

        }
    }
}
