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
            var optionSelected = Console.ReadLine();
            var selectedCatInput = validateInput(optionSelected);
            if (selectedCatInput != 0)
            {
                Console.WriteLine(selectedCatInput);
                if (selectedCatInput == 1)
                {
                    Console.WriteLine("This value ones");
                }else if (selectedCatInput == 2)
                {
                    Console.WriteLine("This is value twos");
                }
                else
                {
                    Console.WriteLine("This is value threes");
                }
            }
            else
            {
                Console.WriteLine("invalid inputs");
                showPlanCategory();
            }
        }
        public int validateInput(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Invalid choice pick a plan");
                showPlanCategory();
            }
            else
            {
                bool canConverted = int.TryParse(category, out int converted);
                if (canConverted && converted > 0 && converted < 4)
                {
                    return converted;
                }
                else
                {
                    showPlanCategory();
                }
                return 0;
            }
            showPlanCategory();
            return 0;

        }
    }
}
