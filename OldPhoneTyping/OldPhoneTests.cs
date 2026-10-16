class OldPhoneTypingTests
{
    private readonly OldPhoneTyping _solution = new OldPhoneTyping();

    public void RunAll()
    {
        // --- Official example ---
        RunTest("Example 1: Word \"test\"",
            digits: new[] { 8, 3, 3, 7, 7, 7, 7, 8 }, expected: "test");

        // --- Test cases ---
        RunTest("Test 1: Empty input",
            digits: new int[] { },                    expected: "");

        RunTest("Test 2: Single press",
            digits: new[] { 2 },                      expected: "a");

        RunTest("Test 3: Last letter on a 3-letter key",
            digits: new[] { 2, 2, 2 },                expected: "c");

        RunTest("Test 4: Wrap around after last letter",
            digits: new[] { 2, 2, 2, 2 },             expected: "a");

        RunTest("Test 5: Four-letter key (7 -> s)",
            digits: new[] { 7, 7, 7, 7 },             expected: "s");

        RunTest("Test 6: Four-letter key (9 -> z)",
            digits: new[] { 9, 9, 9, 9 },             expected: "z");

        RunTest("Test 7: Different keys in a row",
            digits: new[] { 2, 3, 4 },                expected: "adg");

        RunTest("Test 8: Word \"dog\"",
            digits: new[] { 3, 6, 6, 6, 4 },          expected: "dog");

        RunTest("Test 9: Word \"hey\"",
            digits: new[] { 4, 4, 3, 3, 9, 9, 9 },    expected: "hey");

        RunTest("Test 10: Space between letters",
            digits: new[] { 4, 4, 0, 4, 4, 4 },       expected: "h i");

        RunTest("Test 11: Multiple spaces",
            digits: new[] { 0, 0 },                   expected: "  ");

        RunTest("Test 12: Key 1 produces nothing",
            digits: new[] { 2, 1, 3 },                expected: "ad");

        RunTest("Test 13: Repeated key without pause merges letters",
            digits: new[] { 2, 2 },                   expected: "b");
    }

    private void RunTest(string name, int[] digits, string expected)
    {
        string result = _solution.Decode(digits);

        bool pass = result == expected;
        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");

        if (!pass)
        {
            Console.WriteLine($"  digits: [{string.Join(", ", digits)}]");
            Console.WriteLine($"  Expected: \"{expected}\"  Got: \"{result}\"");
        }
    }
}