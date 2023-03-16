using System.ComponentModel.DataAnnotations;

namespace Hr.LeaveManagement.MVC.Models.VMs
{
    public class LeaveTypeVM : CreateLeaveTypeVM
    {
       public int Id { get; set; }
    }

    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}
