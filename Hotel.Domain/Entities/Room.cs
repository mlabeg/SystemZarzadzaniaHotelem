using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
	public class Room
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public int Capacity { get; set; }
		public string? Description { get; set; }
		public RoomType Type { get; set; }
		public int TypeRoomId { get; set; }

		public Room()
		{
		}
	}
}