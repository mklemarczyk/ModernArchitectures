using System;

namespace ArqLibrarianClassic.Library
{
    public class SingleRating
    {
        public int Rating { get; }
        private DateTime when;

        public SingleRating(int rating)
        {
            this.Rating = rating;
            this.when = DateTime.Now;
        }
    }
}