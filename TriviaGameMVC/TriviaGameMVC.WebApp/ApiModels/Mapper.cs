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

        public static Question Map(QuestionViewModel viewModel) => new Question
        {
            QuestionId=viewModel.QuestionId,
            CategoryId=viewModel.CategoryId,
            QuestionString=viewModel.QuestionString,
            Value=viewModel.Value
        };

        public static QuestionViewModel Map(Question question) => new QuestionViewModel
        {
            QuestionId=question.QuestionId,
            CategoryId=question.CategoryId,
            QuestionString=question.QuestionString,
            Value=question.Value
        };

        public static Category Map(CategoryViewModel viewModel) => new Category
        {
            CategoryId = viewModel.CategoryId,
            CategoryString = viewModel.CategoryString
        };

        public static CategoryViewModel Map(Category category) => new CategoryViewModel
        {
            CategoryId=category.CategoryId,
            CategoryString=category.CategoryString
        };

        public static Choice Map(ChoiceViewModel viewModel) => new Choice
        {
            ChoiceId = viewModel.ChoiceId,
            QuestionId = viewModel.QuestionId,
            Correct = viewModel.Correct,
            ChoiceString = viewModel.ChoiceString
        };

        public static ChoiceViewModel Map(Choice choice) => new ChoiceViewModel
        {
            ChoiceId = choice.ChoiceId,
            QuestionId = choice.QuestionId,
            Correct = choice.Correct,
            ChoiceString = choice.ChoiceString
        };
    }
}
