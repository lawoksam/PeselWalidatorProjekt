// See https://aka.ms/new-console-template for more information
PeselWalidator_ peselWalidator = new PeselWalidator_(new int[] {1,2,3,4,5,6,7,8,9,1,0});
Console.WriteLine(peselWalidator.Plec());
peselWalidator.WczytajPesel("91072404614");
Console.WriteLine(peselWalidator.DataUrodzenia());

public class PeselWalidator_
{
    protected int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
    public int[] pesel = new int[11];

    public PeselWalidator_() { pesel = new int[11]; }
    public PeselWalidator_(int[] pesel)
    {
        this.pesel = pesel;
    }

    public void PESELWalidator(string pesel)
    {
        WczytajPesel(pesel);
    }

    public void WczytajPesel(string pesel)
    {
        for (int i = 0; i < 11; i++)
        {
            this.pesel[i] = Convert.ToInt32(pesel.Substring(i, 1));
        }

    }


    public int SumaKontrolna()
    {
        return 1 * pesel[0] + 3 * pesel[1] + 7 * pesel[2] + 9 * pesel[3] + 1 * pesel[4] + 3 * pesel[5]
        + 7 * pesel[6] + 9 * pesel[7] + 1 * pesel[8] + 3 * pesel[9];
    }

    public String DataUrodzenia()
    {
        switch (pesel[2])
        {
        case <2: return $"{pesel[4]}{pesel[5]}/{pesel[2]}{pesel[3]}/19{pesel[0]}{pesel[1]}";
        case >=2: return $"{pesel[4]}{pesel[5]}/{pesel[2]-2}{pesel[3]}/20{pesel[0]}{pesel[1]}";
        }
    }

    public String Plec()
    {
        return pesel[9] % 2 == 0 ? "Kobieta" : "Mężczyzna";
    }

    public Boolean SprawdzPesel()
    {
        if (10 - SumaKontrolna() % 10 == pesel[10])
        { return true; }
        else
            return false;
    }
}