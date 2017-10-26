using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class Terms
    {
        private readonly BorrowingRepository repository;

        private string type;

        public Terms(BorrowingRepository repository, string type)
        {
            this.repository = repository;

            this.type = type;
        }
    }
}
