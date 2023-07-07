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

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = userRepository.GetUserById(id);
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
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(Guid userId, [FromBody] User user)
        {
            if (ModelState.IsValid && userId == user.UserId)
            {
                var existingUser = userRepository.GetUserById(userId);
                if (existingUser == null)
                {
                    return NotFound();
                }
                userRepository.UpdateUser(user);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid userId)
        {
            var existingTask = userRepository.GetUserById(userId);
            if (existingTask == null)
            {
                return NotFound();
            }
            userRepository.GetUserById(userId);
            return NoContent();
        }
    }
}
