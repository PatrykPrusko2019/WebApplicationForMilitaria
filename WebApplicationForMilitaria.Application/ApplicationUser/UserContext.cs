using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WebApplicationForMilitaria.Domain.Interfaces;

namespace WebApplicationForMilitaria.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _repository;
        
        public UserContext(IHttpContextAccessor contextAccessor, IUserRepository repository)
        {
            _httpContextAccessor = contextAccessor;
            _repository = repository;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null) 
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            //string role = "";
            //try
            //{
            //    role = user.FindFirst(c => c.Type == ClaimTypes.Role)!.Value;
            //}
            //catch (Exception ex) 
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //if (role == null || role == "")
            //{
            //    role = _repository.getRole(email).Result;
            //}
            

            return new CurrentUser(id, email);
        }
    }
}
