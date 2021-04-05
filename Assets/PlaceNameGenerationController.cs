using System.Globalization;

public static class PlaceNameGenerationController
{
    private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

    private static readonly string[] Prefixes =
    {
        "Épi", "Auri", "Avi", "Angou", "Anti", "Anto", "Or", "Alen", "Argen", "Auber", "Bel", "Besan", "Bor", "Bour",
        "Cam", "Char", "Cler", "Col", "Cour", "Mar", "Mont", "Nan", "Nar", "Sar", "Valen", "Vier", "Villeur", "Vin",
        "Ba", "Bé", "Beau", "Berge", "Bou", "Ca", "Carca", "Cha", "Champi", "Cho", "Cla", "Colo", "Di", "Dra", "Dragui",
        "Fré", "Genne", "Go", "Gre", "Hague", "Houi", "Leva", "Li", "Mai", "Mari", "Marti", "Mau", "Montau", "Péri",
        "Pa", "Perpi", "Plai", "Poi", "Pu", "Roa", "Rou", "Sau", "Soi", "Ta", "Tou", "Va", "Vitro"
    };

    private static readonly string[] Suffixes =
    {
        "gnan", "gnane", "gneux", "llac", "lles", "lliers", "llon", "lly", "nne", "nnet", "nnois", "ppe", "ppes",
        "ssion", "ssis", "ssonne", "ssons", "ssy", "thune", "çon", "béliard", "bagne", "beuge", "bonne", "ciennes",
        "court", "fort", "gny", "gues", "gueux", "lès", "lême", "let", "limar", "logne", "lon", "luçon", "luire", "lun",
        "mans", "mart", "masse", "miers", "momble", "mont", "mur", "nau", "nesse", "nin", "noît", "rac", "rgues",
        "rault", "ris", "roux", "sart", "seau", "sier", "sir", "teaux", "toise", "tou", "veil", "vers", "ves", "ville",
        "vin", "yonne", "zieu", "zon"
    };

    public static string GetRandomPlaceName()
    {
        return TextInfo.ToTitleCase(string.Concat(EnumerableUtils.GetRandomElementFromEachArray(Prefixes, Suffixes)));
    }
}