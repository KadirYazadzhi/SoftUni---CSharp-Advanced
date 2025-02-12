using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator {
    public class StartUp {
        static void Main() {
            string[] data = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            ListyIterator<string> listyIterator = new ListyIterator<string>(data.Skip(1));
            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END") {
                try {
                    if (command == "Move") Console.WriteLine(listyIterator.Move());
                    else if (command == "Print") Console.WriteLine(listyIterator.Current);
                    else if (command == "HasNext") Console.WriteLine(listyIterator.HasNext());
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
