namespace IsMakinesiKiraHesap;

/// <summary>Konsoldan doğrulanmış girdi okur; hatalı girişte soruyu tekrarlar.</summary>
internal static class GirdiOkuyucu
{
    /// <summary>Verilen aralıkta (sınırlar dahil) bir tam sayı okur.</summary>
    public static int SayiOku(string soru, int enAz, int enCok)
    {
        // TODO: Girdi akışı kapanırsa (Ctrl+Z) döngü sonsuz döner
        while (true)
        {
            Console.Write(soru);
            string? giris = Console.ReadLine();

            if (int.TryParse(giris, out int sayi) && sayi >= enAz && sayi <= enCok)
            {
                return sayi;
            }

            Console.WriteLine($"Lütfen {enAz} ile {enCok} arasında bir tam sayı girin.");
        }
    }

    /// <summary>E/H cevabı okur; E için true, H için false döner.</summary>
    public static bool EvetHayirOku(string soru)
    {
        while (true)
        {
            Console.Write(soru);
            string giris = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (giris == "E")
            {
                return true;
            }

            if (giris == "H")
            {
                return false;
            }

            Console.WriteLine("Lütfen E ya da H girin.");
        }
    }
}