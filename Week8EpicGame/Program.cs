string folderPath = "C:\\Users\\Asus\\OneDrive - Tallinna Tehnikakõrgkool\\1) TKTK Kõik materjalid\\2. semester\\Programmeerimise Algkursus\\data\\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
//string[] heroes = { "Harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };
//string[] villains = { "Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron" };



string[] weapon = {"magic wand", "plastic fork", "sword", "lego brick" };

string hero = GetRandomValueFromArray(heroes);
string herowWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStenght = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {herowWeapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrenght = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}2709
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rand = new Random();
    int randomIndex = rand.Next( someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName ,int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    
    return strike;
}