using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BookLoan
{
    public class TitleViewModel
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public int UDK { get; set; }
        public string Genre { get; set; }
        public string Authors { get; set; }


        public TitleViewModel(List<string> authors)
        {

        }


    }
}
