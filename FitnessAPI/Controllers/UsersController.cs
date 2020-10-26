using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessAPI.Data;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FitnessContext _context;

        public UsersController(FitnessContext context)
        {
            _context = context;
        }


        // GET function to facilitate application login. 
        // Uses an encoded header for this purpose. (Basic Auth)
        //Get: api/Users/GetUser 
        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<User>> GetUser()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var user = await _context.Users
                .Where(user => user.Email == emailAddress)
                .Include(c => c.Sessions)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            //NEVER return the plaintext password - set to null instead
            user.Password = null;

            return user;
        }

        // Retrieve's a user's session data. Undergoes login again for security.
        // TODO: Refactor to remove duplication
        //Get: api/Users/GetUserSessionInfo 
        [Authorize]
        [HttpGet]
        [Route("GetUserSessionInfo")]
        public async Task<ActionResult<string>> GetUserSessionInfo()
        {
         
            // Pulls email from Basic Authentication HTTP Header TODO: Use JWT token in future sprint
            string emailAddress = HttpContext.User.Identity.Name;

            // Saves the first table row that has a correct, decoded email.
            var user = await _context.Users
                .Include(c => c.Sessions) // Includes foreign key to Sessions Table
                .Where(user => user.Email == emailAddress)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            //NEVER return the plaintext password - set to null instead
            user.Password = null;

            //Sessions table data, pertaining to specified user is serialised.
            var sessionData = user.Sessions
                .OrderByDescending(c => c.SessionId) // most recent 50 results
                .ToArray();

            return JsonConvert.SerializeObject(sessionData);
        }


        // POST: api/Users
        // Creates a new User in the table
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        // Update email password height weight age fname lname
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /*
         * NEEDS to have userID, email and password field data in each request
         * TODO: auth check
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

    }
}
