namespace ZooBackend;

public class Animal
{
  public string Species { get; set; } = default!;
  public string Name { get; set; } = default!;
  public double Weight { get; set; }

  public string Image => Species switch {
    "Lion" => Name != "Nala" 
      ? "https://images.pexels.com/photos/18111908/pexels-photo-18111908/free-photo-of-lion-at-the-zoo.jpeg" 
      : "https://images.pexels.com/photos/5837802/pexels-photo-5837802.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    "Tiger" => 
      "https://images.pexels.com/photos/951007/pexels-photo-951007.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    "Giraffe" => 
      "https://images.pexels.com/photos/797643/pexels-photo-797643.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    "Zebra" => 
      "https://images.pexels.com/photos/3250752/pexels-photo-3250752.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    "Wolf" => 
      "https://images.pexels.com/photos/162256/wolf-predator-european-wolf-carnivores-162256.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    "Piranha" => 
      "https://images.pexels.com/photos/13561545/pexels-photo-13561545.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
    _ => ""
  };
}