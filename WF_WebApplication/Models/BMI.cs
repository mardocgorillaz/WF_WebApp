using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WF_WebApplication.Models
{
    public class BMI
    {
        [Display(Name = "Heigh in metre")]
        public double Height
        {
            get;
            set;
        }
        [Display(Name = "Weight in Kilogram")]
        public double Weight
        {
            get;
            set;
        }
        [Display(Name = "BMI")]
        public double BMIValue
        {
            get
            {
                // Avoiding DivideByZero exception  
                if (Height > 0)
                {
                    // BMI = Weight (in Kg) / Height (in metre) Square  
                    return Weight / (Height * Height);
                }
                else
                {
                    return 0;
                }
            }
        }
        public string Recommendation
        {
            get;
            set;
        }
    }
}