using System;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitChatData.Models
{
	public class RoomMembership
	{
		#region Variables
		/// <summary>
		///	Room Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		///	Room Member Id
		/// </summary>
		public int MemberId { get; set; }

		/// <summary>
		///	Room Id
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		///	Room Admin Id
		/// </summary>
		public int AdminId { get; set; }

		/// <summary>
		///	Room Create Date
		/// </summary>
		public DateTimeOffset CreateDate { get; set; }
		#endregion
	}
}