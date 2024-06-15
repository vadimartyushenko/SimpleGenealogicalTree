namespace SimpleGenealogicalTree.Controllers.Dto;

public class MemberDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDate { get; set; }
}
