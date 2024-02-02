using HMOManagerAPI.Data;
using HMOManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMOManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoomController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomId }, room);
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = _dbContext.Rooms.ToList();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            var existingRoom = _dbContext.Rooms.FirstOrDefault(r => r.RoomId == id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            // Should Map
            existingRoom = updatedRoom;

            _dbContext.SaveChanges();
            return Ok(existingRoom);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var existingRooms = _dbContext.Rooms.FirstOrDefault(s => s.RoomId == id);
            if (existingRooms == null)
            {
                return NotFound();
            }

            _dbContext.Remove(existingRooms);

            _dbContext.SaveChanges();
            return Ok(existingRooms);
        }
    }
}
