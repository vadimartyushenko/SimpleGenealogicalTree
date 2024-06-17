namespace SimpleGenealogicalTree.Controllers.Dto;

public class MemberDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDate { get; set; }
    public long? FatherId { get; set; }
    public long? GrandfatherId { get; set; }
    public long? GgrandfatherId { get; set; }
}
