class MyCalendarI
{
    public List<(int start, int end)> bookings = new List<(int start, int end)>();

    public bool Book(int start, int end)
    {
        // list of int int for the bookings
        // loop foreach booking
        // if overlap return false
        // else return true and add to the list
        foreach (var booking in bookings)
        {
            if (start < booking.end && end > booking.start)
            {
                return false;
            }
        }
        bookings.Add((start, end));
        return true;
    }
}