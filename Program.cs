using System.Security.Cryptography.X509Certificates;

class Postac
{
    public string nazwa = "";
    public int zdrowie;
    public int atak;

    public Postac(string nowaNazwa, int noweZdrowie, int nowyAtak)
    {
        nazwa= nowaNazwa;
        zdrowie= noweZdrowie;
        atak=nowyAtak;
    }
    public  void PokazStatystyki()
    {
        Console.WriteLine($"{nazwa} zdrowie {zdrowie}, punkty ataku {atak}");
    }

    public void OtrzymajObrazenia(int ile)
    {
        zdrowie -= ile;
        if (zdrowie < 0)
        {
            zdrowie = 0;
        }
    }
    public void Uleczenie (int ile)
    {
        zdrowie += ile;
    }
    public void Atakuj(Postac przeciwnik)
    {
        Console.WriteLine($"{nazwa} atakuje {przeciwnik.nazwa} i zadaje {atak} obrażeń ");
        przeciwnik.OtrzymajObrazenia(atak);
    }
}
class Program
{
    static void Main()
    {
        Postac rycerz=new Postac("Rycerz",100,20);
        Postac mag = new Postac("Mag",70,35);
        Postac lucznik = new Postac("Łucznik", 80, 25);

        Console.Write("Podaj nazwe postaci");
        string wybranaNazwa=Console.ReadLine() ?? "";
        Console.Write("Podaj zdrowie");
        int wybraneZdrowie = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Podaj atak");
        int wybranyAtak = int.Parse(Console.ReadLine() ?? "0");

        Postac gracz = new Postac(wybranaNazwa, wybraneZdrowie, wybranyAtak);
        gracz.PokazStatystyki();

        rycerz.PokazStatystyki();
        mag.PokazStatystyki();
        rycerz.Atakuj(mag);
        mag.Atakuj(rycerz);
        mag.PokazStatystyki();
        rycerz.PokazStatystyki();
       
    }
}