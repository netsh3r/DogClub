namespace DogClub.Models;

public class SortModel
{
    public SortType SortType { get; set; }
    public string PropertyName { get; set; }
}

public enum SortType
{
    Asc,
    Desc
}