using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Interfaces.Services
{
    public interface IIsbnService
    {
        string Dehyphenate(string isbn);

        string Hyphenate(string isbn);
    }
}
