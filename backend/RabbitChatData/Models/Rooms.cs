using System;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RabbitChatData.Models
{
	[Table("room", Schema = "public")]
	public class Rooms
	{
		#region Variables
		/// <summary>
		///	Room Id
		/// </summary>
		[Key]
		[Column("id")]
		public int Id { get; set; }

		/// <summary>
		///	Room Name
		/// </summary>
		[Column("room_name")]
		public string RoomName { get; set; }

		/// <summary>
		///	Room Create Date
		/// </summary>
		[Column("create_date")]
		public DateTimeOffset CreateDate { get; set; }

		/// <summary>
		///	Room Creator Id
		/// </summary>
		[Column("creator_id")]
		public int CreatorId { get; set; }

		/// <summary>
		///	Room Create Purpose
		/// </summary>
		[Column("purpose")]
		public string Purpose { get; set; }

		/// <summary>
		///	Room Admin Id
		/// </summary>
		[Column("admin_id")]
		public int AdminId { get; set; }
		#endregion

		#region Methods

		/// <summary>
		///	Save Room
		/// </summary>
		public static bool SaveRoom(NpgsqlConnection connection, string roomName, int creatorId, string purpose)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "INSERT INTO room (room_name, create_date, creator_id, purpose, admin_id) VALUES (@room_name, @create_date, @creator_id, @purpose, @admin_id)";
				cmd.Parameters.AddWithValue("room_name", roomName);
				cmd.Parameters.AddWithValue("create_date", DateTime.Now);
				cmd.Parameters.AddWithValue("creator_id", creatorId);
				cmd.Parameters.AddWithValue("purpose", purpose);
				cmd.Parameters.AddWithValue("admin_id", creatorId);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}

		/// <summary>
		///	Get Rooms With Given Room Name And CreatorId
		/// </summary>
		public static List<Rooms> GetRoomByNameAndCreatorId(NpgsqlConnection connection, string roomName, int creatorId)
		{
			var rooms = new List<Rooms>();

			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "SELECT * FROM room WHERE room_name=@room_name AND creator_id=@creator_id";
				cmd.Parameters.AddWithValue("room_name", roomName);
				cmd.Parameters.AddWithValue("creator_id", creatorId);


				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var newRoom = new Rooms();
						newRoom.Id = reader.GetInt32(0);
						newRoom.RoomName = reader.GetString(1);
						newRoom.CreateDate = reader.GetDateTime(2);
						newRoom.CreatorId = reader.GetInt32(3);
						newRoom.Purpose = reader.GetString(4);
						newRoom.AdminId = reader.GetInt32(5);
					};
				}
			}

			return rooms;
		}

		/// <summary>
		///	Check Whether Room Exist
		/// </summary>
		public static bool CheckRoomExist(NpgsqlConnection connection, string roomName, int creatorId)
		{
			var isAvaiable = false;

			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "SELECT * FROM room WHERE room_name=@room_name AND creator_id=@creator_id";
				cmd.Parameters.AddWithValue("room_name", roomName);
				cmd.Parameters.AddWithValue("creator_id", creatorId);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						isAvaiable = true;
					};
				}
			}

			return isAvaiable;
		}


		/// <summary>
		///	Delete Room
		/// </summary>
		public static bool DeleteRoom(NpgsqlConnection connection, int roomId)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "DELETE FROM room WHERE id=@room_id";
				cmd.Parameters.AddWithValue("room_id", roomId);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}

		/// <summary>
		///	Check User Admin In Room
		/// </summary>
		public static bool CheckAdmin(NpgsqlConnection connection, int roomId, int adminId)
		{
			var isAdmin = false;
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "SELECT * FROM room WHERE id=@room_id AND admin_id=@admin_id";
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("admin_id", adminId);
				using(var reader = cmd.ExecuteReader()) {
					while(reader.Read()) {
						isAdmin = true;
					}
				}
				return isAdmin;
			}

		}

		/// <summary>
		///	Update Room Name
		/// </summary>
		public static bool UpdateRoomName(NpgsqlConnection connection, int roomId, string roomName)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "UPDATE room SET room_name=@room_name WHERE id=@room_id";
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("room_name", roomName);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}

		/// <summary>
		///	Update Room Admin
		/// </summary>
		public static bool UpdateRoomAdmin(NpgsqlConnection connection, int roomId, int adminId)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "UPDATE room SET admin_id=@admin_id WHERE id=@room_id";
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("admin_id", adminId);
				var count = cmd.ExecuteNonQuery();
				return count > 0;
			}

		}
		#endregion
	}
}