using System.Security.Cryptography.X509Certificates;

string heroName = "Ada";
int health = 70;
int maxHealth = 100;
int gold = 15;
int strength = 6;
int weaponDamage = 3;
bool isRunning = true;

List<string> inventory = new List<string> { "miecz", "mikstura", "łuk" };

List<string> longNames = inventory.FindAll(item => item.Length >= 5);
bool hasSword = inventory.Exists(item => item == "miecz");

void ShowMessage(string text) { Console.WriteLine(text); }
int AddGold(int gold, int reward) => gold + reward;
bool HasEnoughGold(int gold, int price) => gold >= price;

int CalculateDamage(int strength, int weaponDamage) => strength + weaponDamage;
int Heal(int health, int amount, int maxHealth) => health + amount >= maxHealth ? maxHealth : health + amount;
bool IsGameOver(int health) => health <= 0;


void ShowStatus(string name, int health, int maxHealth, int gold) {
    Console.WriteLine($"Imie: {name}");
    Console.WriteLine($"Zdrowie: {health}/{maxHealth}");
    Console.WriteLine($"Złoto: {gold}");
}
void ShowMenu() {
    Console.WriteLine("1. Atak treningowy");
    Console.WriteLine("2. Odpoczynek");
    Console.WriteLine("3. Koniec gry");
}

void ShowPanelTitle(string title, ConsoleColor backgroundColor) {
    Console.BackgroundColor = backgroundColor;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"========= {title} =========");
    Console.ResetColor();
}

string ReadCommand()
{
    while (true)
    {
        Console.Write("Wybór: ");
        string? command = Console.ReadLine();

        if (command == "1" || command == "2" || command == "3") {
            return command;
        } else {
            Console.WriteLine("Zła wartość");
        }
    }
}

Console.ForegroundColor = ConsoleColor.White;

while (isRunning)
{
    if (IsGameOver(health)) { 
        Console.WriteLine("Koniec gry"); 
        isRunning=false; 
        break; 
    }
    
    ShowStatus(heroName, health, maxHealth, gold);
    ShowMenu();
    string command = ReadCommand();

    if (command == "1")
    {
        int damage = CalculateDamage(strength, weaponDamage);
        Console.WriteLine($"Zadajesz {damage} obrażeń manekinowi.");
    }
    else if (command == "2")
    {
        health = Heal(health, 10 , maxHealth);
        Console.WriteLine($"Odpoczywasz. Masz teraz {health} HP.");
    }
    else if (command == "3")
    {
        isRunning = false;
    }
}

// 1 ZADANIA
// 1.1: Metoda ShowMessage
// 1.2: Bool
// 1.3: gold i reward
// 1.4: W pętli while lub ifie