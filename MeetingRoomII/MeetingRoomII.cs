class MeetingRoomII
{
    public int MinMeetingRooms(int[][] intervals)
    {
        // Sort the intervals by start time
        // Get the start time array and end time array
        // int rooms = 0 
        // for i as number of intervals
        // if start[i] < end[rooms] then rooms++
        // else end[rooms] = end[i]

        if (intervals.Length == 0)
            return 0;

        int n = intervals.Length;
        int[] start = new int[n];
        int[] end = new int[n];

        for (int i = 0; i < n; i++)
        {
            start[i] = intervals[i][0];
            end[i] = intervals[i][1];
        }

        Array.Sort(start);
        Array.Sort(end);

        int rooms = 0;
        int endIndex = 0;

        for (int i = 0; i < n; i++)
        {
            if (start[i] < end[endIndex])
            {
                rooms++;
            }
            else
            {
                endIndex++;
            }
        }

        return rooms;
    }
}