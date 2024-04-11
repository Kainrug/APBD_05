using System;

namespace Api_APBD05.APBD_05.APBD_5.classes;

public class AnimalInfo(int id, string name, AnimalCategory category, double mass, HairColor hairColor)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public AnimalCategory Category { get; set; } = category;
    public double Mass { get; set; } = mass;
    public HairColor HairHairColor { get; set; } = hairColor;
    
    
    public override bool Equals(object? obj)
    {
        if (obj is not AnimalInfo)
        {
            return false;
        }

        var otherAnimal = (AnimalInfo)obj;
        return Id == otherAnimal.Id && Name == otherAnimal.Name && Category == otherAnimal.Category &&
               HairHairColor == otherAnimal.HairHairColor && Math.Abs(Mass - otherAnimal.Mass) < 0.001;
    }
}