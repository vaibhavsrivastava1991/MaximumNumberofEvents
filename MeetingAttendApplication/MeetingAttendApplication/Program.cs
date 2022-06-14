using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingAttendApplication
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public int StartAt { get; set; }
        public int EndAt { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> startingTimes = new List<int>() { 1, 2, 1 };
            List<int> endingTimes = new List<int>() { 1, 2, 2 };
            List<Meeting> meetings = new List<Meeting>();
            int totalMeeting = startingTimes.Count;

            for (int i = 0; i < totalMeeting; i++)
            {
                meetings.Add(new Meeting
                {
                    MeetingId = i+1,
                    StartAt = startingTimes[i],
                    EndAt = endingTimes[i]
                });
            }

            meetings = meetings.OrderBy(s => s.EndAt).ToList();
            int lastMeetingEndAt = -1;
            List<Meeting> attendingMeetings = new List<Meeting>();

            foreach (var eachMeeting in meetings)
            {
                if (lastMeetingEndAt <= -1 || eachMeeting.StartAt > lastMeetingEndAt)
                {
                    attendingMeetings.Add(eachMeeting);
                    lastMeetingEndAt = eachMeeting.EndAt;
                }
            }

            foreach (var meetinAttend in attendingMeetings)
            {
                Console.WriteLine("MeetingId: " + meetinAttend.MeetingId + " Meeting Start At: " + meetinAttend.StartAt + " Meeting End At: " + meetinAttend.EndAt);

            }

            Console.WriteLine("No. of meeting person can attend: "+ attendingMeetings.Count);
            Console.ReadLine();
            // Console.WriteLine("Hello World!");
        }
    }
}
