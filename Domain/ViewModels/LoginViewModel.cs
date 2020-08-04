using Domain.ViewModels;

namespace VirtualMarketPlace.Domain.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginReturnViewModel LoginReturn { get; set; }
    }
}
