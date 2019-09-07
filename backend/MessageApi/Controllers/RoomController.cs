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
	public class RoomController : ControllerBase
	{
		[HttpPost("Create")]
		public ObjectResult CreateRoom([FromBody] Room body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var isRoomExist = Rooms.CheckRoomExist(connectionHelper.GetConnection(), body.RoomName, body.CreatorId);

				if (isRoomExist == false)
				{
					Rooms.SaveRoom(connectionHelper.GetConnection(), body.RoomName, body.CreatorId, body.Purpose);
					connectionHelper.CloseConnection();
					return Ok(new { });
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "VG433P4MT35LRA5PH4F9RKZFSQYPGZCX"
					});
				}
			}

		}

		[HttpPut("Update/Name")]
		public ObjectResult UpdateRoomName([FromBody] Room body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var isRoomAdmin = Rooms.CheckAdmin(connectionHelper.GetConnection(), body.Id, body.AdminId);

				if (isRoomAdmin == true)
				{

					var updateResult = Rooms.UpdateRoomName(connectionHelper.GetConnection(), body.Id, body.RoomName);

					if (updateResult == true)
					{
						connectionHelper.CloseConnection();
						return Ok(new { });
					}
					else
					{
						connectionHelper.CloseConnection();
						return StatusCode(400, new
						{
							ErrorCode = "YFQB9YLRPHJW86B6DUSNZRJNPZNS43D3"
						});
					}
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "M33MRBKZL79RMWGDTDWBLGQ2FSR7RA9M"
					});
				}

			}

		}

		[HttpPut("Update/Admin")]
		public ObjectResult UpdateRoomAdmin([FromBody] Room body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var isRoomAdmin = Rooms.CheckAdmin(connectionHelper.GetConnection(), body.Id, body.AdminId);

				if (isRoomAdmin == true)
				{
					var updateResult = Rooms.UpdateRoomAdmin(connectionHelper.GetConnection(), body.Id, body.NewAdminId);

					if (updateResult == true)
					{
						connectionHelper.CloseConnection();
						return Ok(new { });
					}
					else
					{
						connectionHelper.CloseConnection();
						return StatusCode(400, new
						{
							ErrorCode = "W26SSH94PHLWCE6LWR5EUNYMRA86RAP5"
						});
					}
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "ZBNMJPYN4MHQQ4CFLG8JQEV2VG7SJ69L"
					});
				}

			}

		}

		[HttpDelete("Delete")]
		public ObjectResult DeleteRoom([FromBody] Room body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var checkUserAdmin = Rooms.CheckAdmin(connectionHelper.GetConnection(), body.Id, body.AdminId);

				if (checkUserAdmin == true)
				{
					var deleteResult = Rooms.DeleteRoom(connectionHelper.GetConnection(), body.Id);

					if (deleteResult == true)
					{
						connectionHelper.CloseConnection();
						return Ok(new { });
					}
					else
					{
						connectionHelper.CloseConnection();
						return StatusCode(400, new
						{
							ErrorCode = "LCEF787WNABTB2MAA4PWQGVEYA46E6B4"
						});
					}
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "M4VKD2TG2LGZVAVD5UHS624ZYZB7M7H5"
					});
				}
			}

		}

		[HttpPost("Add/Member")]
		public ObjectResult AddMemberToRoom([FromBody] RoomMembership body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var isAdmin = Rooms.CheckAdmin(connectionHelper.GetConnection(), body.RoomId, body.AdminId);

				if (isAdmin == true)
				{
					var insertResult = RoomMembers.InsertMember(connectionHelper.GetConnection(), body.RoomId, body.MemberId);

					if (insertResult == true)
					{
						connectionHelper.CloseConnection();
						return Ok(new { });
					}
					else
					{
						connectionHelper.CloseConnection();
						return StatusCode(400, new
						{
							ErrorCode = "VBT3CHVKYNTCPF2DMM55V9MSZMCCSUFF"
						});
					}
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "ACX4UY4PGG2D4F3CNHN5JMMRKJZ9VE5B"
					});
				}
			}
		}

		[HttpDelete("Delete/Member")]
		public ObjectResult DeleteMemberToRoom([FromBody] RoomMembership body)
		{
			using (var connectionHelper = ConnectionHelper.GetConnectionHelper())
			{
				connectionHelper.OpenConnection();

				var isAdmin = Rooms.CheckAdmin(connectionHelper.GetConnection(), body.RoomId, body.AdminId);

				if (isAdmin == true)
				{
					var insertResult = RoomMembers.DeleteMember(connectionHelper.GetConnection(), body.RoomId, body.MemberId);

					if (insertResult == true)
					{
						connectionHelper.CloseConnection();
						return Ok(new { });
					}
					else
					{
						connectionHelper.CloseConnection();
						return StatusCode(400, new
						{
							ErrorCode = "VEQ8D7PUKV6HRV7Z4FHH88NJ4NKPH4VX"
						});
					}
				}
				else
				{
					connectionHelper.CloseConnection();
					return StatusCode(400, new
					{
						ErrorCode = "9MR6VJCM2GQYTK69GHNERHBWBR47YR9L"
					});
				}
			}
		}
	}
}
