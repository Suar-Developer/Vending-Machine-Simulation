using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InspiroTest
{
    public class EnumMaster
    {
        public enum Products
        {
            [Description("Biskuit")]
            Biskuit = 6000,
            [Description("Chips")]
            Chips = 8000,
            [Description("Oreo")]
            Oreo = 10000,
            [Description("Tango")]
            Tango = 12000,
            [Description("Coklat")]
            Coklat = 15000,
        }

        public enum Moneys
        {
            DuaRb = 2000,
            LimaRb = 5000,
            SepuluhRb = 10000,
            DuapuluhRb = 20000,
            LimapuluhRb = 50000,
        }

        public enum Messages
        {
            [Description("Stock Is Empty")]
            NoStock,
            [Description("Invalid Cash")]
            InvalidCash,
            [Description("Thank You For Buying")]
            Thanks,
        }
    }
}
