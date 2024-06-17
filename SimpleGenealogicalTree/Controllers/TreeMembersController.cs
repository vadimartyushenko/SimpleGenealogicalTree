using Microsoft.AspNetCore.Mvc;
using SimpleGenealogicalTree.Models;
using SimpleGenealogicalTree.DataAccess;
using SimpleGenealogicalTree.Controllers.Dto;
using SimpleGenealogicalTree.Utils;

namespace SimpleGenealogicalTree.Controllers;

[Route("[controller]")]
[ApiController]
public class TreeMembersController : ControllerBase
{
    readonly DbConnector _dbConnector;

    public TreeMembersController(DbConnector dbConnector)
    {
        _dbConnector = dbConnector;
    }

    // GET: api/<TreeMemberController>
    [HttpGet]
    public ActionResult<List<MemberDto>> GetMemberList()
    {
        var items = _dbConnector.GetAllEntities<Member>().Select(x => x.ToDto());
        return Ok(items);
    }

    // GET api/<TreeMemberController>/5
    [HttpGet("{id}")]
    public ActionResult<MemberDto> Get(int id)
    {
        var member = _dbConnector.GetEntity<Member>(id);
        return Ok(member.ToDto());
    }

    // GET api/<TreeMemberController>/grandfather/byid/5
    [HttpGet("grandfather/byid/{id}")]
    public ActionResult<MemberDto> GetGrandfather(int id)
    {
        var member = _dbConnector.GetEntity<Member>(id) ?? throw new EntityNotFoundException();
        if (member.GrandfatherId.HasValue) {
            var result = _dbConnector.GetEntity<Member>(member.GrandfatherId.Value)?.ToDto();
            return Ok(result);
        }
        else
            return Ok(new EmptyResult());
    }

    // POST api/<TreeMemberController>
    [HttpPost]
    public IActionResult Post([FromBody] MemberDto dto)
    {
        var member = new Member {
            Id = default,
            Name = dto.Name,
            Surname = dto.Surname,
            BirthDayNumber = dto.BirthDate.DayNumber,
            FatherId = dto.FatherId,
            GrandfatherId = dto.GrandfatherId,
            GgrandfatherId = dto.GgrandfatherId,
        };
        var item = _dbConnector.InsertEntity(member);
        return CreatedAtAction(nameof(Get), new { item.Id }, item);
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
