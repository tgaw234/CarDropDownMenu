using CarDropDownMenu.Models;

public class CarBrand
{
    public int Id { get; set; }
    public string BrandName { get; set; }

    // Navigation property for many-to-many relationship
    public ICollection<CarBrandCarMakeMatrix> CarBrandCarMakeMatrix { get; set; }
}
