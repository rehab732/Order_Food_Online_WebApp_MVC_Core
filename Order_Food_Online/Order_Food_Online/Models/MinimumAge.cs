using System.ComponentModel.DataAnnotations;

namespace Order_Food_Online.Models
{
    public class MinimumAge : ValidationAttribute
    {
        int val1, val2;
        public MinimumAge(int num1, int num2)
        {
            val1 = num1;
            val2 = num2;

        }
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj is int)
                {
                    int suppval = (int)obj;
                    if (suppval > val1 && suppval < val2)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = $"Your Age Must Be Between This Range ( {val1},{val2})";
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
