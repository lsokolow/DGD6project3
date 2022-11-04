using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Example
{
    public string Name;
    public string DisplayName;

    public string IconString;
    

    //public int HP;
    public ClothingStyle Style;
    public ClothingType Type;
    //public AccessoryType AType;
    public List<string> CSpriteString = new List<string>();

    public Sprite IconSprite;
    public List<Sprite> ClothingSprites = new List<Sprite>();

    public Sprite[] SpriteSheet;

    public Clothing C;
    public PageManager PM;


    public Example(string n, string dn, string a, string sheet, ClothingStyle cs, ClothingType ct)
    {
        
        Name = n;
        DisplayName = dn;
        IconString = a;
        //HP = hp;
        Style = cs;
        Type = ct;
        SpriteSheet = Resources.LoadAll<Sprite>(sheet);

        
    }

    //public Example SetAType(AccessoryType a)
   // {
    //    AType = a;
    //    return this;
   // }

    public Example AddCSprites(string s)
    {
        CSpriteString.Add(s);
        return this;
    }

    public Example SetDicts(ClothingType ct)
    {
        //C = God.Lib.Typedict[ct];
        //PM = God.Menus.PageDict[ct];
        return this;
    }

    public Example LoadSprites()
    {

        IconSprite = SpriteSheet.Single(s => s.name == IconString);

        foreach (string cs in CSpriteString)
        {
            ClothingSprites.Add(SpriteSheet.Single(s => s.name == cs));
        }
        return this;
    }

}

public static class ExampleBuilder
{
    public static List<Example> Examples = new List<Example>();
    public static List<Example> HairItems = new List<Example>();
    public static List<Example> HatItems = new List<Example>();
    public static List<Example> DressItems = new List<Example>();
    public static List<Example> TopItems = new List<Example>();
    public static List<Example> BottomItems = new List<Example>();
    public static List<Example> SockItems = new List<Example>();
    public static List<Example> ShoeItems = new List<Example>();
    public static List<Example> LeftHoldItems = new List<Example>();
    public static List<Example> RightHoldItems = new List<Example>();
    public static List<Example> BraceletItems = new List<Example>();
    public static List<Example> NecklaceItems = new List<Example>();
    public static List<Example> LegAccessoryItems = new List<Example>();
    public static List<Example> EarringItems = new List<Example>();

    public static Dictionary<ClothingType, List<Example>> CTExamples = new Dictionary<ClothingType, List<Example>>();

    public static List<Example> GetClothes(ClothingType type)
    {
        return CTExamples[type];
    }

    public static void Add(Example e)
    {
        Examples.Add(e);
        if (!CTExamples.ContainsKey(e.Type)) CTExamples.Add(e.Type, new List<Example>());
        CTExamples[e.Type].Add(e);
    }

