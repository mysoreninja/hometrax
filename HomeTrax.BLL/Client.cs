﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTrax.BLL
{
    public class Client
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }

        [MaxLength(250)]
        [Required()]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(250)]
        [Required()]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(Validator.PhonePattern)]
        public string Phone { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        public DateTime? UpdateDate { get; set; }

        [MaxLength(100)]
        [Display(Name = "Modified By")]
        public string UpdatedBy { get; set; }

        public int? Page { get; set; }
    }
}
