using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitChatData.Models
{
	[Table("login", Schema = "public")]
	public class Login
	{
		#region Variables
		/// <summary>
		///	User Id
		/// </summary>
		[Key]
		[Column("user_id")]
		public int UserId { get; set; }

		/// <summary>
		///	User Email
		/// </summary>
		[Column("email")]
		public string Email { get; set; }

		/// <summary>
		///	User Password
		/// </summary>
		[Column("password")]
		public string Password { get; set; }
		#endregion
	}
}