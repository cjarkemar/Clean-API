// User
using System;
namespace Domain.Models.User
{
	public class User : UserModel
	{
		public string Username { get; set; } = string.Empty;

		public string PasswordHash { get; set; } = string.Empty;
	}
}

