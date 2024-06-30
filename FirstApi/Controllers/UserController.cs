using Microsoft.AspNetCore.Mvc;
using FirstApi;  // Add this line to reference the UserClass

public class UserController : ControllerBase
{
    private static List<User> users = new List<User>();
    // GET: api/<UserController>
    [HttpGet]
    public IEnumerable<User> Get()
    {
        return users;
    }
    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public User Get(int id)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        return user;
    }
    // POST api/<UserController>
    [HttpPost]
    public void Post([FromBody] User request)
    {
        users.Add(request);
    }
    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User request)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        else
        {
            //user.Id = id;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Job = request.Job;
            return Ok(user);
        }
    }
    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        users.Remove(user);
    }
}