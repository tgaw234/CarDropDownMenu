using CarDropDownMenu.Models;

public class CarMake
{
    public int Id { get; set; }
    public string MakeName { get; set; }
    public int CarBrandId { get; set; }

    // Navigation property for many-to-many relationship
    public ICollection<CarBrandCarMakeMatrix> CarBrandCarMakeMatrix { get; set; }
}
