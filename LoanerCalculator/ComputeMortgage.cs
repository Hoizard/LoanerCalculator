using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanerCalculator
{
    public class ComputeMortgage
    {
        public static double ComputeMonthlyPayment(double principal, double years, double rate)
        {
            double monthly = 0;
            double top = principal * rate / 1200.00;
            double bottom = 1 - Math.Pow(1.0 + rate / 1200.0, -12.0 * years);
            monthly = top / bottom;
            return monthly;
        }

    }
}