class TextJustificationTests
{
    private readonly TextJustification _solution = new TextJustification();

    public void RunAll()
    {
        // --- Official examples ---
        RunTest("Example 1: Even space distribution",
            words: ["This", "is", "an", "example", "of", "text", "justification."],
            maxWidth: 16,
            expected: ["This    is    an", "example  of text", "justification.  "]);

        RunTest("Example 2: Single-word line",
            words: ["What", "must", "be", "acknowledgment", "shall", "be"],
            maxWidth: 16,
            expected: ["What   must   be", "acknowledgment  ", "shall be        "]);

        RunTest("Example 3: Large input",
            words: ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"],
            maxWidth: 20,
            expected: ["Science  is  what we", "understand      well", "enough to explain to", "a  computer.  Art is", "everything  else  we", "do                  "]);

        // --- Edge cases ---
        RunTest("Test 1: Single word",
            words: ["Hello"],
            maxWidth: 10,
            expected: ["Hello     "]);

        RunTest("Test 2: Two words exact fit (last line, no extra spaces)",
            words: ["Hello", "World"],
            maxWidth: 11,
            expected: ["Hello World"]);

        RunTest("Test 3: Two words, last line left-justified with padding",
            words: ["Hello", "World"],
            maxWidth: 15,
            expected: ["Hello World    "]);

        RunTest("Test 4: Multiple short words across lines",
            words: ["a", "b", "c", "d", "e"],
            maxWidth: 5,
            expected: ["a b c", "d e  "]);

        RunTest("Test 5: Uneven space distribution (extra spaces go left)",
            words: ["Listen", "to", "many", "speak", "to", "a", "few"],
            maxWidth: 15,
            expected: ["Listen  to many", "speak to a few "]);

        RunTest("Test 6: Single-character gap between words",
            words: ["abcdef", "gh", "ij", "klmnop"],
            maxWidth: 10,
            expected: ["abcdef  gh", "ij klmnop "]);

        RunTest("Test 7: Mixed word lengths",
            words: ["a", "bc", "def", "ghij", "k"],
            maxWidth: 8,
            expected: ["a bc def", "ghij k  "]);
    }

    private void RunTest(string name, string[] words, int maxWidth, string[] expected)
    {
        List<string> result = _solution.FullJustify(words, maxWidth);

        bool pass = result.Count == expected.Length &&
                    result.Zip(expected).All(pair => pair.First == pair.Second);

        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");

        if (!pass)
        {
            Console.WriteLine($"  Line count — expected: {expected.Length}, got: {result.Count}");
            int maxLines = Math.Max(expected.Length, result.Count);
            for (int i = 0; i < maxLines; i++)
            {
                string exp = i < expected.Length ? $"\"{expected[i]}\"" : "(missing)";
                string got = i < result.Count   ? $"\"{result[i]}\""   : "(missing)";
                string marker = (i < expected.Length && i < result.Count && expected[i] == result[i]) ? "  " : "✗ ";
                Console.WriteLine($"  {marker}[{i}] expected: {exp}");
                Console.WriteLine($"      got:      {got}");
            }
        }
    }
}