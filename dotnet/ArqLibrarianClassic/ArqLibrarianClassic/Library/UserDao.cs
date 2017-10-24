namespace ArqLibrarianClassic
{
    public interface UserDao
    {
        void Insert(User user);
        User FindById(long userId);
    }
}