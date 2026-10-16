using System;

// TWORZENIE POSTACI
// Kolejność: nazwa, zdrowie, atak, poziom.

Postac rycerz = new Postac("Rycerz", 100, 20, 5);
Postac mag = new Postac("Mag", 70, 35, 3);
Postac lucznik = new Postac("Łucznik", 80, 25, 1);

Console.WriteLine("POSTACIE NA POCZĄTKU GRY:");

rycerz.PokazStatystyki();
mag.PokazStatystyki();
lucznik.PokazStatystyki();


// OBRAŻENIA I LECZENIE

Console.WriteLine("\nŁUCZNIK OTRZYMUJE OBRAŻENIA I LECZY SIĘ:");

lucznik.OtrzymajObrazenia(30);
lucznik.Ulecz(10);
lucznik.PokazStatystyki();


// AWANSOWANIE

Console.WriteLine("\nŁUCZNIK AWANSUJE DWA RAZY:");

lucznik.Awansuj();
lucznik.Awansuj();
lucznik.PokazStatystyki();


// TWORZENIE POSTACI Z DANYCH UŻYTKOWNIKA
// Zakładamy wpisywanie poprawnych liczb całkowitych.

Console.Write("\nPodaj nazwę swojej postaci: ");
string wybranaNazwa = Console.ReadLine() ?? "";

Console.Write("Podaj zdrowie: ");
int wybraneZdrowie = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Podaj atak: ");
int wybranyAtak = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Podaj poziom: ");
int wybranyPoziom = int.Parse(Console.ReadLine() ?? "0");

Postac gracz = new Postac(
    wybranaNazwa,
    wybraneZdrowie,
    wybranyAtak,
    wybranyPoziom
);

gracz.PokazStatystyki();


// SPRAWDZENIE KONTROLI DANYCH W KONSTRUKTORZE

Console.WriteLine("\nPOSTAĆ UTWORZONA Z NIEPRAWIDŁOWYMI DANYMI:");

Postac potwor = new Postac("Potwór", -50, 0, -2);
potwor.PokazStatystyki();


// POJEDYNCZE ATAKI

Console.WriteLine("\nPOJEDYNCZE ATAKI:");

rycerz.Atakuj(mag);
mag.Atakuj(rycerz);
rycerz.Atakuj(mag);

rycerz.PokazStatystyki();
mag.PokazStatystyki();


// AUTOMATYCZNA WALKA
// Przywracamy zdrowie przed rozpoczęciem nowego pojedynku.

rycerz.zdrowie = 100;
mag.zdrowie = 70;

Console.WriteLine("\nAUTOMATYCZNA WALKA:");

while (rycerz.zdrowie > 0 && mag.zdrowie > 0)
{
    rycerz.Atakuj(mag);

    // Pokonany mag nie może odpowiedzieć atakiem.
    if (mag.zdrowie > 0)
    {
        mag.Atakuj(rycerz);
    }

    rycerz.PokazStatystyki();
    mag.PokazStatystyki();

    Console.WriteLine();
}

if (rycerz.zdrowie > 0)
{
    Console.WriteLine($"Wygrywa {rycerz.nazwa}!");
}
else
{
    Console.WriteLine($"Wygrywa {mag.nazwa}!");
}


// DEFINICJA KLASY

class Postac
{
    // POLA — dane każdego obiektu.

    public string nazwa;
    public int zdrowie;
    public int atak;
    public int poziom;


    // KONSTRUKTOR — ustawia dane podczas tworzenia obiektu.

    public Postac(
        string nowaNazwa,
        int noweZdrowie,
        int nowyAtak,
        int nowyPoziom)
    {
        nazwa = nowaNazwa;

        zdrowie = noweZdrowie;
        if (zdrowie < 1)
        {
            zdrowie = 1;
        }

        atak = nowyAtak;
        if (atak < 1)
        {
            atak = 1;
        }

        poziom = nowyPoziom;
        if (poziom < 1)
        {
            poziom = 1;
        }
    }


    // METODY — czynności wykonywane przez obiekty.

    public void PokazStatystyki()
    {
        Console.WriteLine(
            $"{nazwa}: zdrowie {zdrowie}, atak {atak}, poziom {poziom}"
        );
    }

    public void OtrzymajObrazenia(int ile)
    {
        zdrowie -= ile;

        if (zdrowie < 0)
        {
            zdrowie = 0;
        }
    }

    public void Ulecz(int ile)
    {
        zdrowie += ile;
    }

    public void Atakuj(Postac przeciwnik)
    {
        Console.WriteLine(
            $"{nazwa} atakuje {przeciwnik.nazwa} i zadaje {atak} obrażeń."
        );

        przeciwnik.OtrzymajObrazenia(atak);
    }

    public void Awansuj()
    {
        poziom += 1;
        zdrowie += 10;
        atak += 2;
    }
}