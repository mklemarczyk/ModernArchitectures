using System.Collections.Generic;
using System.Linq;

namespace ArqLibrarianClassic.Library
{
    public class MemoryUserDao : UserDao
    {
        private static readonly List<User> users = new List<User>();

        public void Insert(User user)
        {
            user.Id = Generated.UserId();
            users.Add(user);
        }
        
        public User FindById(long id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new LibrarianException($"User not found with id = {id}");
            }

            return user;
        }

        public void Init()
        {
            Insert(new User("kowalski", "kowal", "Jan Kowalski", "Gdynia", "87052507754"));
            Insert(new User("nowak", "nowypass", "Piotr Nowak", "Warszawa", "890224031121"));
            Insert(new User("koper", "dupadupa", "Wojciech Koperski", "Zakopane", "91121202176"));
        }

        public void Clear()
        {
            users.Clear();
        }
    }
}