namespace DogClub.Dto;

public class IndexDto
{
    public Head[] Head { get; set; }
    public object[] Value { get; set; }
}

public class Head
{
    public string Name { get; set; }
    public string Description { get; set; }
}