

public class Possum
{
    public string name;
    private string scientificName = "Didelphis Virginiana";
    private int lifespan = 4;
}

public class PossumAlert
{
    public delegate void Alert(object source, EventArgs args);

    public event Alert AlertPossum;

    public void PossumAppearance(Possum possum)
    {
        Console.WriteLine($"{possum.name}, the possum has appeared!");
        Thread.Sleep(3000);
        PossumDisappearance(possum);

    }

    protected virtual void PossumDisappearance(Possum possum)
    {
        if (AlertPossum != null)
            AlertPossum(this, null);
    }
 }

public class PossumWatch
{
    public void PossumDisappearance(object source, EventArgs eventArgs)
    {
        Console.WriteLine("the possum has disappeared!");
    }
}




class Program
{
    static void Main(string [] args)
    {
        var possumName = "Greg";
        var greg = new Possum { name = possumName };
        var possumAlert = new PossumAlert();
        var possumWatch = new PossumWatch();
        possumAlert.AlertPossum += possumWatch.PossumDisappearance;
        possumAlert.PossumAppearance(greg);
        Console.ReadKey();
    }
}