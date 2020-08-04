namespace Domain.ViewModels
{
    public class LoginReturnViewModel
    {

        public LoginReturnViewModel(bool hasException, string exceptionMessage)
        {
            HasException = hasException;
            ExceptionMessage = exceptionMessage;
        }
        public bool HasException { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
