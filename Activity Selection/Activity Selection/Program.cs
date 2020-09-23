using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Activity_Selection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Activity(1,5),
                new Activity(3,12),
                new Activity(0,7),
                new Activity(5,8),
                new Activity(3,4),
                new Activity(5,9),
                new Activity(6,15),
                new Activity(8,9),
                new Activity(8,10),
                new Activity(2,6),
                new Activity(12,14)
            };
            activities = activities.OrderBy(x => x.Finish).ToList();

            List<Activity> selectedActivities = new List<Activity>();

            Activity currentActivity = activities[0];
            selectedActivities.Add(currentActivity);
            while(activities.Count > 0)
            { 
                if(activities[0].Start < currentActivity.Finish)
                {
                    activities.RemoveAt(0);
                }
                else
                {
                    currentActivity = activities[0];
                    selectedActivities.Add(currentActivity);
                }                
            }

            foreach(var activity in selectedActivities)
            {
                Console.WriteLine($"{activity.Start} - {activity.Finish}");
            }
        }
    }


    public class Activity
    {
        public Activity(int start, int finish)
        {
            this.Start = start;
            this.Finish = finish;
        }

        public int Start { get; set; }
        public int Finish { get; set; }
    }
}
