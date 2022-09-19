namespace BusinessLayer
{
    public interface IVerifyAnswers
    {
        dynamic Verify_API_Form_Data__EMAILS(string response, int responseMin, int responseMax);
        dynamic Verify_API_Form_Data__LongResponse(string response, int responseMin, int responseMax);
        dynamic Verify_API_Form_Data__PASSWORD(string password, int responseMin, int responseMax);
        dynamic Verify_API_Form_Data__StringsONLY(string strinVal, int responseMin, int responseMax);
        dynamic Verify_API_Form_Data__USERNAME(string username, int responseMin, int responseMax);
        bool Veryify_EMAIL(string Email);
    }
}