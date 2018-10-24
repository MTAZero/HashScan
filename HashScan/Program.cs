using HashScan.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashScan
{
    class Program
    {
        public static ResultScan MD5Scan(string path_db, string path)
        {
            MD5 md5 = new MD5();
            HashScanner hashScanner = new HashScanner(md5);

            return hashScanner.scan(path_db, path);
        }

        public static ResultScan SHA1Scan(string path_db, string path)
        {
            SHA1 sha1 = new SHA1();
            HashScanner hashScanner = new HashScanner(sha1);

            return hashScanner.scan(path_db, path);
        }

        static void Main(string[] args)
        {
            // path database
            string path_md5 = "./db/md5.txt";
            string path_sha1 = "./db/sha1.txt";

            Console.Write("File scan (path) : ");
            string path = Console.ReadLine();
            Console.WriteLine();

            ResultScan ans = new ResultScan();
            // Use MD5 scan
            ans = MD5Scan(path_md5, path);
            Console.Write("MD5 Scan : ");
            if (ans.IsEmpty == true)
                Console.WriteLine("Clear File!");
            else
                Console.WriteLine("Malware Found : " + ans.VirusName);
            Console.WriteLine();

            // Use Sha1 Scan
            ans = SHA1Scan(path_sha1, path);
            Console.Write("SHA1 Scan : ");
            if (ans.IsEmpty == true)
                Console.WriteLine("Clear File!");
            else
                Console.WriteLine("Malware Found : " + ans.VirusName);
            Console.WriteLine();

            // wait a key
            Console.WriteLine("Scan Done");
            Console.ReadLine();
        }
    }
}
