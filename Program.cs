using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDatabase
{
    static class CustomDatabaseApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0 - Write data");
            Console.WriteLine("1 - Read data");
            int modeID = Convert.ToInt32(Console.ReadLine());

            if (modeID == 0)
            {
                Console.Write("Your name, please ");
                string name = Console.ReadLine();
                Console.Write("Your password, please ");
                string password = Console.ReadLine();

                User user = new User(name, password, DateTime.Now);
                Config.AddUser(user);
                Config.Save();
            }
            else
            {

            }

        }
    }

    class User
    {
        private string name;
        private string password;
        private DateTime birthday;
        private DateTime createdAt;

        public string Name 
        { 
            get { return name; } 
            set 
            {
                if (value == null) { return; }
                if (value.Length == 0) { return; }
                name = value.Trim();
            } 
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value == null) { return; }
                if (value.Length < 4) { return; }
                password = value;
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public User(string name, string password, DateTime birthday)
        {
            this.name = name;
            this.password = password;
            this.birthday = birthday;
            this.createdAt = DateTime.Now;
        }
    }

    static class Config
    {
        private static string dataPath = @"C:\Database\";

        private static List<User> users = new List<User>();

        public static List<User> GetUsers() { return users; }
        public static void AddUser(User u) { users.Add(u); }
        public static void RemoveUser(User u) { users.Remove(u); }
        public static void RemoveUser(int index) { users.RemoveAt(index); }


        public static void Save()
        {
            if (!Directory.Exists(dataPath)) { Directory.CreateDirectory(dataPath); }

            foreach(User user in users)
            {
                string userPath = dataPath + user.Name + ".data";
                using (StreamWriter sw = new StreamWriter(userPath, false))
                {
                    sw.WriteLine(user.Name);
                    sw.WriteLine(user.Password);
                    sw.WriteLine(user.Birthday);
                    sw.WriteLine(user.CreatedAt);
                }
            }
        }

        public static void Load()
        {
            if (!Directory.Exists(dataPath)) { return; }

            /* Ваш код 😋 */
        }
    }
}
