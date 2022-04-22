using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
        private readonly DataContext _context;

    public UsersController(DataContext context)
    {
            _context = context;        
    }

    [HttpGet]
    //Asynchronus code
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    

    /* Synchronus code 
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        return _context.Users.ToList();
    }

    */

    // api/users/3
    [HttpGet("{id}")]
    
    //Asynchronus code
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }


    /* Synchronus code 
    public ActionResult<AppUser> GetUser(int id)
    {
        return _context.Users.Find(id);
    }
    */
}