using System.Text;

public class OldPhoneTyping
{
    private static readonly string[] Keys =
    {
        " ",     // 0
        "",      // 1
        "abc",   // 2
        "def",   // 3
        "ghi",   // 4
        "jkl",   // 5
        "mno",   // 6
        "pqrs",  // 7
        "tuv",   // 8
        "wxyz"   // 9
    };

    public string Decode(int[] digits)
    {
        var result = new StringBuilder();
        int i = 0;

        while (i < digits.Length)
        {
            int digit = digits[i];
            int count = 0;

            // Count consecutive presses of the same key
            while (i < digits.Length && digits[i] == digit)
            {
                count++;
                i++;
            }

            string letters = Keys[digit];
            if (letters.Length == 0)
            {
                continue;
            }

            // 0 (space) is emitted once per press; letter keys wrap around
            if (digit == 0)
            {
                result.Append(' ', count);
            }
            else
            {
                result.Append(letters[(count - 1) % letters.Length]);
            }
        }

        return result.ToString();
    }
}