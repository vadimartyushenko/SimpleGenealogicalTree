using SimpleGenealogicalTree.Controllers.Dto;

namespace SimpleGenealogicalTree.Models;

public class Member : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int BirthDayNumber { get; set; }
    public long? FatherId { get; set; }
    public long? GrandfatherId { get; set; }
    public long? GgrandfatherId { get; set; }

}

public static class Memberext
{
    public static MemberDto ToDto(this Member m) => new()
    {
        Id = m.Id,
        Name = m.Name,
        Surname = m.Surname,
        BirthDate = DateOnly.FromDayNumber(m.BirthDayNumber),
        FatherId = m.FatherId,
        GrandfatherId = m.GrandfatherId,
        GgrandfatherId = m.GgrandfatherId,
    };
}
