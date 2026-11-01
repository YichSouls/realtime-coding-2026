class CompareVersionNumbersTests
{
    private readonly CompareVersionNumbers _solution = new CompareVersionNumbers();

    public void RunAll()
    {
        // --- Official examples ---
        RunTest("Example 1: Leading zeros are equivalent",
            version1: "1.01",   version2: "1.001",  expected: 0);

        RunTest("Example 2: Missing revision treated as 0",
            version1: "1.0",    version2: "1.0.0",  expected: 0);

        RunTest("Example 3: First revision smaller",
            version1: "0.1",    version2: "1.1",    expected: -1);

        RunTest("Example 4: Extra non-zero trailing revision",
            version1: "1.0.1",  version2: "1",      expected: 1);

        RunTest("Example 5: Differs at third revision",
            version1: "7.5.2.4", version2: "7.5.3", expected: -1);

        // --- Test cases ---
        RunTest("Test 1: Equal simple versions",
            version1: "1",              version2: "1",           expected: 0);

        RunTest("Test 2: Leading zeros",
            version1: "01.002.0003",    version2: "1.2.3",       expected: 0);

        RunTest("Test 3: Missing trailing zero revisions",
            version1: "2.5",            version2: "2.5.0.0",     expected: 0);

        RunTest("Test 4: Greater major revision (10 > 2)",
            version1: "10.0",           version2: "2.999",        expected: 1);

        RunTest("Test 5: Smaller minor revision",
            version1: "3.4.9",          version2: "3.5.0",        expected: -1);

        RunTest("Test 6: Extra non-zero revision",
            version1: "1.0.0.1",        version2: "1",            expected: 1);

        RunTest("Test 7: Extra zero revisions only",
            version1: "1.0.0.0",        version2: "1",            expected: 0);

        RunTest("Test 8: Revision exceeds int.MaxValue",
            version1: "2147483648.0",   version2: "2147483647.999", expected: 1);

        RunTest("Test 9: Very long leading zeros",
            version1: "000000000000000000000123", version2: "123", expected: 0);

        RunTest("Test 10: Very long revision values",
            version1: "999999999999999999999999", version2: "1000000000000000000000000", expected: -1);
    }

    private void RunTest(string name, string version1, string version2, int expected)
    {
        int result = _solution.CompareVersion(version1, version2);

        bool pass = result == expected;
        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");

        if (!pass)
        {
            Console.WriteLine($"  version1: \"{version1}\"  version2: \"{version2}\"");
            Console.WriteLine($"  Expected: {expected}  Got: {result}");
        }
    }
}