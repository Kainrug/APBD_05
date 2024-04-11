using System.Collections.Generic;
using Api_APBD05.APBD_05.APBD_5.classes;

namespace Api_APBD05.APBD_05.APBD_5.Interface;

public interface IMockDbVisit
{
    public ICollection<Visit?> GetByAnimal(AnimalInfo animalInfo);

    public void Add(Visit visit);
}