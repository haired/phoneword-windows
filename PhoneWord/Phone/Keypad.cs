using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Phone
{
    public class Keypad
    {

        // Set members static

        public Keypad()
        {
            // TODO Set as resource
            _phoneKeypad = new Dictionary<char, string>();
            _phoneKeypad.Add('0', "0");
            _phoneKeypad.Add('1', "1");
            _phoneKeypad.Add('2', "2ABC");
            _phoneKeypad.Add('3', "3DEF");
            _phoneKeypad.Add('4', "4GHI");
            _phoneKeypad.Add('5', "5JKL");
            _phoneKeypad.Add('6', "6MNO");
            _phoneKeypad.Add('7', "7PQRS");
            _phoneKeypad.Add('8', "8TUV");
            _phoneKeypad.Add('9', "9WXYZ"); //z?

        }


        /// <summary>
        /// Get a character on a key, at a particular position
        /// </summary>
        /// <param name="key"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public char GetCharAt(char key, int position)
        {
            if (_phoneKeypad.ContainsKey(key))
                if(position < GetKeyNumberOfChar(key))
                    return _phoneKeypad[key].ElementAt(position);

            throw new ArgumentOutOfRangeException("No Char at key:" + key + " and position:" + position);
            //return '\0';
        }


        /// <summary>
        /// Get the number of character on a particular key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetKeyNumberOfChar(char key) 
        {
            return PhoneKeypad[key].Length;
        }


        private Dictionary<char, string> _phoneKeypad ;
        public Dictionary<char, string> PhoneKeypad
        {
            get 
            {
                return _phoneKeypad;
            }
        }

    }
}
