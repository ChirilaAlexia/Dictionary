using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDictionary
{
    internal class Administrator
    {
        private Dictionary<string, string> administrator = new Dictionary<string, string>();
        public Administrator()
        {
            LoadUserCredentials();
        }
        private void LoadUserCredentials()
        {
            string[] lines = File.ReadAllLines("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\administrators.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 2)
                {
                    administrator.Add(parts[0], parts[1]);
                }
            }
        }
        public bool Authenticate(string username, string password)
        {
            if (administrator.ContainsKey(username))
            {
                if (administrator[username] == password)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
