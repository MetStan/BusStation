namespace BusStation.Controllers
{
    using BusStation.Contracts;
    using BusStation.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService userSirvice)
        {
            users = userSirvice;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel model)
        {
            List<string> errors = users.CreateUser(model).ToList();

            if (errors.Any() == false)
            {
                return Redirect("/Users/Login");
            }

            //return Error(errors);
            return Redirect("Register");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Destinations/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel model)
        {
            var userId = users.GetUserId(model);

            //if (string.IsNullOrEmpty(userId) == false && string.IsNullOrWhiteSpace(userId) == false)
            if (userId != null)
            {
                this.SignIn(userId);

                return Redirect("/Destinations/All");
            }
            ;
            //return Error("Incorrect Username or Password.");
            return Redirect("Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}

