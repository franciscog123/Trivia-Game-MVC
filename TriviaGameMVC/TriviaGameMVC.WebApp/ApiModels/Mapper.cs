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
            CompletedQuizzes = viewModel.CompletedQuizzes,
            Email = viewModel.Email
        };


        public static UserViewModel Map(User user) => new UserViewModel
        {

            UserId = user.UserId,
            UserName = user.UserName,
            CompletedQuizzes = user.CompletedQuizzes,
            Email = user.Email
        };

        public static ScoreBoard Map(ScoreBoardViewModel viewModel) => new ScoreBoard
        {
            UserId=viewModel.UserId,
            UserName=viewModel.UserName,
            CompletedQuizzes=viewModel.CompletedQuizzes,
            TotalScore=viewModel.TotalScore
        };

        public static ScoreBoardViewModel Map(ScoreBoard scoreBoard) => new ScoreBoardViewModel
        {
            UserId=scoreBoard.UserId,
            UserName=scoreBoard.UserName,
            CompletedQuizzes=scoreBoard.CompletedQuizzes,
            TotalScore=scoreBoard.TotalScore
        };
    }
}
