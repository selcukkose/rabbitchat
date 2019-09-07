using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace RabbitChatData.Models
{
	[Table("message", Schema = "public")]
	public class Messages
	{
		#region Variables
		/// <summary>
		///	Message Id
		/// </summary>
		[Key]
		[Column("id")]
		public int Id { get; set; }

		/// <summary>
		///	Message Text
		/// </summary>
		[Column("message_text")]
		public string MessageText { get; set; }

		/// <summary>
		///	Message Create Date
		/// </summary>
		[Column("create_date")]
		public DateTimeOffset CreateDate { get; set; }

		/// <summary>
		///	Message Sender Id
		/// </summary>
		[Column("sender_id")]
		public int SenderId { get; set; }

		/// <summary>
		///	Message Receiver Id
		/// </summary>
		[Column("receiver_id")]
		public int[] ReceiverId { get; set; }

		/// <summary>
		///	Message Sended Room Id
		/// </summary>
		[Column("room_id")]
		public int RoomId { get; set; }

		/// <summary>
		///	Message Type Name
		/// </summary>
		[Column("message_type_name")]
		public string MessageTypeName { get; set; }
		#endregion

		#region Methods

		/// <summary>
		///	Save Direct Message
		/// </summary>
		public static bool SaveDirectMessage(NpgsqlConnection connection, int senderId, int[] receiverId, string messageText, string messageType)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "INSERT INTO message (message_text, create_date, sender_id, receiver_id, room_id, message_type_name) VALUES (@message_text, @create_date, @sender_id, array[@receiver_id], null, @message_type_name)";
				cmd.Parameters.AddWithValue("message_text", messageText);
				cmd.Parameters.AddWithValue("create_date", DateTime.Now);
				cmd.Parameters.AddWithValue("sender_id", senderId);
				cmd.Parameters.AddWithValue("receiver_id", receiverId);
				cmd.Parameters.AddWithValue("message_type_name", messageType);
				cmd.ExecuteNonQuery();
			}

			return true;
		}

		/// <summary>
		///	Save Room Message
		/// </summary>
		public static bool SaveRoomMessage(NpgsqlConnection connection, int senderId, int roomId, string messageText, string messageType)
		{
			using (var cmd = new NpgsqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandText = "INSERT INTO message (message_text, create_date, sender_id, receiver_id, room_id, message_type_name) VALUES (@message_text, @create_date, @sender_id, null, @room_id, @message_type_name)";
				cmd.Parameters.AddWithValue("message_text", messageText);
				cmd.Parameters.AddWithValue("create_date", DateTime.Now);
				cmd.Parameters.AddWithValue("sender_id", senderId);
				cmd.Parameters.AddWithValue("room_id", roomId);
				cmd.Parameters.AddWithValue("message_type_name", messageType);
				cmd.ExecuteNonQuery();
			}

			return true;
		}

		#endregion
	}
}