using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HiWeb.Tests.Controllers
{
    // Primary constructor
    public class CSharpContruct//(int x, int y)
    {
        private static void DoMain(string[] args)
        {
            var hero = new AType();
            if (hero.SuperPower == String.Empty)
            {
                hero = null;
            }

            // New null conditional operator
            WriteLine(hero?.SuperPower ?? "You aint a super hero.");
            ReadLine();
        }

        public void Process()
        {
            MyTemp2(out string x);


            // static type as using
            WriteLine(x);

            var a = new AType();

            switch(a)
            {

                default:
                    break;
            }
        }


        // exception filtering
        public void Process2()
        {
            var random = new Random();
            var randomExceptions = random.Next(400, 405);

            WriteLine("Generated exception: " + randomExceptions);
            Write("Exception type: ");

            try
            {
                throw new Exception(randomExceptions.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Write("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Write("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Write("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                Write("Forbidden");
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                Write("Not Found");
            }
        }

        //Expression Bodied Function & Property
        public int MyTemp(int x, int y) => x + y;

        public string MyTemp1()
        {
            //Dictionary Initializers
            var alien = new Dictionary<string, string>()
            {
                ["Name"] = "Fizzy",
                ["Planet"] = "Kepler-452b"
            };


            // nameof
            return nameof(alien);
        }

        // string interpolation
        public void MyTemp2(out string x) { x = $"this is my machine {Environment.MachineName} <-"; }



    }

    class PeopleManager
    {
        public List<string> Roles { get; } =
           new List<string>() { "Employee", "Managerial" };
    }

    
    class AType
    {
        // auto property intializer
        public string Name { get; } = "Sammy Jenkins";

        public decimal Salary { get; set; } = 10000;
        public string SuperPower { get; internal set; }
    }

}
