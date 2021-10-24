using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28.Implement_strStr__
{
    class Program
    {
        static void Main(string[] args)
        {
            string myhaystack = "mississippi";
            string myneedle = "issip";

            Console.WriteLine(myhaystack);
            Console.WriteLine(myneedle);
            Console.WriteLine(Convert.ToString(StrStr(myhaystack, myneedle)));
            Console.WriteLine(Convert.ToString(StrStr2(myhaystack, myneedle)));
            Console.Read();

            int StrStr(string haystack, string needle)
            {
                if (needle.Length == 0)
                {
                    return 0;
                }

                int j = 0;                                          //счетчик индекса needle

                for (int i = 0; i < haystack.Length; i++)
                {
                    if (haystack.Length - i < needle.Length - j)       //Если needle уже не влезает в haystack - Сброс (Ускоряет выполнение)
                    {
                        return -1;
                    }

                    if (haystack[i] == needle[j] && j == needle.Length - 1)
                    {
                        return i - needle.Length + 1;
                    }
                    else if (haystack[i] == needle[j] && j < needle.Length - 1)
                    {
                        j += 1;
                    }
                    else if (haystack[i] != needle[j])          //Сброс перебора символов в haystack needle, старт подбора со след символа после неудачи
                    {
                        i -= j;
                        j = 0;
                    }

                }
                return -1;
            }

            int StrStr2(string haystack, string needle)
            {

                HashSet<string> hash = new HashSet<string>();
                hash.Add(needle);

                if (hash.Contains(haystack))
                {
                    return 0;
                }

                int len = needle.Length;
                for (int i = 0; i < haystack.Length && haystack.Length - i >= len; i++)
                    if (hash.Contains(haystack.Substring(i, len)))
                        return i;

                return -1;
            }
            
        }
    }
}
