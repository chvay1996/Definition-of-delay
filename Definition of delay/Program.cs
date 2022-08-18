using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition_of_delay
{
    class Program
    {
        static void Main ( string [] args )
        {
            Database database = new Database ();
            database.Work ();
        }
    }

    class Database
    {
        private List<Soldier> _soldiers = new List<Soldier> ();

        public Database ()
        {
            _soldiers.Add ( new Soldier ( "Иван", "Lithgow L1A1", "Полковник", 36) );
            _soldiers.Add ( new Soldier ( "Роман", "Lithgow L1A1-F1", "Капитан", 22) );
            _soldiers.Add ( new Soldier ( "Владимир", "Lithgow L2A1", "Майор", 18) );
            _soldiers.Add ( new Soldier ( "Александр", "Lithgow MCEM", "Генерал майор", 30) );
            _soldiers.Add ( new Soldier ( "Алина", "F1 SMG", "Маршал россии", 56) );
        }

        public void Work ()
        {
            bool isWork = true;
            string input;

            while ( isWork == true )
            {
                Console.WriteLine ("1 - показать весь список военных." +
                    "\n2 - Показать сокращенный список." +
                    "\n3 - Выход");
                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        ShowListSoldier ();
                        break;
                    case "2":
                        ShowAnAbbreviatedList ();
                        break;
                    case "3":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ("Хмммм... Что-то пошло не так!");
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void ShowListSoldier ()
        {
            foreach ( var soldier in _soldiers )
            {
                soldier.ShowInfo ();
            }
        }

        private void ShowAnAbbreviatedList ()
        {
            Console.WriteLine ("\nПолный список военных\n");

            var abbreviatedInformationSoldiers = from Soldier soldier in _soldiers select new { name = soldier.Name, title = soldier.Title };

            foreach ( var soldier in abbreviatedInformationSoldiers )
            {
                Console.WriteLine ($"Имя {soldier.name} \tзвание {soldier.title}");
            }
        }
    }

    class Soldier
    {
        private string _armament;
        private byte _serviceLife;

        public Soldier( string name, string armament, string title, byte serviceLife )
        {
            _armament = armament;
            _serviceLife = serviceLife;
            Name = name;
            Title = title;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }

        public void ShowInfo ()
        {
            Console.WriteLine ($"Солдат {Name} \tвооружение {_armament} \tзвание {Title} \tсрок службы {_serviceLife}\n");
        }
    }
}
/*Задача:
Существует класс солдата. В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
Написать запрос при помощи которого получить набор данных состоящий из имени и звания.
Вывести все полученные данные в консоль.
(Не менее 5 записей)*/