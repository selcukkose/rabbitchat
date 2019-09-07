using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace RabbitChatData.Models
{
	[Table("room_membership", Schema = "public")]
	public class RoomMembers
	{
		#region Variables
		/// <summary>
		///	Room Id
		/// </summary>
		[Key]
		[Column("id")]
		public int Id { get; set; }

		/// <summary>
		///	Room Member Id
		/// </summary>
		[Column("member_id")]
		public int MemberId { get; set; }

		/// <summary>
		///	Room Id
		/// </summary>
		[Column("room_id")]
		public int RoomId { get; set; }

		/// <summary>
		///	Room Create Date
		/// </summary>
		[Column("create_date")]
		public DateTimeOffset CreateDate { get; set; }
		#endregion

		#region Methods
		/// <summary>
		///	Add Member To The Room
		/// </summary>
		public static bool InsertMember(NpgsqlConnection connection, int roomId, int memberId)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "INSERT INTO room_membership (member_id, room_id, create_date) VALUES (@member_id, @room_id, @create_date)";
				cmd.Parameters.AddWithValue("member_id", memberId);
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("create_date", DateTime.Now);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}

		/// <summary>
		///	Add Member To The Room
		/// </summary>
		public static bool DeleteMember(NpgsqlConnection connection, int roomId, int memberId)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "DELETE FROM room_membership WHERE room_id=@room_id AND member_id=@member_id";
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("member_id", memberId);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}
		#endregion
	}
}