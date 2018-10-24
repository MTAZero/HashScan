using HashScan.Entity;
using HashScan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashScan.Lib
{
    class ResultScan
    {
        public bool IsEmpty { get; set; }
        public string VirusName { get; set; }
    }

    class BinarySearch
    {
        private List<Virus> viruses;
        
        public void SetLists(List<Virus> list)
        {
            viruses = list;
            SortList();
        }

        public List<Virus> GetLists()
        {
            return viruses;
        }

        private void SortList()
        {
            viruses = viruses.OrderBy(p => p.HashValue).ToList();
        }

        public ResultScan Search(string hashValue)
        {
            ResultScan ans = new ResultScan() { IsEmpty = true, VirusName = ""};

            int low = 0;
            int high = viruses.Count;

            while (high > low + 1)
            {
                int mid = (high + low) / 2;
                var virus = viruses[mid];
                if (virus.HashValue == hashValue)
                {
                    ans.IsEmpty = false;
                    ans.VirusName = virus.Name;
                    return ans;
                }

                if (hashValue.CompareTo(virus.HashValue) > 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            if (low < viruses.Count && viruses[low].HashValue == hashValue)
            {
                ans.IsEmpty = false;
                ans.VirusName = viruses[low].Name;
                return ans;
            } 

            if (high < viruses.Count && viruses[high].HashValue == hashValue)
            {
                ans.IsEmpty = false;
                ans.VirusName = viruses[high].Name;
                return ans;
            }

            return ans;
        } 
    }

    class HashScanner
    {
        private IHash hashHelper;
        private DataBase databaseHelper = new DataBase();
        private BinarySearch binarySearch = new BinarySearch();

        public HashScanner(IHash _hashHelper)
        {
            hashHelper = _hashHelper;
        }

        public ResultScan scan(string path_db, string path)
        {
            List<Virus> listVirus = databaseHelper.GetListViruses(path_db);

            binarySearch.SetLists(listVirus);

            string hashValue = hashHelper.HashFile(path);
            Console.WriteLine("Hash value : " + hashValue);

            ResultScan ans = binarySearch.Search(hashValue);

            return ans;
        }

    }
}
