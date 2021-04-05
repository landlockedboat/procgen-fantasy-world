using System.Globalization;
using UnityEngine;

public static class CountryNameGenerationController
{
    private static readonly string[] Nm1 =
    {
        "b", "c", "d", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z",
        "", "", "", "", ""
    };

    private static readonly string[] Nm2 = {"a", "e", "o", "u"};

    private static readonly string[] Nm3 =
    {
        "br", "cr", "dr", "fr", "gr", "pr", "str", "tr", "bl", "cl", "fl", "gl", "pl", "sh", "sc", "sk", "sm", "sn",
        "sp", "st", "sw", "ch", "sh", "th", "wh"
    };

    private static readonly string[] Nm4 =
    {
        "ae", "ai", "ao", "au", "a", "ay", "ea", "ei", "eo", "eu", "e", "ey", "ua", "ue", "ui", "uo", "u", "uy",
        "ia", "ie", "iu", "io", "iy", "oa", "oe", "ou", "oi", "o", "oy"
    };

    private static readonly string[] Nm5 =
    {
        "stan", "dor", "vania", "nia", "lor", "cor", "dal", "bar", "sal", "ra", "la", "lia", "jan", "rus", "ze",
        "tan", "wana", "sil", "so", "na", "le", "bia", "ca", "ji", "ce", "ton", "ssau", "sau", "sia", "ca", "ya", "ye",
        "yae", "tho", "stein", "ria", "nia", "burg", "nia", "gro", "que", "gua", "qua", "rhiel", "cia", "les", "dan",
        "nga",
        "land"
    };

    private static readonly string[] Nm6 =
    {
        "ia", "a", "en", "ar", "istan", "aria", "ington", "ua", "ijan", "ain", "ium", "us", "esh", "os", "ana",
        "il", "ad", "or", "ea", "eau", "ax", "on", "ana", "ary", "ya", "ye", "yae", "ait", "ein", "urg", "al", "ines",
        "ela"
    };

    private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

    public static string GetRandomCountryName()
    {
        var nameType = Random.Range(0, 5);
        var retName = nameType switch
        {
            0 => string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm1, Nm2, Nm3, Nm4, Nm5)),
            1 => string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm1, Nm2, Nm3, Nm4, Nm6)),
            2 => string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm3, Nm4, Nm5)),
            3 => string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm2, Nm3, Nm6)),
            4 => string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm3, Nm4, Nm1)) + " " +
                 string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Nm3, Nm6)),
            _ => ""
        };

        return TextInfo.ToTitleCase(retName);
    }
}