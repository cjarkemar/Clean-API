// UserModel
using System;
namespace Domain.Models.User
{
	public class UserModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int phone { get; set; }
        public string adress { get; set; } = string.Empty; 

    }
}

