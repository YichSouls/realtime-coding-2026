class CompareVersionNumbers
{
    public int CompareVersion(string version1, string version2)
    {
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');

        int length = Math.Max(v1.Length, v2.Length);

        for (int i = 0; i < length; i++)
        {
            int num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
            int num2 = i < v2.Length ? int.Parse(v2[i]) : 0;

            if (num1 > num2) return 1;
            if (num1 < num2) return -1;
        }

        return 0;
    }
}