using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitChatData;
using RabbitChatData.Helpers;
using RabbitChatData.Models;
using MessageApi.Models;

namespace MessageApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		[HttpPost("Send/Direct")]
		public ObjectResult PostMessageDirect([FromBody] Message body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				Messages.SaveDirectMessage(connectionHelper.GetConnection(), body.SenderId, body.ReceiverId, body.MessageText, body.MessageTypeName);

				connectionHelper.CloseConnection();
			}

			return Ok(new
			{

			});
		}

		[HttpPost("Send/Room")]
		public ObjectResult PostMessageRoom([FromBody] Message body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				Messages.SaveRoomMessage(connectionHelper.GetConnection(), body.SenderId, body.RoomId, body.MessageText, body.MessageTypeName);

				connectionHelper.CloseConnection();
			}

			return Ok(new
			{

			});
		}

	}
}
