using System;
using System.Runtime.CompilerServices;

[TestFixture]
public class ClockTest
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(61000, Clock.Past(0, 1, 1));
    }
}
public static class Clock
{
    public static int Past(int hours, int minutes, int seconds)
    {
        //#Happy Coding! ^_^

        // var hourMilliseconds = TimeSpan.FromHours(h).TotalMilliseconds;
        // var minuteMilliseconds = TimeSpan.FromMinutes(m).TotalMilliseconds;
        // var secondMilliseconds = TimeSpan.FromSeconds(s).TotalMilliseconds;

        // return (int)(hourMilliseconds + minuteMilliseconds + secondMilliseconds);

        var hTime = TimeUnitFactory(hours).TimeInMilliseconds;
        var mTime = TimeUnitFactory(minutes).TimeInMilliseconds;
        var sTime = TimeUnitFactory(seconds).TimeInMilliseconds;

        return hTime + mTime + sTime;
    }

    private static ITimeUnit TimeUnitFactory(int timeUnitAmount, [CallerArgumentExpression("timeUnitAmount")] string timeUnit = null){
        return timeUnit switch
        {
            "hours" => new HoursTimeUnit(timeUnitAmount),
            "minutes" => new MinutesTimeUnit(timeUnitAmount),
            "seconds" => new SecondsTimeUnit(timeUnitAmount),
            _ => throw new ArgumentException("Must use a variable name of hours, minutes, or seconds when passing to this method.")
        };
    }

    public interface ITimeUnit
    {
        int TimeInMilliseconds { get; }
    }

    private class HoursTimeUnit : ITimeUnit
    {
        private int _timeUnitAmount;

        public int TimeInMilliseconds => (int)(TimeSpan.FromHours(_timeUnitAmount).TotalMilliseconds);
        public HoursTimeUnit(int timeUnitAmount)
        {
            _timeUnitAmount = timeUnitAmount;
        }
    }
    private class MinutesTimeUnit : ITimeUnit
    {
        private int _timeUnitAmount;

        public int TimeInMilliseconds => (int)(TimeSpan.FromMinutes(_timeUnitAmount).TotalMilliseconds);
        public MinutesTimeUnit(int timeUnitAmount)
        {
            _timeUnitAmount = timeUnitAmount;
        }
    }
    private class SecondsTimeUnit : ITimeUnit
    {
        private int _timeUnitAmount;

        public int TimeInMilliseconds => (int)(TimeSpan.FromSeconds(_timeUnitAmount).TotalMilliseconds);
        public SecondsTimeUnit(int timeUnitAmount)
        {
            _timeUnitAmount = timeUnitAmount;
        }
    }
}
