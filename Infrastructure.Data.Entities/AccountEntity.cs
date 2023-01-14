using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Accounts")]
    public class AccountEntity
    {
        [Key, ForeignKey("Employee")]
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
    }
}
