namespace SimpleGenealogicalTree.Utils;

public class EntityNotFoundException(string message = "Entity not found") : Exception(message) { }
