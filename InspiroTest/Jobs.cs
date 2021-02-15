using System;
using System.Collections.Generic;
using System.Text;

namespace InspiroTest
{
    public class Jobs
    {
        private int currentTotal { get; set; }
        public static void GetProducts(List<int> prices, List<object> names)
        {
            foreach (var item in Enum.GetValues(typeof(EnumMaster.Products)))
            {
                names.Add(item);
                int price = (int)item;
                prices.Add(price);
            }
        }

        public static void GetMoneys(List<int> moneys)
        { 
            foreach (var item in Enum.GetValues(typeof(EnumMaster.Moneys)))
            {
                int money = (int)item;
                moneys.Add(money);
            }
        }

        public static void Total(int total, int currTotal)
        {
            total = total + currTotal;
        }

        public int biskuit = 10;
    }
}
