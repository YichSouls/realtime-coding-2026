class MeetingRoomIITests
{
    private readonly MeetingRoomII _solution = new MeetingRoomII();

    public void RunAll()
    {
        // --- Official examples ---
        RunTest("Example 1: Two rooms needed",
            intervals: [[0,30],[5,10],[15,20]],
            expected: 2);

        RunTest("Example 2: No overlap, one room",
            intervals: [[7,10],[2,4]],
            expected: 1);

        RunTest("Example 3: Meetings touch exactly, one room",
            intervals: [[9,10],[10,11],[11,12]],
            expected: 1);

        RunTest("Example 4: All overlap at time 4",
            intervals: [[1,5],[2,6],[3,7],[4,8]],
            expected: 4);

        RunTest("Example 5: Touch boundary reuse",
            intervals: [[1,4],[2,3],[3,6],[5,7]],
            expected: 2);

        // --- Test cases ---
        RunTest("Test 1: No meetings",
            intervals: [],
            expected: 0);

        RunTest("Test 2: Single meeting",
            intervals: [[5,10]],
            expected: 1);

        RunTest("Test 3: Completely separate meetings",
            intervals: [[1,2],[3,4],[5,6]],
            expected: 1);

        RunTest("Test 4: Meetings touch but do not overlap",
            intervals: [[1,3],[3,5],[5,8]],
            expected: 1);

        RunTest("Test 5: All meetings overlap",
            intervals: [[1,10],[2,9],[3,8],[4,7]],
            expected: 4);

        RunTest("Test 6: Unsorted intervals",
            intervals: [[10,20],[0,30],[5,10],[15,25]],
            expected: 3);

        RunTest("Test 7: Room reused multiple times",
            intervals: [[1,4],[2,3],[4,6],[5,7],[7,9]],
            expected: 2);

        RunTest("Test 8: Same start time",
            intervals: [[1,5],[1,3],[1,2]],
            expected: 3);

        RunTest("Test 9: Same end time",
            intervals: [[1,5],[2,5],[3,5]],
            expected: 3);

        RunTest("Test 10: Complex schedule",
            intervals: [[0,10],[5,15],[10,20],[12,18],[15,25],[20,30]],
            expected: 3);

        RunTest("Test 11: Short meetings inside one long meeting",
            intervals: [[0,100],[10,20],[20,30],[30,40],[40,50]],
            expected: 2);

        RunTest("Test 12: Duplicate meetings",
            intervals: [[1,5],[1,5],[1,5]],
            expected: 3);
    }

    private void RunTest(string name, int[][] intervals, int expected)
    {
        int result = _solution.MinMeetingRooms(intervals);

        bool pass = result == expected;
        Console.WriteLine($"[{(pass ? "PASS" : "FAIL")}] {name}");

        if (!pass)
        {
            Console.WriteLine($"  Expected: {expected}  Got: {result}");
            Console.WriteLine($"  Intervals: [{string.Join(", ", intervals.Select(i => $"[{i[0]},{i[1]}]"))}]");
        }
    }
}