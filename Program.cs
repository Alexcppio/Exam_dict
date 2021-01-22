using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex_task_dict.Classes;

namespace ex_task_dict
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Menu("dictionary.json");
            /*
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
              { "кошка", "cat" },
              { "собака", "dog" },
              { "змея", "snake" },
              { "корова", "cow" },
              { "лошадь", "horse" },
              { "свинья", "pig" },
              { "курица", "chicken" },
              { "утка", "duck" }
            };
            var obj = new RusEngDictionary("dictionary.json");
            obj.SerializeJson(dict);
            */
        }
    }
}
