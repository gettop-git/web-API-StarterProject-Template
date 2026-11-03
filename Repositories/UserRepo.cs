using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepo
    {
    
        readonly string Filepath = @"..\Repositories\Data.txt";
        public User GetUserById(int id)
        {

            using (StreamReader reader = System.IO.File.OpenText(Filepath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(currentUserInFile))
                    {
                        continue;
                    }

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user;
                }
            }
            return null;
        }

        public User AddUser(User user)
        {
            if (user == null)
            {
                return user;
            }
            int numberOfUsers = System.IO.File.ReadLines(Filepath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);

            System.IO.File.AppendAllText(Filepath, userJson +
              Environment.NewLine);
            return user;
        }
        public User UserLogIn(Userin userin)
        {
            User user = null;
            using (StreamReader reader = System.IO.File.OpenText(Filepath))
            {
                string? currentUserInFile;

                while ((currentUserInFile = reader.ReadLine()) != null)
                {


                    user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == userin.Email && user.Password == userin.Password)
                    {
                        return user;
                    }


                }
            }
            user = null;
            return user;
        }

        public User? UpdateUserById(int id, User user)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(Filepath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User userInFile = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (userInFile.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(Filepath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));

                System.IO.File.WriteAllText(Filepath, text);

                return user;
            }
            return null;
        }

    }
}
