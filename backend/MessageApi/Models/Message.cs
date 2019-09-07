using System;

namespace MessageApi.Models
{

	public class Message
	{

		#region Variables
		/// <summary>
		///	Message Text
		/// </summary>
		public string MessageText { get; set; }
		/// <summary>
		///	Message Sender Id
		/// </summary>
		public int SenderId { get; set; }

		/// <summary>
		///	Message Receiver Id
		/// </summary>
		public int[] ReceiverId { get; set; }

		/// <summary>
		///	Message Sended Room Id
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		///	Message Type Name
		/// </summary>
		public string MessageTypeName { get; set; }
		#endregion

	}
}