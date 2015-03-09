using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Phone
{
    public class PhoneNumber
    {

        public PhoneNumber() { }

        public PhoneNumber(int[] tNumber)
        {
            _number = tNumber;
        }

        private int[] _number;
        public int[] Number
        {
            set { _number = value; }
            get { return _number; }
        }

        private ObservableCollection<string> _stringsList;
        /// <summary>
        /// Hold the list of hidden strings in the Phone Number
        /// </summary>
        public ObservableCollection<string> StringsList
        {
            get { return _stringsList; }
        }


        /// <summary>
        /// Find the strings hidden in the phone number <code>Number</code> and store them in the <code>StringsList</code> Member
        /// </summary>
        /// <returns>List of strings out the number</returns>
        /// <seealso cref="StringsList"/>
        public void FindStrings()
        {
            
            _stringsList = new ObservableCollection<string>();
            Keypad keypad = new Keypad();
            char[] tChar = new char[Number.Length];

            // Initialize the result with first string (the phone number itself)
            for (int i = 0; i < Number.Length; i++)
                tChar[i] = keypad.getCharKey(Number[i], 0);


            for (int fixedIndex = 0; fixedIndex < Number.Length; ++fixedIndex)
            {
                for (int i = 0; i < Number.Length; ++i)
                {
                    for (int k = 0; k < Keypad.MAX_CHAR_COUNT; ++k)
                    {
                        if (i == fixedIndex) 
                            break;
                        else if (tChar[i] == 0) 
                            break; 
                        else if (tChar[i] == 1)
                            break;
                        else
                        {
                            tChar[i] = keypad.getCharKey(Number[i], k);
                            _stringsList.Add(new string(tChar));
                        }
                    }
                }
            }

             
        }


    }
}
