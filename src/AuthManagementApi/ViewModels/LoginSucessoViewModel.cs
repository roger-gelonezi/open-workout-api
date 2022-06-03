using System.ComponentModel;

namespace AuthManagementApi.ViewModels
{
    [DisplayName("LoginSucesso")]
    public class LoginSucessoViewModel
    {
        public LoginSucessoViewModel(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
