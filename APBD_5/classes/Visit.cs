using System;

namespace Api_APBD05.APBD_05.APBD_5.classes;

public class Visit(DateTime visitDate, AnimalInfo? animal, string visitInfo, double visitPrice)
{
    public DateTime VisitDate { get; set; } = visitDate;
    public AnimalInfo? Animal { get; set; } = animal;
    public string VisitInfo { get; set; } = visitInfo;
    public double VisitPrice { get; set; } = visitPrice;
}