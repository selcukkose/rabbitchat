using System;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitChatData.Models
{
	public class Room
	{
		#region Variables
		/// <summary>
		///	Room Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		///	Room Name
		/// </summary>
		public string RoomName { get; set; }

		/// <summary>
		///	Room Creator Id
		/// </summary>
		public int CreatorId { get; set; }

		/// <summary>
		///	Room Create Purpose
		/// </summary>
		public string Purpose { get; set; }

		/// <summary>
		///	Room Admin Id
		/// </summary>
		public int AdminId { get; set; }

		/// <summary>
		///	Room New Admin Id
		/// </summary>
		public int NewAdminId { get; set; }
		#endregion
	}
}