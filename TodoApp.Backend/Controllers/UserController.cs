using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Backend.Data;
using TodoApp.Backend.Models;
using TodoApp.Backend.Repositories;

namespace TodoApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAllUsers();
        }

        // GET: api/User/{userId}
        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var user = userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.AddUser(user);
                return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/User/{userId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public IActionResult Put(Guid userId, [FromBody] User user)
        {
            if (ModelState.IsValid && userId == user.UserId)
            {
                User existingUser = userRepository.GetUserById(userId);
                if (existingUser == null)
                {
                    return NotFound();
                }
                userRepository.UpdateUser(existingUser, user);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/User/{userId}
        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid userId)
        {
            User existingUser = userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                return NotFound();
            }
            userRepository.DeleteUser(userId);
            return NoContent();
        }
    }
}
