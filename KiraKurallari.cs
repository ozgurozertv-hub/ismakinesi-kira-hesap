namespace IsMakinesiKiraHesap;

/// <summary>Kira hesabının sabit kurallarını tek yerde tutar.</summary>
internal static class KiraKurallari
{
    /// <summary>Menü numarasından makine adına eşleme.</summary>
    public static readonly Dictionary<int, string> MakineAdlari = new()
    {
        [1] = "Mini ekskavatör",
        [2] = "Kazıcı yükleyici",
        [3] = "Paletli ekskavatör"
    };

    /// <summary>Makine adına göre günlük kira ücreti (TL).</summary>
    public static readonly Dictionary<string, decimal> GunlukUcretler = new()
    {
        ["Mini ekskavatör"] = 1000m,
        ["Kazıcı yükleyici"] = 1500m,
        ["Paletli ekskavatör"] = 3000m
    };

    /// <summary>Menü numarasından sezon adına eşleme.</summary>
    public static readonly Dictionary<int, string> SezonAdlari = new()
    {
        [1] = "Kış",
        [2] = "Bahar-Güz",
        [3] = "Yaz"
    };

    /// <summary>Sezona göre ücret katsayısı.</summary>
    // İş kuralı: kışın şantiye talebi düşer, yaz inşaat sezonunun zirvesidir
    public static readonly Dictionary<string, decimal> SezonKatsayilari = new()
    {
        ["Kış"] = 0.8m,
        ["Bahar-Güz"] = 1.0m,
        ["Yaz"] = 1.3m
    };

    /// <summary>Kiralanabilecek en az gün.</summary>
    public const int EnAzGun = 1;

    /// <summary>Kiralanabilecek en çok gün.</summary>
    public const int EnCokGun = 30;
}