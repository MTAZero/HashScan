using HashScan.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashScan.Lib
{
    class DataBase
    {
        public List<Virus> GetListViruses(string path)
        {
            List<Virus> ans = new List<Virus>();

            try
            {   
                using (StreamReader sr = new StreamReader(path))
                {

                    int lines = Int32.Parse(sr.ReadLine().Trim());
                    for(var index = 0; index<lines; index++)
                    {
                        string line = sr.ReadLine().Trim();
                        List<string> str = line.Split(':').ToList();

                        Virus virus = new Virus();
                        virus.Name = str[0];
                        virus.HashValue = str[1];
                        ans.Add(virus);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return ans;
        }
    }
}
