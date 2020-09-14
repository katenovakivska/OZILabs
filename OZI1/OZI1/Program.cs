using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI1
{
    public struct User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public bool Limitation { get; set; }
        public User(string login, string password, string role, string status, bool limitation)
        {
            Login = login;
            Password = password;
            Role = role;
            Limitation = limitation;
            Status = status;
        }
    }

    public class Reading
    {
        //public static string path = @"C:\Users\Kateryna\source\repos\OZI1\OZI1\Files\";
        public List<User> FileRead(string file)
        {
            List<User> users = new List<User>(); 
            string path = @"C:\Users\Kateryna\source\repos\OZI1\OZI1\Files\";
            string[] lines = File.ReadAllLines($"{path}{file}", Encoding.GetEncoding(1251));

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(';');
                User user = new User();
                user.Login = temp[0];
                user.Password = temp[1];
                user.Role = temp[2];
                user.Status = temp[3];
                user.Limitation = Convert.ToBoolean(temp[4]);
                users.Add(user);

            }

            return users;
        }

        public List<User> FileWrite(string user, string pathCsvFile)
        {
            string path = @"C:\Users\Kateryna\source\repos\OZI1\OZI1\Files\";
            pathCsvFile = $"{path}{pathCsvFile}";
            using (StreamWriter streamReader = new StreamWriter(pathCsvFile, true))
            {
                 streamReader.WriteLine(user);
            }
            return FileRead("file1.csv");
        }

        public List<User> FileDelete(string user, string u, string pathCsvFile)
        {
            string path = @"C:\Users\Kateryna\source\repos\OZI1\OZI1\Files\";
            pathCsvFile = $"{path}{pathCsvFile}";
            var lines = File.ReadAllLines(pathCsvFile, Encoding.GetEncoding(1251)).ToList();
            lines.Remove(user);
            lines.Add(u);
            File.WriteAllLines(pathCsvFile, lines);
            return FileRead("file1.csv");
        }

    }
    
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Reading reading = new Reading();
            List<User> users = reading.FileRead("file1.csv");
            //users.Add(new User("Olexandra", "123456", "User", "Unblocked", new List<string>() { "one", "two"}));
            //users.Add(new User("Olesya", "123456", "User", "Unblocked", new List<string>() { "one" }));
            //users.Add(new User("ADMIN", "123456", "Admin", "Neutral", new List<string>()));
            Application.Run(new EntranceForm(users));
        }
    }
}
