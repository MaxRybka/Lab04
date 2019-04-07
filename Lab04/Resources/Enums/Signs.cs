using System.ComponentModel;

namespace Lab04.Resources
{
    public enum ChineseSigns
    {
        [Description("Monkey")] Monkey = 1,
        [Description("Rooster")] Rooster,
        [Description("Dog")] Dog,
        [Description("Pig")] Pig,
        [Description("Rat")] Rat,
        [Description("Ram")] Ram,
        [Description("Tiger")] Tiger,
        [Description("Rabbit")] Rabbit,
        [Description("Dragon")] Dragon,
        [Description("Sneak")] Sneak,
        [Description("Horse")] Horse,
        [Description("Ox")] Ox

    }

    public enum SunSigns
    {
        [Description("Capricorn")] Capricorn,
        [Description("Aquarius")] Aquarius,
        [Description("Pisces")] Pisces,
        [Description("Aries")] Aries,
        [Description("Taurus")] Taurus,
        [Description("Gemini")] Gemini,
        [Description("Cancer")] Cancer,
        [Description("Leo")] Leo,
        [Description("Virgo")] Virgo,
        [Description("Libra")] Libra,
        [Description("Scorpio")] Scorpio,
        [Description("Sagittarius")] Sagittarius
    }
}
