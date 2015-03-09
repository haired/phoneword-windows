using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Phone
{
    public class Keypad
    {

        public static readonly int MAX_CHAR_COUNT = 4; // Maximum Number of characher on a key

        public Keypad()
        {
            // TODO Set as resource
            phoneKeypad = new Dictionary<int, string>();
            phoneKeypad.Add(0, "0");
            phoneKeypad.Add(1, "1");
            phoneKeypad.Add(2, "2ABC");
            phoneKeypad.Add(3, "3DEF");
            phoneKeypad.Add(4, "4GHI");
            phoneKeypad.Add(5, "5JKL");
            phoneKeypad.Add(6, "6MNO");
            phoneKeypad.Add(7, "7PQRS");
            phoneKeypad.Add(8, "8TUV");
            phoneKeypad.Add(9, "9WXYZ"); //z?

        }


        public char getCharKey(int key, int position)
        {
            if ((key == 0) || (key == 1))
                return phoneKeypad[key].ElementAt(0);
            else if (phoneKeypad.ContainsKey(key) && (0 <= position && position <= MAX_CHAR_COUNT -1))
                return phoneKeypad[key].ElementAt(position);
            else
                return '\0';
        }

        public  Dictionary<int, string> phoneKeypad ;

    }
}