    public static void Setup()
    {
        Add(new Example("ffm_hair", "Twined Wind", "ffm_hair_icon", "Sprites/outfits/flower_fairy_mevilla/ln_flower_fairy_mevilla1", ClothingStyle.Elegant, ClothingType.Hair)
        .AddCSprites("ffm_hair1").AddCSprites("ffm_hair3").LoadSprites().SetDicts(ClothingType.Hair));

        HairItems.Add(new Example("ks_hair", "Cute Kitty Ear", "ks_hair_icon", "Sprites/outfits/kitten_sketchbook/LN_kitten_sketchbook2", ClothingStyle.Cute, ClothingType.Hair)
        .AddCSprites("ks_hair").LoadSprites().SetDicts(ClothingType.Hair));

        HairItems.Add(new Example("rs_hair", "Cupcake", "rs_hair_icon", "Sprites/outfits/rabbit_sweet/ln_rabbit_sweet1", ClothingStyle.Sweet, ClothingType.Hair)
        .AddCSprites("rs_hair1").LoadSprites().SetDicts(ClothingType.Hair));

        HairItems.Add(new Example("ci_hair", "Melting Maple Syrup", "ci_hair_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Hair)
        .AddCSprites("ci_hair").LoadSprites().SetDicts(ClothingType.Hair));

        HatItems.Add(new Example("ci_hat", "Demon Bunny - Mint", "ci_hat_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Hat)
        .AddCSprites("ci_hat").LoadSprites().SetDicts(ClothingType.Hat));

        HatItems.Add(new Example("rs_headband", "Polka Bunny Ears", "rs_headband_icon", "Sprites/outfits/rabbit_sweet/ln_rabbit_sweet1", ClothingStyle.Sweet, ClothingType.Hat)
        .AddCSprites("rs_headband").LoadSprites().SetDicts(ClothingType.Hat));

        DressItems.Add(new Example("ffm_dress", "Free Blossom", "ffm_dress_icon", "Sprites/outfits/flower_fairy_mevilla/ln_flower_fairy_mevilla1", ClothingStyle.Elegant, ClothingType.Dress)
        .AddCSprites("ffm_dress").LoadSprites().SetDicts(ClothingType.Dress));

        DressItems.Add(new Example("ks_main", "Kitten Sketchbook", "ks_main_icon", "Sprites/outfits/kitten_sketchbook/LN_kitten_sketchbook2", ClothingStyle.Cute, ClothingType.Dress)
        .AddCSprites("ks_main").LoadSprites().SetDicts(ClothingType.Dress));

        DressItems.Add(new Example("rs_dress", "White Clouds Poem", "rs_dress_icon", "Sprites/outfits/rabbit_sweet/ln_rabbit_sweet1", ClothingStyle.Sweet, ClothingType.Dress)
        .AddCSprites("rs_dress").AddCSprites("rs_sleeve").LoadSprites().SetDicts(ClothingType.Dress));

        TopItems.Add(new Example("ci_shirt", "Strapless Sweater - Black", "ci_shirt_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Top)
        .AddCSprites("ci_shirt").AddCSprites("ci_sleeve").LoadSprites().SetDicts(ClothingType.Top));

        BottomItems.Add(new Example("ci_skirt", "Roaming the Street - Mint", "ci_skirt_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Bottom)
        .AddCSprites("ci_skirt").LoadSprites().SetDicts(ClothingType.Bottom));

        ShoeItems.Add(new Example("ffm_shoes", "In Silence", "ffm_shoes_icon", "Sprites/outfits/flower_fairy_mevilla/ln_flower_fairy_mevilla1", ClothingStyle.Elegant, ClothingType.Shoes)
        .AddCSprites("ffm_shoe1").AddCSprites("ffm_shoe2").LoadSprites().SetDicts(ClothingType.Shoes));

        BraceletItems.Add(new Example("ffm_bracelet", "Viola Tricolor", "ffm_bracelet_icon", "Sprites/outfits/flower_fairy_mevilla/ln_flower_fairy_mevilla1", ClothingStyle.Elegant, ClothingType.Bracelet)
        .AddCSprites("ffm_bracelet").LoadSprites().SetDicts(ClothingType.Bracelet));

        

        SockItems.Add(new Example("ks_socks", "Kitten Talk", "ks_socks_icon", "Sprites/outfits/kitten_sketchbook/LN_kitten_sketchbook2", ClothingStyle.Cute, ClothingType.Socks)
        .AddCSprites("ks_sock1").AddCSprites("ks_sock2").LoadSprites().SetDicts(ClothingType.Socks));

        ShoeItems.Add(new Example("ks_shoes", "Cute High-Top Flats", "ks_shoes_icon", "Sprites/outfits/kitten_sketchbook/LN_kitten_sketchbook2", ClothingStyle.Cute, ClothingType.Shoes)
        .AddCSprites("ks_shoe1").AddCSprites("ks_shoe2").LoadSprites().SetDicts(ClothingType.Shoes));

        LeftHoldItems.Add(new Example("ks_bag", "Cute Kitten Bag", "ks_bag_icon", "Sprites/outfits/kitten_sketchbook/LN_kitten_sketchbook2", ClothingStyle.Cute, ClothingType.LeftHold)
        .AddCSprites("ks_bag1").LoadSprites().SetDicts(ClothingType.LeftHold));

        

        

        SockItems.Add(new Example("rs_socks", "Frosting Cream", "rs_socks_icon", "Sprites/outfits/rabbit_sweet/ln_rabbit_sweet1", ClothingStyle.Sweet, ClothingType.Socks)
        .AddCSprites("rs_sock1").AddCSprites("rs_sock2").LoadSprites().SetDicts(ClothingType.Socks));

        ShoeItems.Add(new Example("rs_shoes", "Rabbit Dance", "rs_shoes_icon", "Sprites/outfits/rabbit_sweet/ln_rabbit_sweet1", ClothingStyle.Sweet, ClothingType.Shoes)
        .AddCSprites("rs_shoe1").AddCSprites("rs_shoe2").LoadSprites().SetDicts(ClothingType.Shoes));

        

        

        

        

        SockItems.Add(new Example("ci_socks", "Zebra Crossing - Mint", "ci_socks_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Socks)
        .AddCSprites("ci_sock1").AddCSprites("ci_sock2").LoadSprites().SetDicts(ClothingType.Socks));

        ShoeItems.Add(new Example("ci_shoes", "High Platform Shoes - Mint", "ci_shoes_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Shoes)
        .AddCSprites("ci_shoe1").AddCSprites("ci_shoe2").LoadSprites().SetDicts(ClothingType.Shoes));

        LeftHoldItems.Add(new Example("ci_bunny", "Voodoo Bunny - White", "ci_bunny_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.LeftHold)
        .AddCSprites("ci_bunny").LoadSprites().SetDicts(ClothingType.LeftHold));

        RightHoldItems.Add(new Example("ci_phone", "Assembly Technology - Lemon", "ci_phone_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.RightHold)
        .AddCSprites("ci_phone").LoadSprites().SetDicts(ClothingType.RightHold));

        NecklaceItems.Add(new Example("ci_necklace", "Cross Tie - Mint", "ci_necklace_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Necklace)
        .AddCSprites("ci_necklace").LoadSprites().SetDicts(ClothingType.Necklace));

        LegAccessoryItems.Add(new Example("ci_legwarmers", "Loose Socks - Cross", "ci_legwarmers_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.LegAccessory)
        .AddCSprites("ci_legwarmer1").AddCSprites("ci_legwarmer2").LoadSprites().SetDicts(ClothingType.LegAccessory));

        BraceletItems.Add(new Example("ci_bracelets", "Fluorescent Bracelets", "ci_bracelets_icon", "Sprites/outfits/cunning_imp/ln_cunning_imp2", ClothingStyle.Cool, ClothingType.Bracelet)
        .AddCSprites("ci_bracelet1").AddCSprites("ci_bracelet2").LoadSprites().SetDicts(ClothingType.Bracelet));
    }
}