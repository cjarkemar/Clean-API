using Domain.Models.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("User")]
    public class User : UserModel
    {
    }
}