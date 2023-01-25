using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SWAdventureWorks_Canale.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
        }

        public short DepartmentId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string GroupName { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
