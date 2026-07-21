class StringAlignment
{
    public int ComputeMinDistance(string str1, string str2)
    {
        int s1Length = str1.Length;
        int s2Length = str2.Length;
        int shiftLeftLimit = -s2Length;
        int shiftRightLimit = s1Length;

        int minDistance = int.MaxValue;
        for (int shift = shiftLeftLimit; shift <= shiftRightLimit; shift++)
        {
            int distance;
            if (shift < 0)
            {
                if (s1Length + Math.Abs(shift) < s2Length)
                {
                    string shiftedStr1 = new string('*', Math.Abs(shift)) + str1 + new string('*', s2Length - (s1Length + Math.Abs(shift)));
                    string shiftedStr2 = str2;
                    distance = ComputeDistance(shiftedStr1, shiftedStr2);
                }
                else
                {
                    string shiftedStr1 = new string('*', Math.Abs(shift)) + str1;
                    string shiftedStr2 = str2 + new string('*', s1Length + Math.Abs(shift) - s2Length);
                    distance = ComputeDistance(shiftedStr1, shiftedStr2);
                }
            }
            else
            {
                if (s1Length > s2Length + shift)
                {
                    string shiftedStr1 = str1 + new string('*', s2Length - (s1Length + shift));
                    string shiftedStr2 = new string('*', shift) + str2;
                    distance = ComputeDistance(shiftedStr1, shiftedStr2);
                }
                else
                {
                    string shiftedStr1 = str1 + new string('*', shift);
                    string shiftedStr2 = new string('*', shift) + str2;
                    distance = ComputeDistance(shiftedStr1, shiftedStr2);
                }
            }

            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }

        return minDistance;
    }

    public int ComputeDistance(string str1, string str2)
    {
        int distance = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                distance++;
            }
        }
        return distance;
    }
}