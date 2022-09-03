using Microsoft.VisualStudio.TestPlatform;
using BusinessLayer;
using RepoLayer;
using ModelLayer;

namespace Tests.Project2;
//[TestClass]
public class UserAuthenticationTest : IUserAuthentication
{
    private readonly IADO_Access  aDO_Access;
    
    public UserAuthenticationTest(IADO_Access access) {
        this.aDO_Access = access;
    }
    [Fact]
    //[TestMethod]
    public void Test1()
    {
    }
    //Arrange - Set up the environment for the test - variables, class objects, mock classes
    public async Task<dynamic> User_Login(string username = "Test1", string password = "Pass1")
    {
        //validate username and password to make sure there are no inccoreect entrees
        VerifyAnswers verify = new VerifyAnswers();
        dynamic validater = verify.Verify_API_Form_Data__USERNAME(username, 3, 30);
        if (validater.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return validater; //return the string error message
        }

        validater = verify.Verify_API_Form_Data__PASSWORD(password, 5, 30);
        if (validater.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return validater; //return the string error message
        }




        bool verifiedResult = await CheckIf_UserExists(username);
        if (verifiedResult == false)//If the user does not exist
        {//return 0 | username or pass DNE
            return 0;
        }
        else//the username exists 
        {//try to log in now
            dynamic? loggedUser = await this.aDO_Access.Login_User(username, password);
            if (loggedUser != null)//If the username and password matched and the user was gotten
            {
                return loggedUser;
            }
            return 1;
        }
    }//End of User LOGIN

    public async Task<dynamic> User_Register(UserRegisterDTO user)
    {
        //Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {username} -- UserAuth Class\n");
        VerifyAnswers verify = new VerifyAnswers();

        //Check if form data is good by validating data
        dynamic verified = verify.Verify_API_Form_Data__USERNAME(user.Username, 3, 30);
        if (verified.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return verified; //return the string error message
        }

        verified = verify.Verify_API_Form_Data__PASSWORD(user.Password, 5, 50);
        if (verified.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return verified; //return the string error message
        }

        verified = verify.Verify_API_Form_Data__EMAILS(user.Email, 5, 30);
        if (verified.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return verified; //return the string error message
        }

        verified = verify.Verify_API_Form_Data__StringsONLY(user.First, 0, 30);
        if (verified.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return verified; //return the string error message
        }

        verified = verify.Verify_API_Form_Data__StringsONLY(user.Last, 0, 30);
        if (verified.GetType() == typeof(bool)) //if verification was a success boolean
        {
            Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
        }
        else// if the verification was not a bool but an error string
        {
            return verified; //return the string error message
        }
        dynamic? newUser = null;
        if (user.Role.ToString() == "User")
        {
            newUser = new User(
               Guid.NewGuid(),
               user.Username,
               user.Password,
               user.First,
               user.Last,
               user.Email,
               user.Role,
               DateTime.Now
               );
        }
        else
        {
            newUser = new Admin(
               Guid.NewGuid(),
               user.Username,
               user.Password,
               user.First,
               user.Last,
               user.Email,
               user.Role,
               DateTime.Now
               );
        }
        bool verifiedResult = await this.aDO_Access.Register_User(newUser);
        if (verifiedResult == true)//If the user was  saved
        {//return true
            return true;
        }

        return false;//If user was not saved returrn false



    }//End of USER REGISTER

    public async Task<bool> CheckIf_UserExists(string username = "Test1")
    {
        bool check = await this.aDO_Access.CheckFor_User(username);
        if (check == true)
        {
            //its true that the user exists already
            Console.WriteLine($"\n\n\t\t{username} already exists -- Check if Exists -- UserAuth - BL\n");
            return true;
        }
        else
        {
            //the user does not exists
            Console.WriteLine($"\n\n\t\t{username} does not exist -- Check If Exists -- UserAuth - BL\n");
            return false;
        }
    }





    //Act - Do the action that invokes the method under test(MoT) and get the result if necessary


    //Assert - compare the expected result with the actual result of the "act" action
}
