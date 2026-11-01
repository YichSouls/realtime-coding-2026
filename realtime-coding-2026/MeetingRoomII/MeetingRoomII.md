Meeting Rooms II

Problem Description

You are given a list of meeting time intervals.

Each interval is represented by two integers:

[startTime, endTime]

where:

* startTime is the time when the meeting begins.
* endTime is the time when the meeting ends.
* startTime < endTime.

A meeting room can host only one meeting at a time.

Two meetings overlap if one meeting starts before another meeting has ended.

However, if one meeting ends at the exact time another meeting starts, the same room can be reused.

For example:

[9, 10]
[10, 11]

do not overlap.

Return the minimum number of meeting rooms required to schedule all meetings without conflicts.

⸻

Function Signature

minMeetingRooms(intervals)

Parameters

* intervals: an array of meeting intervals.
* Each interval contains exactly two integers:

[startTime, endTime]

Return Value

Return an integer representing the minimum number of meeting rooms required.

⸻

Constraints

0 <= intervals.length <= 100000
intervals[i].length == 2
0 <= intervals[i][0] < intervals[i][1] <= 1000000

The intervals are not guaranteed to be sorted.

⸻

Example 1

Input

intervals = [
  [0, 30],
  [5, 10],
  [15, 20]
]

Output

2

Explanation

The meeting [0, 30] overlaps with both [5, 10] and [15, 20].

However, [5, 10] and [15, 20] do not overlap.

One possible room assignment is:

Room 1: [0, 30]
Room 2: [5, 10], [15, 20]

Therefore, two meeting rooms are required.

⸻

Example 2

Input

intervals = [
  [7, 10],
  [2, 4]
]

Output

1

Explanation

The meetings do not overlap, so the same room can be reused.

⸻

Example 3

Input

intervals = [
  [9, 10],
  [10, 11],
  [11, 12]
]

Output

1

Explanation

Each meeting starts exactly when the previous meeting ends.

Because a room becomes available at the meeting’s end time, all meetings can use the same room.

⸻

Example 4

Input

intervals = [
  [1, 5],
  [2, 6],
  [3, 7],
  [4, 8]
]

Output

4

Explanation

At time 4, all four meetings are active.

Therefore, four rooms are required.

⸻

Example 5

Input

intervals = [
  [1, 4],
  [2, 3],
  [3, 6],
  [5, 7]
]

Output

2

Explanation

The maximum number of meetings running at the same time is two.

A possible room assignment is:

Room 1: [1, 4], [5, 7]
Room 2: [2, 3], [3, 6]

The meeting [2, 3] ends exactly when [3, 6] starts, so the same room can be reused.

⸻

Test Cases

Test Case 1: No Meetings

Input

intervals = []

Expected Output

0

⸻

Test Case 2: One Meeting

Input

intervals = [
  [5, 10]
]

Expected Output

1

⸻

Test Case 3: Completely Separate Meetings

Input

intervals = [
  [1, 2],
  [3, 4],
  [5, 6]
]

Expected Output

1

⸻

Test Case 4: Meetings Touch but Do Not Overlap

Input

intervals = [
  [1, 3],
  [3, 5],
  [5, 8]
]

Expected Output

1

⸻

Test Case 5: All Meetings Overlap

Input

intervals = [
  [1, 10],
  [2, 9],
  [3, 8],
  [4, 7]
]

Expected Output

4

⸻

Test Case 6: Unsorted Intervals

Input

intervals = [
  [10, 20],
  [0, 30],
  [5, 10],
  [15, 25]
]

Expected Output

3

Explanation

At time 15, the following meetings are active:

[0, 30]
[10, 20]
[15, 25]

Therefore, three rooms are required.

⸻

Test Case 7: Reuse a Room Multiple Times

Input

intervals = [
  [1, 4],
  [2, 3],
  [4, 6],
  [5, 7],
  [7, 9]
]

Expected Output

2

⸻

Test Case 8: Same Start Time

Input

intervals = [
  [1, 5],
  [1, 3],
  [1, 2]
]

Expected Output

3

All meetings begin at the same time, so each one requires a separate room.

⸻

Test Case 9: Same End Time

Input

intervals = [
  [1, 5],
  [2, 5],
  [3, 5]
]

Expected Output

3

⸻

Test Case 10: Complex Schedule

Input

intervals = [
  [0, 10],
  [5, 15],
  [10, 20],
  [12, 18],
  [15, 25],
  [20, 30]
]

Expected Output

3

Explanation

The maximum number of simultaneously active meetings is three.

For example, between time 12 and 15, these meetings are active:

[5, 15]
[10, 20]
[12, 18]

⸻

Test Case 11: Short Meetings Inside a Long Meeting

Input

intervals = [
  [0, 100],
  [10, 20],
  [20, 30],
  [30, 40],
  [40, 50]
]

Expected Output

2

The long meeting occupies one room, while all short meetings can reuse a second room.

⸻

Test Case 12: Duplicate Meetings

Input

intervals = [
  [1, 5],
  [1, 5],
  [1, 5]
]

Expected Output

3

⸻

Important Edge Cases

Consider the following cases carefully:

* The input is empty.
* The input contains only one meeting.
* The meetings are not sorted.
* One meeting ends exactly when another begins.
* Several meetings have the same start time.
* Several meetings have the same end time.
* One long meeting contains many shorter meetings.
* All meetings overlap.
* No meetings overlap.

⸻

Follow-up Questions

1. What is the time complexity of your solution?
2. What is the space complexity?
3. Can you solve the problem using a min-heap?
4. What should the heap store?
5. Why is the earliest ending meeting the most important one?
6. Can you solve the problem by sorting all start times and end times separately?
7. What are the trade-offs between:
    * the min-heap approach,
    * and the two-pointer approach?
8. How would you return the actual room assignment instead of only the number of rooms?
9. How would your solution change if meetings required a ten-minute cleanup period after they ended?
10. How would you process meetings if they arrived one at a time as a stream?
11. Could this problem be solved without sorting?
12. How would the solution change if ending and starting at the same time counted as an overlap?