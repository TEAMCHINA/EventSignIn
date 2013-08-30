using System;
using System.Collections.Generic;
using System.Linq;
using EventSignIn.Models;

namespace EventSignIn.DataAccess
{
    public class UserDataAccess
    {
        public IList<UserModel> GetUsers()
        {
            using (var db = new EventSignInEntities())
            {
                var users = db.Users
                                   .Select(user => new UserModel
                                       {
                                           Id = user.Id,
                                           FirstName = user.FirstName,
                                           LastName = user.LastName,
                                           EmailAddress = user.EmailAddress,
                                           EmailOptIn = user.EmailOptIn,
                                           GraduationYear = user.GraduationYear,
                                           Notes = user.Notes,
                                           PhoneNumber = user.PhoneNumber,
                                       });

                return users.ToList();
            }
        }

        public UserModel GetUserById(int id)
        {
            return GetUsers()
                .FirstOrDefault(user => user.Id == id);
        }

        public UserModel GetUserByEmail(string emailAddress)
        {
            return GetUsers()
                .FirstOrDefault(user => string.Equals(emailAddress, user.EmailAddress, StringComparison.OrdinalIgnoreCase));
        }

        public int CreateUser(UserModel user)
        {
            using (var db = new EventSignInEntities())
            {
                var newUser = new User
                                   {
                                       Id = user.Id,
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       EmailAddress = user.EmailAddress,
                                       EmailOptIn = true, // All users should be opted in by default at creation
                                       GraduationYear = user.GraduationYear,
                                       Notes = user.Notes,
                                       PhoneNumber = user.PhoneNumber,
                                   };

                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser.Id;
            }
        }
    }
}