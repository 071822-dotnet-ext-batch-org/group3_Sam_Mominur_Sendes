using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VerifyAnswers
    {
        /// <summary>
        /// This method is to verify usernames
        ///
        /// CANNOT HAVE SPECIAL CHARACTERS
        /// MUST BE WITHIN THE MIX AND MAX VALUE
        /// </summary>
        /// <param name="username"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__USERNAME(string username, int responseMin, int responseMax)
        {
            string answer = username;
            string msgLessthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax}\nMAKE ANOTHER RESPONSE";
            string msgGreaterthan = $"\n\n\t\tYour answer '{answer}' cannot be less than {responseMin} or greater than {responseMax} characters\nMAKE ANOTHER RESPONSE";
            string msgEmpty = $"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:";
            string msgSpecialChar = $"\n\n\t\tYour answer '{answer}' cannot have any SPECIAL characters\n\nMAKE ANOTHER RESPONSE";
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
        /// This is a method to verify the form data of a front end api
        /// This takes in a string only response that could be within a min and max length
        /// This response cannot have any number or special characters
        ///
        /// THIS WILL EITHER RETURN A SUCCESS BOOL OR ERROR STRING
        /// </summary>
        /// <param name="strinVal"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__StringsONLY(string strinVal, int responseMin, int responseMax)
        {
            string answer = strinVal;
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
        ///
        /// THIS WILL EITHER RETURN A SUCCESS BOOL OR ERROR STRING
        /// </summary>
        /// <param name="password"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__PASSWORD(string password, int responseMin, int responseMax)
        {
            string answer = password;
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
        ///
        /// THIS WILL EITHER RETURN A SUCCESS BOOL OR ERROR STRING
        /// </summary>
        /// <param name="response"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__LongResponse(string response, int responseMin, int responseMax)
        {
            string answer = response;
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

        /// <summary>
        /// This method is to validate emails
        /// 
        /// THIS WILL EITHER RETURN A SUCCESS BOOL OR ERROR STRING
        /// </summary>
        /// <param name="response"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public dynamic Verify_API_Form_Data__EMAILS(string response, int responseMin, int responseMax)
        {
            string answer = response;
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
                else //If there is no error 
                {
                    return true; //return success bool
                }
            }//End If
        }//End of API Form verification for EMAILS ONLY



    }

}