using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VerifyAnswers
    {
/// <summary>
/// What is your "password".
/// 
/// This takes in how long it can be with min and max int
/// </summary>
/// <param name="responseMin"></param>
/// <param name="responseMax"></param>
/// <returns></returns>
        public static string Verify_String_Answer_for_PASSWORD(int responseMin, int responseMax){
            bool flag = false;
            string? answer = "";
            do{
                Console.WriteLine($"\n\n\t\tWhat is your password?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                if(answer?.Length < responseMin){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE BELOW:");
                    //Task.Delay(2000);
                    continue;
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer?.Length > responseMax){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE BELOW:");
                }else if(answer.Trim() == ""){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(
                    // answer.Contains("!") ||
                    // answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have numbers or special characters.\n\t\t\t\tEXCEPT FOR '@' and '!'\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify_String_Answer


        /// <summary>
        /// 
        /// This is a generic class that takes and validates as string 
        /// The string input returns a console message "What is your {variable}?
        /// 
        /// And prompts the user for a response 
        /// this answer is then validated (between min and max int set by user)
        ///     and cannot contain numbers or special characters
        /// 
        /// 
        /// </summary>
        /// <param name="questionTopic"></param>
        /// <returns></returns>
        public static string Verify_Short_StringOnly_Answer(string questionTopic, int min, int max){
            //bool flag = false;
            string? answer = "";
            do{
                Console.WriteLine($"\n\n\t\tWhat is your {questionTopic}?");
                answer = Console.ReadLine();
                if(answer.Length < min){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {min} or greater than {max} characters\nMAKE ANOTHER RESPONSE BELOW:");
                    //Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");
                    continue;

                }else if(answer.Length > max){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {min} or greater than {max} characters\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else if(answer.Trim() == ""){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(
                    // answer.Contains("0")|| 
                    // answer.Contains("1") ||
                    // answer.Contains("2") ||
                    // answer.Contains("3") ||
                    // answer.Contains("4") ||
                    // answer.Contains("5") ||
                    // answer.Contains("6") ||
                    // answer.Contains("7") ||
                    // answer.Contains("8") ||
                    // answer.Contains("9") ||
                    answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have special characters and must be less than {min} or greater than {max} characters.\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(true);
            //return answer;
        }//End Verify_Short_StringOnly_Answer

        /// <summary>
        /// This method will ask a user to input a string response 
        /// 
        /// The method takes in a string specifying what the user will be asked.
        /// Then 2 min and max integers specifying how long user's response should be.
        /// </summary>
        /// <param name="questionTopic"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public static string? Verify_String_Answer(string questionTopic, int responseMin, int responseMax){
            //bool flag = false;
            string? answer = "";
            do{
                Console.WriteLine($"\n\n\t\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE BELOW:");
                    //Task.Delay(2000);
                    continue;
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE BELOW:");
                }else if(answer.Trim() == ""){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("!") ||
                    // answer.Contains("@") ||
                    answer.Contains("#") ||
                    // answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    // answer.Contains(",") ||
                    // answer.Contains(".") ||
                    // answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have numbers or special characters.\n\t\t\t\tEXCEPT FOR '@', '#', '$', ',', and '.'\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(true);
            return answer;
        }//End Verify_String_Answer

        /// <summary>
        /// This method lets a user input a string value to get an integer response back.
        /// 
        /// This method takes in 2 integer values that specify min and max integeger string length.
        /// </summary>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public static int Verify_SingleString_Answer_FOR_INT(int responseMin, int responseMax){
            //bool flag = false;
            string? answer = "";
            do{
                //Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                answer = answer.ToUpperInvariant();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE BELOW:");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE BELOW:");
                }else if(answer.Trim() == ""){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("Z")|| 
                    answer.Contains("X") ||
                    answer.Contains("C") ||
                    answer.Contains("V") ||
                    answer.Contains("B") ||
                    answer.Contains("N") ||
                    answer.Contains("M") ||
                    answer.Contains("A") ||
                    answer.Contains("S") ||
                    answer.Contains("D") ||
                    answer.Contains("F") ||
                    answer.Contains("G") ||
                    answer.Contains("H") ||
                    answer.Contains("J") ||
                    answer.Contains("K") ||
                    answer.Contains("L") ||
                    answer.Contains("Q") ||
                    answer.Contains("W") ||
                    answer.Contains("E") ||
                    answer.Contains("R") ||
                    answer.Contains("T") ||
                    answer.Contains("Y") ||
                    answer.Contains("U") ||
                    answer.Contains("I") ||
                    answer.Contains("O") ||
                    answer.Contains("P") ||
                    answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have LETTERS or SPECIAL characters\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return Convert.ToInt16(answer.Trim());
                    }
                    // }//End foreach loop
                }//End If
            }while(true);
            //return Convert.ToInt16(answer);
        }//End Verify_SingleString_Answer_FOR_INT

        public static double Verify_String_Answer_FOR_DOUBLE(int responseMin, int responseMax){
            //bool flag = false;
            string? answer = "";
            do{
                //Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                answer = answer.ToUpperInvariant();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE");
                }else if(answer.Trim() == ""){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("Z")|| 
                    answer.Contains("X") ||
                    answer.Contains("C") ||
                    answer.Contains("V") ||
                    answer.Contains("B") ||
                    answer.Contains("N") ||
                    answer.Contains("M") ||
                    answer.Contains("A") ||
                    answer.Contains("S") ||
                    answer.Contains("D") ||
                    answer.Contains("F") ||
                    answer.Contains("G") ||
                    answer.Contains("H") ||
                    answer.Contains("J") ||
                    answer.Contains("K") ||
                    answer.Contains("L") ||
                    answer.Contains("Q") ||
                    answer.Contains("W") ||
                    answer.Contains("E") ||
                    answer.Contains("R") ||
                    answer.Contains("T") ||
                    answer.Contains("Y") ||
                    answer.Contains("U") ||
                    answer.Contains("I") ||
                    answer.Contains("O") ||
                    answer.Contains("P") ||
                    answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    // answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot have LETTERS or SPECIAL characters\n\t\t\tEXCEPT FOR '.'\n\nMAKE ANOTHER RESPONSE");
                    continue;

                    }else{
                        return Convert.ToDouble(answer);
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(true);
            return Convert.ToDouble(answer);;
        }//End Verify for double

        public static bool Verify_StringAnswer_For_Descrition(string strinVal, int responseMin,int responseMax)
        {
            string? answer = strinVal;
            do
            {
                //Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                //answer = Console.ReadLine();
                //answer = answer.ToUpperInvariant();
                if (answer.Length < responseMin)
                {
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE");
                    return false;
                    //Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }
                else if (answer.Length > responseMax)
                {
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE");
                    return false;
                }
                else if (answer.Trim() == "")
                {
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    return false;
                }
                else
                {
                    // foreach(char s in answer.Trim()){
                    if (
                    //answer.Contains("Z") ||
                    //answer.Contains("X") ||
                    //answer.Contains("C") ||
                    //answer.Contains("V") ||
                    //answer.Contains("B") ||
                    //answer.Contains("N") ||
                    //answer.Contains("M") ||
                    //answer.Contains("A") ||
                    //answer.Contains("S") ||
                    //answer.Contains("D") ||
                    //answer.Contains("F") ||
                    //answer.Contains("G") ||
                    //answer.Contains("H") ||
                    //answer.Contains("J") ||
                    //answer.Contains("K") ||
                    //answer.Contains("L") ||
                    //answer.Contains("Q") ||
                    //answer.Contains("W") ||
                    //answer.Contains("E") ||
                    //answer.Contains("R") ||
                    //answer.Contains("T") ||
                    //answer.Contains("Y") ||
                    //answer.Contains("U") ||
                    //answer.Contains("I") ||
                    //answer.Contains("O") ||
                    //answer.Contains("P") ||
                    //answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    //answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    //answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    //answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    //answer.Contains(",") ||
                    // answer.Contains(".") ||
                    //answer.Contains("?") ||
                    answer.Contains("/"))
                    {
                        //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                        Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot have SPECIAL characters\n\t\t\tEXCEPT FOR (. , $ + ' ? !) \n\nMAKE ANOTHER RESPONSE");
                        return false;

                    }
                    else
                    {
                        return true;
                    }
                    // }//End foreach loop
                    return false;
                }//End If
                //return "";
            } while (true);
            //return false;

        }//End of Description Verification

        /// <summary>
        /// This is a method to verify the form data of a front end api
        /// This takes in a string only response that could be within a min and max length
        /// This response cannot have any number or special characters
        /// </summary>
        /// <param name="strinVal"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__StringsONLY(string strinVal, int responseMin, int responseMax)
        {
            string? answer = strinVal;
            string msgLessthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE";
            string msgGreaterthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE";
            string msgEmpty = $"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:";
            string msgSpecialChar = $"\n\n\t\tYour answer '{answer}' cannot have any numbers or SPECIAL characters\n\nMAKE ANOTHER RESPONSE";
            if (answer.Length < responseMin)
            {
                Console.WriteLine(msgLessthan);
                return msgLessthan;
                //Task.Delay(2000);
                //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

            }
            else if (answer.Length > responseMax)
            {
                Console.WriteLine(msgGreaterthan);
                return msgGreaterthan;
            }
            else if (answer.Trim() == "")
            {
                Console.WriteLine(msgEmpty);
                return msgEmpty;
            }
            else
            {
                // foreach(char s in answer.Trim()){
                if (
                //answer.Contains("Z") ||
                //answer.Contains("X") ||
                //answer.Contains("C") ||
                //answer.Contains("V") ||
                //answer.Contains("B") ||
                //answer.Contains("N") ||
                //answer.Contains("M") ||
                //answer.Contains("A") ||
                //answer.Contains("S") ||
                //answer.Contains("D") ||
                //answer.Contains("F") ||
                //answer.Contains("G") ||
                //answer.Contains("H") ||
                //answer.Contains("J") ||
                //answer.Contains("K") ||
                //answer.Contains("L") ||
                answer.Contains("9") ||
                answer.Contains("8") ||
                answer.Contains("7") ||
                answer.Contains("6") ||
                answer.Contains("5") ||
                answer.Contains("4") ||
                answer.Contains("3") ||
                answer.Contains("2") ||
                answer.Contains("1") ||
                answer.Contains("0") ||
                answer.Contains("!") ||
                answer.Contains("@") ||
                answer.Contains("#") ||
                answer.Contains("$") ||
                answer.Contains("%") ||
                answer.Contains("^") ||
                answer.Contains("&") ||
                answer.Contains("*") ||
                answer.Contains("(") ||
                answer.Contains(")") ||
                answer.Contains("-") ||
                answer.Contains("+") ||
                answer.Contains("=") ||
                answer.Contains("_") ||
                answer.Contains("{") ||
                answer.Contains("}") ||
                answer.Contains("[") ||
                answer.Contains("]") ||
                answer.Contains("|") ||
                answer.Contains(";") ||
                answer.Contains(":") ||
                answer.Contains("'") ||
                answer.Contains("<") ||
                answer.Contains(">") ||
                answer.Contains(",") ||
                answer.Contains(".") ||
                answer.Contains("?") ||
                answer.Contains("/"))
                {
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine(msgSpecialChar);
                    return msgSpecialChar;

                }
                else
                {
                    return true;
                }
            }//End If
        }//End of API Form verification for STRINGS ONLY

        /// <summary>
        /// This method is specifically for creating a password from an API front end
        /// The response must be withing min and max
        /// Cannot have special characters EXCEPT FOR '_', '@' and '!'
        /// </summary>
        /// <param name="password"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__PASSWORD(string password, int responseMin, int responseMax)
        {
            string? answer = password;
            string msgLessthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE";
            string msgGreaterthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE";
            string msgEmpty = $"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:";
            string msgSpecialChar = $"\n\n\t\tYour answer '{answer}' cannot have any numbers or SPECIAL characters\n\t\t\t\tEXCEPT FOR '_', '@' and '!'\n\nMAKE ANOTHER RESPONSE";
            if (answer.Length < responseMin)
            {
                Console.WriteLine(msgLessthan);
                return msgLessthan;
                //Task.Delay(2000);
                //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

            }
            else if (answer.Length > responseMax)
            {
                Console.WriteLine(msgGreaterthan);
                return msgGreaterthan;
            }
            else if (answer.Trim() == "")
            {
                Console.WriteLine(msgEmpty);
                return msgEmpty;
            }
            else
            {
                // foreach(char s in answer.Trim()){
                if (
                //answer.Contains("Z") ||
                //answer.Contains("X") ||
                //answer.Contains("C") ||
                //answer.Contains("V") ||
                //answer.Contains("B") ||
                //answer.Contains("N") ||
                //answer.Contains("M") ||
                //answer.Contains("A") ||
                //answer.Contains("S") ||
                //answer.Contains("D") ||
                //answer.Contains("F") ||
                //answer.Contains("G") ||
                //answer.Contains("H") ||
                //answer.Contains("J") ||
                //answer.Contains("K") ||
                //answer.Contains("L") ||
                //answer.Contains("9") ||
                //answer.Contains("8") ||
                //answer.Contains("7") ||
                //answer.Contains("6") ||
                //answer.Contains("5") ||
                //answer.Contains("4") ||
                //answer.Contains("3") ||
                //answer.Contains("2") ||
                //answer.Contains("1") ||
                //answer.Contains("0") ||
                //answer.Contains("!") ||
                //answer.Contains("@") ||
                answer.Contains("#") ||
                answer.Contains("$") ||
                answer.Contains("%") ||
                answer.Contains("^") ||
                answer.Contains("&") ||
                answer.Contains("*") ||
                answer.Contains("(") ||
                answer.Contains(")") ||
                answer.Contains("-") ||
                answer.Contains("+") ||
                answer.Contains("=") ||
                //answer.Contains("_") ||
                answer.Contains("{") ||
                answer.Contains("}") ||
                answer.Contains("[") ||
                answer.Contains("]") ||
                answer.Contains("|") ||
                answer.Contains(";") ||
                answer.Contains(":") ||
                answer.Contains("'") ||
                answer.Contains("<") ||
                answer.Contains(">") ||
                answer.Contains(",") ||
                answer.Contains(".") ||
                answer.Contains("?") ||
                answer.Contains("/"))
                {
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine(msgSpecialChar);
                    return msgSpecialChar;

                }
                else
                {
                    return true;
                }
            }//End If
        }//End of API Form verification for PASSWORD ONLY

        /// <summary>
        /// This is a method to verify long formed user responses
        /// This response must be within the min and max
        /// This response cannot have special characters EXCEPT FOR '_', '@' and '!'
        /// </summary>
        /// <param name="response"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__LongResponse(string response, int responseMin, int responseMax)
        {
            string? answer = response;
            string msgLessthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE";
            string msgGreaterthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE";
            string msgEmpty = $"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:";
            string msgSpecialChar = $"\n\n\t\tYour answer '{answer}' cannot have any SPECIAL characters\n\t\t\t\tEXCEPT FOR '_', '@' and '!'\n\nMAKE ANOTHER RESPONSE";
            if (answer.Length < responseMin)
            {
                Console.WriteLine(msgLessthan);
                return msgLessthan;
                //Task.Delay(2000);
                //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

            }
            else if (answer.Length > responseMax)
            {
                Console.WriteLine(msgGreaterthan);
                return msgGreaterthan;
            }
            else if (answer.Trim() == "")
            {
                Console.WriteLine(msgEmpty);
                return msgEmpty;
            }
            else
            {
                // foreach(char s in answer.Trim()){
                if (
                //answer.Contains("Z") ||
                //answer.Contains("X") ||
                //answer.Contains("C") ||
                //answer.Contains("V") ||
                //answer.Contains("B") ||
                //answer.Contains("N") ||
                //answer.Contains("M") ||
                //answer.Contains("A") ||
                //answer.Contains("S") ||
                //answer.Contains("D") ||
                //answer.Contains("F") ||
                //answer.Contains("G") ||
                //answer.Contains("H") ||
                //answer.Contains("J") ||
                //answer.Contains("K") ||
                //answer.Contains("L") ||
                //answer.Contains("9") ||
                //answer.Contains("8") ||
                //answer.Contains("7") ||
                //answer.Contains("6") ||
                //answer.Contains("5") ||
                //answer.Contains("4") ||
                //answer.Contains("3") ||
                //answer.Contains("2") ||
                //answer.Contains("1") ||
                //answer.Contains("0") ||
                //answer.Contains("!") ||
                //answer.Contains("@") ||
                answer.Contains("#") ||
                answer.Contains("$") ||
                answer.Contains("%") ||
                answer.Contains("^") ||
                answer.Contains("&") ||
                answer.Contains("*") ||
                answer.Contains("(") ||
                answer.Contains(")") ||
                answer.Contains("-") ||
                answer.Contains("+") ||
                answer.Contains("=") ||
                //answer.Contains("_") ||
                answer.Contains("{") ||
                answer.Contains("}") ||
                answer.Contains("[") ||
                answer.Contains("]") ||
                answer.Contains("|") ||
                answer.Contains(";") ||
                answer.Contains(":") ||
                answer.Contains("'") ||
                answer.Contains("<") ||
                answer.Contains(">") ||
                answer.Contains(",") ||
                answer.Contains(".") ||
                answer.Contains("?") ||
                answer.Contains("/"))
                {
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine(msgSpecialChar);
                    return msgSpecialChar;

                }
                else
                {
                    return true;
                }
            }//End If
        }//End of API Form verification for LONG-formed RESPONSES ONLY

        public dynamic Verify_API_Form_Data__EMAILS(string response, int responseMin, int responseMax)
        {
            string? answer = response;
            string msgLessthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE";
            string msgGreaterthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE";
            string msgEmpty = $"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:";
            string msgSpecialChar = $"\n\n\t\tYour answer '{answer}' cannot have any SPECIAL characters\n\t\t\t\tEXCEPT FOR '.' and '@'\n\nMAKE ANOTHER RESPONSE";
            if (answer.Length < responseMin)
            {
                Console.WriteLine(msgLessthan);
                return msgLessthan;
                //Task.Delay(2000);
                //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

            }
            else if (answer.Length > responseMax)
            {
                Console.WriteLine(msgGreaterthan);
                return msgGreaterthan;
            }
            else if (answer.Trim() == "")
            {
                Console.WriteLine(msgEmpty);
                return msgEmpty;
            }
            else
            {
                // foreach(char s in answer.Trim()){
                if (
                //answer.Contains("Z") ||
                //answer.Contains("X") ||
                //answer.Contains("C") ||
                //answer.Contains("V") ||
                //answer.Contains("B") ||
                //answer.Contains("N") ||
                //answer.Contains("M") ||
                //answer.Contains("A") ||
                //answer.Contains("S") ||
                //answer.Contains("D") ||
                //answer.Contains("F") ||
                //answer.Contains("G") ||
                //answer.Contains("H") ||
                //answer.Contains("J") ||
                //answer.Contains("K") ||
                //answer.Contains("L") ||
                //answer.Contains("9") ||
                //answer.Contains("8") ||
                //answer.Contains("7") ||
                //answer.Contains("6") ||
                //answer.Contains("5") ||
                //answer.Contains("4") ||
                //answer.Contains("3") ||
                //answer.Contains("2") ||
                //answer.Contains("1") ||
                //answer.Contains("0") ||
                answer.Contains("!") ||
                //answer.Contains("@") ||
                answer.Contains("#") ||
                answer.Contains("$") ||
                answer.Contains("%") ||
                answer.Contains("^") ||
                answer.Contains("&") ||
                answer.Contains("*") ||
                answer.Contains("(") ||
                answer.Contains(")") ||
                answer.Contains("-") ||
                answer.Contains("+") ||
                answer.Contains("=") ||
                answer.Contains("_") ||
                answer.Contains("{") ||
                answer.Contains("}") ||
                answer.Contains("[") ||
                answer.Contains("]") ||
                answer.Contains("|") ||
                answer.Contains(";") ||
                answer.Contains(":") ||
                answer.Contains("'") ||
                answer.Contains("<") ||
                answer.Contains(">") ||
                answer.Contains(",") ||
                //answer.Contains(".") ||
                answer.Contains("?") ||
                answer.Contains("/"))
                {
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine(msgSpecialChar);
                    return msgSpecialChar;

                }
                else
                {
                    return true;
                }
            }//End If
        }//End of API Form verification for EMAILS ONLY



    }
}