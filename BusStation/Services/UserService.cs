namespace BusStation.Services
{
    using BusStation.Contracts;
    using BusStation.Data;
    using BusStation.Data.Common;
    using BusStation.Data.Models;
    using BusStation.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IValidatorService validator;
        private readonly IPasswordHasher hashedPassword;
        private readonly BusStationDbContext db;

        public UserService(IValidatorService validator, 
            IPasswordHasher hashedPassword,
            BusStationDbContext db)
        {
            this.validator = validator;
            this.hashedPassword = hashedPassword;
            this.db = db;
        }

        //public UserService(BusStationDbContext db,
        //IValidatorService userValidator,
        //IPasswordHasher passwordHasher)
        //    : base(db)
        //{
        //    validator = userValidator;
        //    hashedPassword = passwordHasher;
        //}

        public ICollection<string> CreateUser(RegisterFormViewModel model)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (IsUsernameAvailable(model.Username)
                || IsEmailAvailable(model.Email))
            {
                errors.Add($"User or Email exists.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword.HashPassword(model.Password),
            };
            
            db.Users.Add(user);
            db.SaveChanges();

            return errors;
        }

        public string GetUserId(LoginFormViewModel model)
        {
            var password = hashedPassword.HashPassword(model.Password);

            var userId = db.Users
                    .Where(u => u.Username == model.Username && u.Password == password)
                    .Select(u => u.Id)
                    .FirstOrDefault();

            return userId;
        }

        public string GetUsername(string userId)
        {
            var username = db.Users
                .Where(u => u.Id == userId)
                .Select(n => n.Username)
                .FirstOrDefault();

                return username;
        }

        public bool IsEmailAvailable(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }
    }
}
