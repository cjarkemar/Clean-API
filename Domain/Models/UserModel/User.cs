// User
using System;
namespace Domain.Models.UserModel
{
	public class User
	{
		public string Username { get; set; } = string.Empty;

		public string PasswordHash { get; set; } = string.Empty;
	}
}

