using HashScan.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashScan.Lib
{
    class SHA1 : IHash
    {
        public string HashFile(string path)
        {
            try {
                using (FileStream fs = File.OpenRead(path))
                {
                    System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1Managed();
                    return BitConverter.ToString(sha.ComputeHash(fs)).Replace("-", string.Empty).ToLower();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return "";
            }
        }
    }
}
