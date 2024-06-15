namespace SimpleGenealogicalTree.Models;

public class Member : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDate { get; set; }
}
