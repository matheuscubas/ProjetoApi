namespace DesafioDesafiante.ViewModels
{
    public class LoginResultViewModel
    {
        public LoginResultViewModel(string usermame, string token)
        {
            Usermame = usermame;
            Token = token;
        }

        public string Usermame { get; private set; }
        public string Token { get; private set; }
 
    }
}
