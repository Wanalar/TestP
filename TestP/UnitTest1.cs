using Microsoft.VisualBasic;
using SF2022User01Lib;

namespace TestP
{
    public class Tests
    {
        Calculations calculations;
        [SetUp]
        public void Setup()
        {
            calculations = new Calculations();
        }

        [Test]
        public void TestComparisonOfIncomingAndOutgoingParameters30Min()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             "08:30 - 09:00",
                                             "09:00 - 09:30",
                                             "09:30 - 10:00",
                                             "11:30 - 12:00",
                                             "12:00 - 12:30",
                                             "12:30 - 13:00",
                                             "13:00 - 13:30",
                                             "13:30 - 14:00",
                                             "14:00 - 14:30",
                                             "14:30 - 15:00",
                                             "15:40 - 16:10",
                                             "16:10 - 16:40",
                                             "17:30 - 18:00"};
            Assert.AreEqual(result, strings);
        }

        [Test]
        public void TestComparisonOfIncomingAndOutgoingParameters45Min()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 45;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:45",
                                             "08:45 - 09:30",
                                             "11:30 - 12:15",
                                             "12:15 - 13:00",
                                             "13:00 - 13:45",
                                             "13:45 - 14:30",
                                             "15:40 - 16:25",
                                            };
            Assert.AreEqual(result, strings);
        }
        [Test]
        public void TestConsultationTimeLess0()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = -30;

            Assert.Throws<ArgumentException>( () => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestDurationsLess0()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 0, 0, 0, 0, 0 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        [Test]
        public void TestBeginWorkingTimeMoreEndWorkingTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(18, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 0, 0);
            int consultationTime = 30;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestArgumentMatchesTimeSpanMoreDuration()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0),new TimeSpan(11,30,0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 45;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        [Test]
        public void TestArgumentMatchesDurationMoreTimeSpan()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10,40, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 45;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        [Test]
        public void TestErrorFree()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            Assert.DoesNotThrow(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        [Test]
        public void TestConsultationTime600Min()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 600;
           
                                           
        Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void TestMissingPeriods()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] {"08:00 - 08:30",
                                             
                                             "09:00 - 09:30",
                                             
                                             "11:30 - 12:00",
                                             
                                             "12:30 - 13:00",
                                             
                                             "13:30 - 14:00",
                                             
                                             "14:30 - 15:00",
                                             
                                             "16:10 - 16:40",
                                             };
            Assert.That(strings, Is.Not.EqualTo(result));
        }
    }
}