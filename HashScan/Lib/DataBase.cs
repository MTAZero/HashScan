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

        public void WriteDataBase(string path, List<Virus> viruses)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(viruses.Count);
                    for(int i = 0; i<viruses.Count; i++)
                    {
                        Virus virus = viruses[i];
                        sw.WriteLine(virus.Name + ":" + virus.HashValue);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error write database: ", e.Message);
            }
        }
    }

}
