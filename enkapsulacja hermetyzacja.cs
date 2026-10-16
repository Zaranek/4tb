Licznik gracz = new Licznik();
Console.WriteLine($"NA poczatku : {gracz.PobierzPunkty()}");
gracz.DodajPunkty(50);
Console.WriteLine($"Po dodaniu 50 : {gracz.PobierzPunkty()}");
gracz.DodajPunkty(-200);
Console.WriteLine($"Po próbie dodania -200 : {gracz.PobierzPunkty()}");
//fragment poniżej który bedzie powodował błąd ze względu na hermetyzację
//gracz.PokazPunkty = -200;
//private blokuje bezpośrednie przypisanie gracz.punkty = -200 poza klasą
// PobierzPunkty() pozwala odczytać aktualny stan pola. niczego nie zmienia.
class Licznik
{
    private int punkty = 0;
    public void DodajPunkty(int ile)
    {
        if(ile>0)
        {
            punkty += ile;
        }
    }
    public void PokazPunkty()
    {
        Console.WriteLine(punkty);
    }
    public void Wyzeruj()
    {
        punkty= 0;
    }
    public int PobierzPunkty()
    {
        return punkty;
    }
}
