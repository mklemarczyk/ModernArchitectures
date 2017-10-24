﻿namespace ArqLibrarianClassic
{
    public class User
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Pesel { get; set; }

        public User(string nickname, string password, string fullname, string address, string pesel)
        {
            this.Nickname = nickname;
            this.Password = password;
            this.Fullname = fullname;
            this.Address = address;
            this.Pesel = pesel;
        }
    }
}