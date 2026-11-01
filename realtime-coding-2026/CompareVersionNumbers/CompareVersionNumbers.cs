class CompareVersionNumbers
{
    public int CompareVersion(string version1, string version2)
    {
        // split the version into string[]
        // for from 1st version number to max length
        // loop return 1 or -1
        // return 0

        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');

        int length = Math.Max(v1.Length, v2.Length);

        for (int i = 0; i < length; i++)
        {
            string rev1 = GetRevision(v1, i);
            string rev2 = GetRevision(v2, i);

            int cmp = CompareRevisionStrings(rev1, rev2);
            if (cmp != 0)
            {
                return cmp;
            }
        }
        return 0;
    }

    private string GetRevision(string[] arr, int i)
    {
        // if no exist return 0
        // get rid of all the 0 at the begin
        if (i >= arr.Length)
        {
            return "0";
        }

        string trimmed = arr[i].TrimStart('0');
        if (trimmed.Length == 0)
        {
            return "0";
        }
        else
        {
            return trimmed;
        }
    }

    private int CompareRevisionStrings(string a, string b)
    {
        // longer is 1 shorter is -1
        // if same length, loop from 0 to length each char parse int

        if (a.Length > b.Length)
        {
            return 1;
        }

        if (b.Length > a.Length)
        {
            return -1;
        }

        for (int i = 0; i < a.Length; i++)
        {
            int intA = a[i];
            int intB = b[i];

            if (intA > intB)
            {
                return 1;
            }

            if (intA < intB)
            {
                return -1;
            }
        }
        return 0;
    }
}