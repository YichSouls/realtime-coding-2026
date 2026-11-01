My Calendar I

Problem Description

Design a calendar that allows a user to book events without creating any overlapping meetings.

Each event is represented by a half-open time interval:

[startTime, endTime)

This means:

* The event starts at startTime.
* The event ends immediately before endTime.
* A new event may start exactly when another event ends.

For example:

[10, 20)
[20, 30)

do not overlap.

Implement a MyCalendar class that supports booking new events.

When a new event is requested:

* Return true if the event does not overlap with any existing event.
* Add the event to the calendar.
* Return false if the event overlaps with an existing event.
* Do not add the event when the booking fails.

⸻

Class Interface

MyCalendar()

Initializes an empty calendar.

bool book(startTime, endTime)

Attempts to add a new event to the calendar.

Parameters

* startTime: the start time of the new event.
* endTime: the end time of the new event.

Return Value

Return:

true

if the event can be added without overlapping an existing event.

Return:

false

if the event overlaps with at least one existing event.

⸻

Constraints

0 <= startTime < endTime <= 1,000,000,000
At most 1000 calls will be made to book.

⸻

Overlap Rule

Two half-open intervals:

[start1, end1)
[start2, end2)

overlap when:

start1 < end2
and
start2 < end1

Equivalent non-overlapping conditions are:

end1 <= start2

or:

end2 <= start1

⸻

Example 1

Input

operations = [
  "MyCalendar",
  "book",
  "book",
  "book"
]
arguments = [
  [],
  [10, 20],
  [15, 25],
  [20, 30]
]

Output

[
  null,
  true,
  false,
  true
]

Explanation

The calendar starts empty.

First booking

book(10, 20)

There are no existing events, so the booking succeeds.

The calendar now contains:

[10, 20)

Return:

true

Second booking

book(15, 25)

This event overlaps with:

[10, 20)

because both events are active between time 15 and time 20.

The event is not added.

Return:

false

Third booking

book(20, 30)

This event starts exactly when the first event ends.

Because the intervals are half-open, the events do not overlap.

The booking succeeds.

Return:

true

⸻

Example 2

Input

operations = [
  "MyCalendar",
  "book",
  "book",
  "book",
  "book"
]
arguments = [
  [],
  [5, 10],
  [10, 15],
  [1, 5],
  [7, 12]
]

Output

[
  null,
  true,
  true,
  true,
  false
]

Explanation

The first three events are:

[5, 10)
[10, 15)
[1, 5)

They touch at their boundaries but do not overlap.

The final event:

[7, 12)

overlaps with both:

[5, 10)
[10, 15)

so it is rejected.

⸻

Example 3

Input

operations = [
  "MyCalendar",
  "book",
  "book",
  "book"
]
arguments = [
  [],
  [20, 30],
  [10, 15],
  [15, 20]
]

Output

[
  null,
  true,
  true,
  true
]

Explanation

The events are booked in an unsorted order.

After all successful bookings, the calendar contains:

[10, 15)
[15, 20)
[20, 30)

None of the events overlap.

⸻

Test Cases

Test Case 1: First Booking

Operations

MyCalendar calendar = new MyCalendar();
calendar.book(10, 20);

Expected Result

true

The calendar is initially empty.

⸻

Test Case 2: Exact Duplicate

Operations

calendar.book(10, 20);
calendar.book(10, 20);

Expected Results

true
false

The second booking overlaps completely with the first.

⸻

Test Case 3: Touching on the Right

Operations

calendar.book(10, 20);
calendar.book(20, 30);

Expected Results

true
true

The second event begins exactly when the first event ends.

⸻

Test Case 4: Touching on the Left

Operations

calendar.book(10, 20);
calendar.book(5, 10);

Expected Results

true
true

The second event ends exactly when the first event begins.

⸻

Test Case 5: Partial Overlap on the Right

Operations

calendar.book(10, 20);
calendar.book(15, 25);

Expected Results

true
false

⸻

Test Case 6: Partial Overlap on the Left

Operations

calendar.book(10, 20);
calendar.book(5, 15);

Expected Results

true
false

⸻

Test Case 7: New Event Inside Existing Event

Operations

calendar.book(10, 30);
calendar.book(15, 20);

Expected Results

true
false

The second event is completely contained inside the first.

⸻

Test Case 8: Existing Event Inside New Event

Operations

calendar.book(15, 20);
calendar.book(10, 30);

Expected Results

true
false

The new event completely contains the existing event.

⸻

Test Case 9: Multiple Non-Overlapping Events

Operations

calendar.book(10, 20);
calendar.book(30, 40);
calendar.book(20, 30);
calendar.book(5, 10);

Expected Results

true
true
true
true

The final calendar contains:

[5, 10)
[10, 20)
[20, 30)
[30, 40)

⸻

Test Case 10: Overlap with One of Several Events

Operations

calendar.book(10, 20);
calendar.book(30, 40);
calendar.book(50, 60);
calendar.book(35, 45);

Expected Results

true
true
true
false

The final event overlaps with:

[30, 40)

⸻

Test Case 11: Event Fits Between Two Existing Events

Operations

calendar.book(10, 20);
calendar.book(30, 40);
calendar.book(20, 30);

Expected Results

true
true
true

The new event fits exactly between the two existing events.

⸻

Test Case 12: Event Does Not Fit Between Two Existing Events

Operations

calendar.book(10, 20);
calendar.book(30, 40);
calendar.book(19, 31);

Expected Results

true
true
false

The new event overlaps with both existing events.

⸻

Test Case 13: Unsorted Bookings

Operations

calendar.book(50, 60);
calendar.book(10, 20);
calendar.book(30, 40);
calendar.book(20, 30);
calendar.book(40, 50);

Expected Results

true
true
true
true
true

The booking requests are not provided in chronological order.

⸻

Test Case 14: Large Time Values

Operations

calendar.book(0, 1000000000);
calendar.book(999999999, 1000000000);

Expected Results

true
false

The second event falls inside the first event.

⸻

Test Case 15: Many Adjacent Events

Operations

calendar.book(0, 10);
calendar.book(10, 20);
calendar.book(20, 30);
calendar.book(30, 40);
calendar.book(40, 50);

Expected Results

true
true
true
true
true

Adjacent half-open intervals do not overlap.

⸻

Important Edge Cases

Consider the following carefully:

* The calendar is initially empty.
* The new event is identical to an existing event.
* The new event is fully inside an existing event.
* The new event fully contains an existing event.
* The new event starts exactly when another event ends.
* The new event ends exactly when another event starts.
* Events are booked in an unsorted order.
* The new event overlaps with only one event among many.
* Time values can be very large.

⸻

Follow-up Questions

1. What is the time complexity of each booking operation if all events are stored in a simple list?
2. What is the total time complexity after making n booking requests?
3. Can you keep the events sorted by start time?
4. If the events are sorted, which existing events must be checked before inserting a new event?
5. Can you use binary search to find the insertion position?
6. What would the time complexity be when using:
    * a simple list,
    * a sorted list,
    * or a balanced binary search tree?
7. How would you implement the solution using a SortedDictionary or another ordered structure?
8. Why are half-open intervals useful for calendar systems?
9. How would your implementation change if touching intervals were considered overlapping?
10. How would you return the conflicting event when a booking fails?
11. How would you support deleting an existing booking?
12. How would you extend the design to allow double bookings but reject triple bookings?
13. How would you make the calendar safe when several users attempt to book events concurrently?
14. How would the solution change if each event also contained a title and an identifier?