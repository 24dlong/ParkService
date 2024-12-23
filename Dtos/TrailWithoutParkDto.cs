namespace ParkService.Dtos;

public class TrailWithoutParkDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    // miles
    public required double Length { get; set; }
}
