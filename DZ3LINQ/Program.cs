using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DZ3LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            string enter1 = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            string[] splitValues1 = enter1.Split(',');
            int counter = 1;
            string intermediateString;

            foreach (string splitValue in splitValues1)
            {
                intermediateString =  counter + "." + splitValue;
                splitValues1[counter - 1] = intermediateString;
                counter++;
            }

            var result1 = splitValues1.Aggregate((current, next) => current + ", " + next);

            Console.WriteLine("1:" + "\n" + result1);
            #endregion

            #region 2
            string enter2 = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            string[] splitValues2 = enter2.Split(';');
            List<string[]> list = new List<string[]>();

            foreach(string splitValue in splitValues2)
            {
                list.Add(splitValue.Split(','));
            }

            List<Player> players = new List<Player>();
            string dateofbirth;
            string[] name;

            foreach (string[] playerFields in list)
            {
                name = playerFields[0].Trim().Split(' ');
                dateofbirth = playerFields[1].Trim(); 
                players.Add(new Player() { Name = name[0], Surname = name[1], DateOfBirth = DateTime.Parse(dateofbirth) });
            }

            var orderedPlayers = players.OrderBy(y => y.DateOfBirth);

            Console.WriteLine("\n2:\n");

            foreach (var s in orderedPlayers)
                Console.WriteLine(s.ToString());
            #endregion

            #region 3
            string enter3 = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            string[] splitValues3 = enter3.Split(',');
            string[] time;
            List<int> time1 = new List<int>();

            foreach(string splitValue in splitValues3)
            {
                time = splitValue.Split(':');
                time1.Add(int.Parse(time[0]) * 60 + int.Parse(time[1]));
            }
            int result3 = time1.Aggregate((current, next) => current + next);
            TimeSpan timeSpan = TimeSpan.FromSeconds(result3);
            Console.WriteLine("\n3:" + "\n" + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds);
            #endregion


            Console.ReadKey();
        }

        class Player
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }

            public override string ToString()
            {
                return Name + " " + Surname + " " + DateOfBirth.ToString() + " Age: " + ((int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd")))/10000).ToString();
            }
        }
    }
}
