using MixedAssignment.Domain.Models;
using MixedAssignment.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.UserService
{
    public interface IUserService
    {
        UserRegiShowVM UserAdd(UserRegisterVM user);
        User LogIn(string username, string password);
        string GetPassword(string email);
        List<Country> GetCountries();
        List<UserType> GetRoles();
        List<State> GetStatebyId();
    }
}
