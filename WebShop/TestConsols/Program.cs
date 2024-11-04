

using DataAccessLayer;
using Entities;

namespace TestConsols
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User user = new User
            {
                FrstName = "Test",
                LastName = "Test",
                Satus  = true,
                Email= "Test@test.com",
                PasswordHash="dfjskfhsd",
                IdRole=1
            };

            IUserRepository userRepository = new UserRepository();
            bool add = userRepository.Add(user);

            Console.WriteLine(add);

        }
    }
}