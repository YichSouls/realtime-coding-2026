class MyCalendarITests
{
    public void RunAll()
    {
        // --- Official examples ---
        RunTest("Example 1: Basic overlap",
            bookings: [(10,20),(15,25),(20,30)],
            expected: [true, false, true]);

        RunTest("Example 2: Touching boundaries accepted, later overlap rejected",
            bookings: [(5,10),(10,15),(1,5),(7,12)],
            expected: [true, true, true, false]);

        RunTest("Example 3: Unsorted bookings, all succeed",
            bookings: [(20,30),(10,15),(15,20)],
            expected: [true, true, true]);

        // --- Test cases ---
        RunTest("Test 1: First booking always succeeds",
            bookings: [(10,20)],
            expected: [true]);

        RunTest("Test 2: Exact duplicate rejected",
            bookings: [(10,20),(10,20)],
            expected: [true, false]);

        RunTest("Test 3: Touching on the right",
            bookings: [(10,20),(20,30)],
            expected: [true, true]);

        RunTest("Test 4: Touching on the left",
            bookings: [(10,20),(5,10)],
            expected: [true, true]);

        RunTest("Test 5: Partial overlap on the right",
            bookings: [(10,20),(15,25)],
            expected: [true, false]);

        RunTest("Test 6: Partial overlap on the left",
            bookings: [(10,20),(5,15)],
            expected: [true, false]);

        RunTest("Test 7: New event inside existing event",
            bookings: [(10,30),(15,20)],
            expected: [true, false]);

        RunTest("Test 8: New event contains existing event",
            bookings: [(15,20),(10,30)],
            expected: [true, false]);

        RunTest("Test 9: Multiple non-overlapping events",
            bookings: [(10,20),(30,40),(20,30),(5,10)],
            expected: [true, true, true, true]);

        RunTest("Test 10: Overlap with one of several events",
            bookings: [(10,20),(30,40),(50,60),(35,45)],
            expected: [true, true, true, false]);

        RunTest("Test 11: Event fits exactly between two existing events",
            bookings: [(10,20),(30,40),(20,30)],
            expected: [true, true, true]);

        RunTest("Test 12: Event overlaps with both neighbors",
            bookings: [(10,20),(30,40),(19,31)],
            expected: [true, true, false]);

        RunTest("Test 13: Unsorted bookings all succeed",
            bookings: [(50,60),(10,20),(30,40),(20,30),(40,50)],
            expected: [true, true, true, true, true]);

        RunTest("Test 14: Large time values",
            bookings: [(0,1000000000),(999999999,1000000000)],
            expected: [true, false]);

        RunTest("Test 15: Many adjacent events",
            bookings: [(0,10),(10,20),(20,30),(30,40),(40,50)],
            expected: [true, true, true, true, true]);
    }

    private void RunTest(string name, (int start, int end)[] bookings, bool[] expected)
    {
        MyCalendarI calendar = new MyCalendarI();

        bool pass = true;
        var failures = new List<string>();

        for (int i = 0; i < bookings.Length; i++)
        {
            bool result = calendar.Book(bookings[i].start, bookings[i].end);
            if (result != expected[i])
            {
                pass = false;
                failures.Add($"  book({bookings[i].start}, {bookings[i].end}) → expected {expected[i]}, got {result}");
            }
        }

        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");
        foreach (var f in failures)
            Console.WriteLine(f);
    }
}