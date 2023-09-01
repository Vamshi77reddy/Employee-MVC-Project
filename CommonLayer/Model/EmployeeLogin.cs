using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeLogin
    {
        public int Emp_id { get; set; }
        [Required(ErrorMessage = "{0} should be given")]
        public string Emp_name { get; set; }
        [Required(ErrorMessage = "{0} should be given")]
    }
}
