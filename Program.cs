using System;

namespace PR4
{
    // Интерфейс для заклинания
    public interface ISpell
    {
        int Mana { get; }
        string Effect { get; }
        string Name { get; }
        string Use();
    }

    // Класс со свойствами заклинания
    public class Spell : ISpell
    {
        // Инициализация свойств
        public int Mana { get; }
        public string Effect { get; }
        public string Name { get; }

        // Конструктор, принимающий значения заклинания
        public Spell(int mana, string effect, string name)
        {
            Mana = mana;
            Effect = effect;
            Name = name;
        }

        // Метод использования заклинания, вывод эффект от заклинания
        public string Use()
        {
            return Effect;
        }
    }

    // Интерфейс для мага
    public interface IMagician
    {
        string Name { get; }
        int Mana { get; }
        void CastSpell(ISpell spell);
    }

    // Класс со свойствами мага
    public class Magician : IMagician
    {
        // Свойства класса Маг
        public string Name { get; }
        public int Mana { get; private set; }

        // Конструктор, принимающий значения мага
        public Magician(string name, int mana)
        {
            Name = name;
            Mana = mana;
        }

        // Колдонуть с проверкой маны
        public void CastSpell(ISpell spell)
        {
            if (Mana >= spell.Mana)
            {
                Console.WriteLine($"{Name} колдует! {spell.Use()}");
                Mana -= spell.Mana;
            }
            else
            {
                Console.WriteLine($"Для использования \"{spell.Name}\" не хватает {spell.Mana - Mana} единиц маны");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов заклинаний
            ISpell rain = new Spell(60, "Идёт дождь!", "Дождь");
            ISpell sun = new Spell(41, "Солнце светит!", "Свет солнца");

            // Создание объекта Маг
            IMagician man = new Magician("Этот крутой мужчина", 100);

            // Использование заклинаний
            man.CastSpell(rain);
            man.CastSpell(sun);

            Console.ReadKey(true);
        }
    }
}