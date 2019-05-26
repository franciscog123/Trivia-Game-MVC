using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.ApiModels
{
    public static class Mapper
    {
        public static User Map(UserViewModel viewModel) => new User
        {
            UserId = viewModel.UserId,
            UserName = viewModel.UserName,
            Email = viewModel.Email,
            CompletedQuizzes = viewModel.CompletedQuizzes
        };


        public static UserViewModel Map(User user) => new UserViewModel
        {

            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            CompletedQuizzes = user.CompletedQuizzes

        };
    }
}
