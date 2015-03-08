namespace TheatreInformationSystem
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> performanceList =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.performanceList.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.performanceList[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.performanceList.Keys;
            return theatres;
        }

        void IPerformanceDatabase.AddPerformance(string theatreName,string performanceName, DateTime startDateTime, 
            TimeSpan duration, decimal price)
        {
            if (!this.performanceList.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var currentTheatrePerformances = this.performanceList[theatreName];
            var endDateTime = startDateTime + duration;
            if (HasOverlappingPerformance(currentTheatrePerformances, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var newPerformance = new Performance(theatreName, performanceName, startDateTime, duration, price); currentTheatrePerformances.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.performanceList.Keys;
            var allPerformances = new List<Performance>();
            foreach (var theatre in theatres)
            {
                var performances = this.performanceList[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        IEnumerable<Performance> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.performanceList.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.performanceList[theatreName];
            return performances;
        }

        protected internal static bool HasOverlappingPerformance(
            IEnumerable<Performance> performances, 
            DateTime startTime, 
            DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var currentPerformanceStartTime = performance.StartDateTime;
                var currentPerformanceEndTime = performance.StartDateTime + performance.Duration;
                var hasOverlapping = 
                  (currentPerformanceStartTime <= startTime && startTime <= currentPerformanceEndTime) ||(currentPerformanceStartTime <= endTime && endTime <= currentPerformanceEndTime) || 
                    (startTime <= currentPerformanceStartTime && currentPerformanceStartTime <= endTime) || 
                    (startTime <= currentPerformanceEndTime && currentPerformanceEndTime <= endTime);

                if (hasOverlapping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
