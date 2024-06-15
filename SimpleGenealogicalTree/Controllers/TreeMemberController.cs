using Microsoft.AspNetCore.Mvc;
using SimpleGenealogicalTree.Models;
using SimpleGenealogicalTree.DataAccess;

namespace SimpleGenealogicalTree.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreeMemberController : ControllerBase
{
    readonly DbConnector _dbConnector;

    public TreeMemberController(DbConnector dbConnector)
    {
        _dbConnector = dbConnector;
    }

    // GET: api/<TreeMemberController>
    [HttpGet]
    public ActionResult<List<Member>> GetMemberList()
    {
        var items = _dbConnector.GetAllEntities<Member>();
        return Ok(items);
        //return Ok(new MemberDto[] { new() { Id = 1, Name = "Pavl", Surname = "Sjdf", BirthDate = new DateOnly(2022, 1, 6) } });
    }

    // GET api/<TreeMemberController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<TreeMemberController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<TreeMemberController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TreeMemberController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
