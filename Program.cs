using System.Globalization;
using System.Text;

namespace IsMakinesiKiraHesap;

/// <summary>Programın giriş noktası; kullanıcıyla etkileşimi yönetir.</summary>
internal class Program
{
    /// <summary>Tutarları Türkçe biçimde (9.750,00) yazmak için kültür bilgisi.</summary>
    private static readonly CultureInfo TrKultur = new("tr-TR");

    /// <summary>Programı başlatır; kullanıcı istediği sürece yeni hesap yapar.</summary>
    static void Main(string[] args)
    {
        // Neden: Türkçe karakterler konsolda bozuk görünmesin
        Console.OutputEncoding = Encoding.UTF8;

        // Neden do-while: ilk hesap sorulmadan yapılır, sonrakiler kullanıcıya bağlı
        do
        {
            TekHesapYap();
            Console.WriteLine();
        }
        while (GirdiOkuyucu.EvetHayirOku("Yeni hesap? (E/H): "));

        Console.WriteLine("İyi çalışmalar.");
    }

    /// <summary>Kullanıcıdan seçimleri alır, tek bir kira hesabı yapar ve sonucu yazar.</summary>
    static void TekHesapYap()
    {
        MenuYazdir("Makine sınıfı:", KiraKurallari.MakineAdlari);
        int makineNo = GirdiOkuyucu.SayiOku("Seçiminiz: ", 1, KiraKurallari.MakineAdlari.Count);
        string makineAdi = KiraKurallari.MakineAdlari[makineNo];
        decimal gunlukUcret = KiraKurallari.GunlukUcretler[makineAdi];

        int gun = GirdiOkuyucu.SayiOku(
            $"Gün sayısı ({KiraKurallari.EnAzGun}-{KiraKurallari.EnCokGun}): ",
            KiraKurallari.EnAzGun,
            KiraKurallari.EnCokGun);

        MenuYazdir("Sezon:", KiraKurallari.SezonAdlari);
        int sezonNo = GirdiOkuyucu.SayiOku("Seçiminiz: ", 1, KiraKurallari.SezonAdlari.Count);
        string sezonAdi = KiraKurallari.SezonAdlari[sezonNo];
        decimal katsayi = KiraKurallari.SezonKatsayilari[sezonAdi];

        decimal toplam = Hesapla(gunlukUcret, gun, katsayi);
        Console.WriteLine($"{makineAdi}, {gun} gün, {sezonAdi} → Toplam: {toplam.ToString("N2", TrKultur)} TL");
    }

    /// <summary>Başlığı ve sözlükteki seçenekleri numaralı liste olarak yazar.</summary>
    static void MenuYazdir(string baslik, Dictionary<int, string> secenekler)
    {
        Console.WriteLine(baslik);
        foreach (var secenek in secenekler)
        {
            Console.WriteLine($"  {secenek.Key}) {secenek.Value}");
        }
    }

    /// <summary>Kira ücretini hesaplar.</summary>
    // İş kuralı: toplam = günlük ücret × gün sayısı × sezon katsayısı
    static decimal Hesapla(decimal gunlukUcret, int gun, decimal katsayi)
    {
        return gunlukUcret * gun * katsayi;
    }
}