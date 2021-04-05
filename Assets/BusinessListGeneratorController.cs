using System.Collections.Generic;
using UnityEngine;

public static class BusinessListGeneratorController
{
    private static readonly List<BusinessByServiceValue> BusinessesByServiceValue = new List<BusinessByServiceValue>
    {
        new BusinessByServiceValue("Clergy", 40),
        new BusinessByServiceValue("Shoemaker", 150),
        new BusinessByServiceValue("Law Enforcement", 150),
        new BusinessByServiceValue("Noble", 200),
        new BusinessByServiceValue("Furrier", 250),
        new BusinessByServiceValue("Tailor", 250),
        new BusinessByServiceValue("Barber", 350),
        new BusinessByServiceValue("Jeweler", 400),
        new BusinessByServiceValue("Tavern", 400),
        new BusinessByServiceValue("Place Of Worship", 500),
        new BusinessByServiceValue("Pastry", 500),
        new BusinessByServiceValue("Mason", 500),
        new BusinessByServiceValue("Carpenter", 550),
        new BusinessByServiceValue("Weaver", 600),
        new BusinessByServiceValue("Administrator", 650),
        new BusinessByServiceValue("Chandler", 700),
        new BusinessByServiceValue("Mercer", 700),
        new BusinessByServiceValue("Cooper", 700),
        new BusinessByServiceValue("Baker", 800),
        new BusinessByServiceValue("Scabbard Maker", 500),
        new BusinessByServiceValue("Wine Seller", 900),
        new BusinessByServiceValue("Hat Maker", 950),
        new BusinessByServiceValue("Saddler", 1_000),
        new BusinessByServiceValue("Priest", 1000),
        new BusinessByServiceValue("Chicken Butcher", 1_000),
        new BusinessByServiceValue("Purse Maker", 1_100),
        new BusinessByServiceValue("Butcher", 1_200),
        new BusinessByServiceValue("Fishmonger", 1_200),
        new BusinessByServiceValue("Beer Seller", 1_400),
        new BusinessByServiceValue("Buckle Maker", 1_400),
        new BusinessByServiceValue("Plasterer", 1_400),
        new BusinessByServiceValue("Spice Merchant", 1_400),
        new BusinessByServiceValue("Blacksmith", 1_500),
        new BusinessByServiceValue("Painter", 1_500),
        new BusinessByServiceValue("Doctor", 1_700),
        new BusinessByServiceValue("Roofer", 1_800),
        new BusinessByServiceValue("Locksmith", 1_900),
        new BusinessByServiceValue("Bather", 1_900),
        new BusinessByServiceValue("Rope Maker", 1_900),
        new BusinessByServiceValue("Inn", 2_000),
        new BusinessByServiceValue("Tanner", 2_000),
        new BusinessByServiceValue("Copyists", 2_000),
        new BusinessByServiceValue("Sculptor", 2_000),
        new BusinessByServiceValue("Rug Maker", 2_000),
        new BusinessByServiceValue("Harness Maker", 2_000),
        new BusinessByServiceValue("Bleachers", 2_100),
        new BusinessByServiceValue("Hay Merchant", 2_300),
        new BusinessByServiceValue("Cutler", 2_300),
        new BusinessByServiceValue("Glove Maker", 2_400),
        new BusinessByServiceValue("Wood Carver", 2_400),
        new BusinessByServiceValue("Wood Seller", 2_400),
        new BusinessByServiceValue("Magic Shop", 2_800),
        new BusinessByServiceValue("Bookbinders", 3_000),
        new BusinessByServiceValue("Illuminator", 3_900),
        new BusinessByServiceValue("Book Seller", 6_300)
    };

    public static List<Business> GetNumberOfBusinessFromSettlementPopulation(int population)
    {
        var businesses = new List<Business>();
        foreach (var businessByServiceValue in BusinessesByServiceValue)
        {
            if (population < businessByServiceValue.ServiceValue)
            {
                break;
            }

            var businessToAdd = new Business
            {
                name = businessByServiceValue.Type,
                amount = Mathf.FloorToInt(population / businessByServiceValue.ServiceValue)
            };
            businesses.Add(businessToAdd);
        }
        return businesses;
    }
}

/* ORIGINAL LIST
 * shoemakers 150
 * Furriers 250
 * Maidservants 250
 * Tailors 250
 * Barbers 350
 * Jewelers 400
 * Taverns/Restaurants 400
 * old-clothes 400 ?
 * Pastrycooks 500
 * Masons 500
 * carpenters 550
 * Weavers 600
 * chandlers 700
 * Mercers 700
 * coopers 700
 * Bakers 800
 * watercarriers 850 This is a job
 * scabbardmakers 850
 * wine-sellers 900
 * Hatmakers 950
 * saddlers 1,000
 * chicken Butchers 1,000
 * Pursemakers 1,100
 * woodsellers 2,400
 * Magic-shops 2,800
 * Bookbinders 3,000
 * Butchers 1,200
 * Fishmongers 1,200
 * Beer-sellers 1,400
 * Buckle Makers 1,400
 * Plasterers 1,400
 * spice Merchants 1,400
 * Blacksmiths 1,500
 * Painters 1,500
 * doctors* 1,700
 * Roofers 1,800
 * locksmiths 1,900
 * Bathers 1,900
 * Ropemakers 1,900
 * Inns 2,000
 * Tanners 2,000
 * copyists 2,000
 * sculptors 2,000
 * Rugmakers 2,000
 * Harness-Makers 2,000
 * Bleachers 2,100
 * Hay Merchants 2,300
 * cutlers 2,300
 * Glovemakers 2,400
 * woodcarvers 2,400
 * Booksellers 6,300
 * Illuminators 3,900
 * Place Of Worship 400
 *
 * OTHER JOBS / NOT BUSINESS
 * 
 * Law Enforcement 150
 * Noble 200
 * Administrator 650
 * Clergy 40
 * Priest 1000
 * 
 */