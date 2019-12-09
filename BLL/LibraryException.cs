using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LibraryException : Exception
    {
        private string message;

        public LibraryException(string exception)
        {
            message = exception;
        }

        public LibraryException() : base()
        {

        }

        public override string Message => message;
    }
}
