namespace MotorcycleAdventures.Core.Models
{
    public interface INameAndId
    {
        int Id { get; set; }
        string Name { get; set; }
        string ToString();
    }
}