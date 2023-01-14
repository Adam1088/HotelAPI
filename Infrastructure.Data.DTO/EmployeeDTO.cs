using Core.Enums;

namespace Infrastructure.Data.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public JobTitle JobTitle { get; set; }
        public double Salary { get; set; }
    }
}
