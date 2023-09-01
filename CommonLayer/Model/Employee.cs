using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class Employee
    {
        public int Emp_id { get; set; }
        [Required(ErrorMessage ="{0} should be given") ]
        public string Emp_name {  get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public string Profile_img { get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public string Emp_gender { get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public string Emp_dep { get; set;}
        [Required(ErrorMessage = "{0} should be given")]

        public double Salary { get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public DateTime start { get; set; }
        [Required(ErrorMessage = "{0} should be given")]

        public string Notes { get; set; }



    }
}
