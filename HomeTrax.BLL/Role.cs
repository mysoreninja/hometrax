﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTrax.BLL
{
    public class Role
    {
        public int RoleId { get; set; }

        [MaxLength(250)]
        [Required()]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

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
    }
}
