using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Utils
{
    /// <summary>
    /// Convert a string to a list of dictionnary words
    /// </summary>
    public class WordString : INotifyPropertyChanged
    {

        public WordString(string str)
        {
            _value = str;
        }

        private string _value;
        public string Value
        {
            set 
            { 
                _value = value;
                OnPropertyChanged();
            }
            get { return _value; }
        }

        private List<string> _wordsList;
        public List<string> WordList
        {
            set
            {
                _wordsList = value;
                OnPropertyChanged();
            }
            get { return _wordsList; }
        }


        /// <summary>
        /// Find Existing words in the string given by the <code>Value</code> member
        /// </summary>
        public void FindWords()
        {
            // TODO
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string
        propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new
            PropertyChangedEventArgs(propertyName));
        }

    }

    public enum Languages 
    {
        English,
        French 
    }
}
