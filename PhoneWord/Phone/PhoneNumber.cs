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

        public PhoneNumber(char[] DigitArray)
        {
            this.DigitArray = DigitArray;
        }

        private char[] _digitArray;
        public char[] DigitArray
        {
            set { _digitArray = value; }
            get { return _digitArray; }
        }

        private ObservableCollection<string> _charCombinations;
        /// <summary>
        /// Hold the list of hidden strings in the Phone Number
        /// </summary>
        public ObservableCollection<string> CharCombinations
        {
            get { return _charCombinations; }
        }


        /// <summary>
        /// DEPRECATED
        /// Find the strings hidden in the phone number <code>Number</code> and store them in the <code>StringsList</code> Member
        /// </summary>
        /// <returns>List of strings out the number</returns>
        /// <seealso cref="StringsList"/>
        /*
        [Obsolete("Use ")]
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
        //*/


        /*
        /// <summary>
        /// List the differents combinations of char which can be formed with <code>DigitArray</code> in the <code>CharCombinations</code> member
        /// </summary>
        public void FetchCharCombinations() 
        {
            _charCombinations = new ObservableCollection<string>();
            Keypad keypad = new Keypad();
            char[] charArray = new char[DigitArray.Length];

            // Initialize the result with first string (the phone number itself)
            for (int i = 0; i < DigitArray.Length; i++)
                charArray[i] = keypad.GetCharAt(DigitArray[i], 0);

            for (int fixedIndex = 0; fixedIndex < DigitArray.Length; ++fixedIndex)
            {
                for (int i = 0; i < DigitArray.Length; ++i)
                {
                    if (i != fixedIndex)
                    {
                        int keyNbChar = keypad.GetKeyNumberOfChar(DigitArray[i]); // Number of characters on the key
                        for (int k = 0; k < keyNbChar; ++k)
                        {
                            charArray[i] = keypad.GetCharAt(DigitArray[i], k);
                            _charCombinations.Add(new string(charArray));
                        }
                    }
                }
            }
        }
        //*/



        /// <summary>
        /// List the differents combinations of char which can be formed with <code>DigitArray</code> in the <code>CharCombinations</code> member
        /// </summary>
        public void FetchCharCombinations()
        {
            _charCombinations = new ObservableCollection<string>();
            Keypad keypad = new Keypad();
            char[] charArray = new char[DigitArray.Length];

            // Initialize the result with first string (the phone number itself)
            for (int i = 0; i < DigitArray.Length; i++)
                charArray[i] = keypad.GetCharAt(DigitArray[i], 1); // TODO init at 0 if we include letters

            _charCombinations.Add(new string(charArray));
            for (int permuteIndex = DigitArray.Length - 1; permuteIndex >= 0; --permuteIndex)
            {
                for (int i = 0; i <= permuteIndex; ++i)
                {
                    int keyNbChar = keypad.GetKeyNumberOfChar(DigitArray[i]); // Number of characters on the key
                    for (int k = 1; k < keyNbChar; ++k) // TODO k start at 0 if we include letters
                    {
                        charArray[i] = keypad.GetCharAt(DigitArray[i], k);
                        _charCombinations.Add(new string(charArray));
                    }
                }
            }
        }

    }
}
