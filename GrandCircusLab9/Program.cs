using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GrandCircusLab9
{
    class Program
    {
        static void Main(string[] args)
        {

            //using collection type ArryList to store third piece of data - favorite color

            ArrayList favoriteColor = new ArrayList()
            {
                "blue",
                "red",
                "green",
                "yellow",
                "lavender",
                "peach",
                "grey",
                "cerulean",
                "purple",
                "gold",
                "silver",
                "clear",
                "polka dot",
                "grey",
                "red",
                "orange",
                "brown",
                "crimson",
                "translucent",
                "atomic purple"
            };
            




            //stored student info in a list collection

            List<string[]> studentList = new List<string[]>
            {

                new string[] { "Jack Bowen", "Detroit", "Pizza"},

                new string[] { "Heather Saunders", "Detroit", "Tacos" },

                new string[] { "Daren Allen", "Sandusky", "Noodles"},

                new string[] { "Allen Wrenchman", "Ann Arbor", "Pasta"},

                new string[] { "Karen Jenkmen", "Detroit", "Subs"},

                new string[] { "Darrel Jones", "Allen Park", "Chocolate"},

                new string[] { "Hank Hill", "Arlington", "Anything grilled with propane"},

                new string[] { "Sara McDargg", "Miami", "Churros"},

                new string[] { "Bilbo Bagins", "Shire", "Pie"},

                new string[] { "Link", "Kokiri Forest", "Moblin"},

                new string[] { "Darnel Dashins", "Detroit", "Hot Dogs"},

                new string[] { "Carrel Conrad", "Fort Worth", "Candy"},

                new string[] { "Larry David", "New York", "Angle Food Cake"},

                new string[] { "George Oscar Bluth", "Sudden Valley", "Frozen Banana"},

                new string[] { "John Rambo", "Vietnam", "the taste of freedom"},

                new string[] { "Julie Shifer", "Boston", "Crab"},

                new string[] { "Sarah Sarfel", "Lincoln Park", "Toast"},

                new string[] { "Joshua Zime", "Detroit", "Sloppy Joes"},

                new string[] { "Gertrude Malificent", "Detroit", "Apples"},

                new string[] { "Homer Simpson", "Springfield", "Donuts"}

            };




  

            int location = 0;

            while (true)

            {
                while (true)
                {
                    Console.WriteLine("Welcome to class. Which student would you like to learn more about?\n(Enter a number 1-{0})", studentList.Count);

                    //format handling
                    try
                    {
                        location = Int32.Parse(Console.ReadLine());

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please only enter a number!\n\n");
                        continue;
                    }

                    //range handling
                    try
                    {
                        string test = studentList[0][0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Student does not exist!\n\n");
                        continue;
                    }

                    break;
                }

                Console.Clear();

                string info = "";

                while (info == "")
                {
                    Console.WriteLine("Student number {0} is {1}", location, studentList[location - 1][0]);

                    Console.WriteLine("\nWould you like to know their...\n'hometown', 'favorite food', or 'favorite color' ?");

                    string option = Console.ReadLine();

                    //call method to find student info
                    info = (ReturnInfo(studentList, location, option, favoriteColor));

                    Console.WriteLine(info);
                }


                Console.WriteLine("\n\nWould you like to continue searching OR add a student?\n\n('c' to continue, 'a' to add, anything else to quit!)");

                char answer = Console.ReadKey(true).KeyChar;

                if(answer == 'c' || answer == 'C')
                {
                    Console.Clear();
                    continue;
                }
                else if(answer == 'a' || answer == 'A')
                {
                    string[] newKid = NewInTown();
                    string[] firstThree = new string[3];
                    firstThree[0] = newKid[0];
                    firstThree[1] = newKid[1];
                    firstThree[2] = newKid[2];

                    studentList.Add(firstThree);
                    favoriteColor.Add(newKid[3]);
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine("Goodbye!!!\n\n(press any key...)");
            Console.ReadKey();
        }

    
        //method to pull student's info--------------------------------------------------------------------------------------------------------------
        static string ReturnInfo(List<string[]> studentList, int location, string option, ArrayList favoriteColor)
        {
            
            if (option == "hometown")
            {
                string saver = (studentList[location - 1][0] + "'s hometown is " + studentList[location - 1][1]);
                return saver;
            }
            else if (option == "favorite food")
            {
                string saver = studentList[location - 1][0] + "'s favorite food is " + studentList[location - 1][2];
                return saver;
            }
            else if(option == "favorite color")
            {
                string saver = studentList[location - 1][0] + "'s favorite color is " + favoriteColor[location - 1];
                return saver;
            }
            else
            {
                Console.WriteLine("Please only type 'hometown' or 'favorite food'!");
                return "";                
            }

            
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        static string[] NewInTown()
        {

            string name;
            string town;
            string food;
            string color;

            Console.Clear();

            while (true)

            {
                Console.WriteLine("What is the 'Firstname Lastname' of the new student?");

                name = Console.ReadLine();

                if (Regex.IsMatch(name, @"^[A-Z][a-z]+\s[A-Z][a-z]+$"))
                {
                    Console.WriteLine("NAME ADDED <<<<<<<");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a Firstname and Lastname, with first letters in capital, all other lower...\n");
                }


            }

            while (true)

            {
                Console.WriteLine("What is their Hometown?");

                town = Console.ReadLine();

                if (Regex.IsMatch(town, @"^[A-Z][a-z]+\s*[A-Z]*[a-z]*$"))
                {
                    Console.WriteLine("HOMETOWN ADDED <<<<<<<");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a town, with first letters capitalized...\n");
                }


            }

            while (true)

            {
                Console.WriteLine("What is their favorite food?");

                food = Console.ReadLine();

                if (Regex.IsMatch(food, @"^[a-zA-Z]+\s*[a-zA-Z]*$"))
                {
                    Console.WriteLine("FAVORITE FOOD ADDED <<<<<<<");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a food, letters only...\n");
                }


            }


            while (true)

            {
                Console.WriteLine("What is their favorite color?");

                color = Console.ReadLine();

                if (Regex.IsMatch(color, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("FAVORITE COLOR ADDED <<<<<<<");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a color using letters only...\n");
                }


            }

            Console.Clear();

            Console.WriteLine(name + " was added!\n(press any key to continue...)");

            Console.ReadKey();

            Console.Clear();

            string[] newInTown = new string[] { name, town, food, color };

            return newInTown;

        }
    }
}
