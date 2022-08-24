using AcmeLibrary.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Infrastructure.Services
{
    public class IsbnService : IIsbnService
    {
        public string Dehyphenate(string isbn)
        {
            return isbn.Trim().Replace("-", "");
        }

        public string Hyphenate(string isbn)
        {
            var cleanIsbn = Dehyphenate(isbn);

            var list = new List<char>();
            list.AddRange(cleanIsbn.Take(3));
            list.Add('-');
            list.AddRange(cleanIsbn.Skip(3).Take(1));
            list.Add('-');
            list.AddRange(cleanIsbn.Skip(4).Take(4));
            list.Add('-');
            list.AddRange(cleanIsbn.Skip(8).Take(4));
            list.Add('-');
            list.Add(cleanIsbn.Last());

            return new string(list.ToArray());
        }
    }
}
