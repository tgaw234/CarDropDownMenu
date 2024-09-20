namespace CarDropDownMenu.Models
{
    public class CarMake
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public int CarBrandId { get; set; }

        public CarBrand CarBrand { get; set; }
        public object Brand { get; internal set; }
    }
}
