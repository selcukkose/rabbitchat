using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitChatData.Models
{
	[Table("users", Schema = "public")]
	public class Users
	{
		#region Variables
		/// <summary>
		///	Message Id
		/// </summary>
		[Key]
		[Column("id")]
		public int Id { get; set; }

		/// <summary>
		///	User Firstname
		/// </summary>
		[Column("name")]
		public string Name { get; set; }

		/// <summary>
		///	User Surname
		/// </summary>
		[Column("surname")]
		public DateTimeOffset Surname { get; set; }

		/// <summary>
		///	User Profile Image
		/// </summary>
		[Column("profile_image")]
		public int ProfileImage { get; set; }
		#endregion
	}
}