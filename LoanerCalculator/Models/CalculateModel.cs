using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanerCalculator.Models
{
    public class CalculateModel
    {
        public int Id { get; set; }
        public double PrincipleAmount { get; set; }
        public double LoanDuration { get; set; }
        public double InterestRate { get; set; }
        [ScaffoldColumn(false)]
        public double Results { get; set; }
    }
}