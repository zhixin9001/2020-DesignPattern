
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Timers;

namespace MetricsCollector
{

    public class Metrics
    {
        // Map的key是接口名称，value对应接口请求的响应时间或时间戳；
        private Dictionary<string, List<double>> responseTimes = new Dictionary<string, List<double>>();
        private Dictionary<string, List<double>> timeStamps = new Dictionary<string, List<double>>();
        private Timer timer = new Timer();

        public void recordResponseTime(string apiName, double responseTime)
        {
            responseTimes.TryAdd(apiName, new List<double>());
            responseTimes[apiName].Add(responseTime);
        }

        public void recordTimestamp(String apiName, double timestamp)
        {
            timeStamps.TryAdd(apiName, new List<double>());
            timeStamps[apiName].Add(timestamp);
        }

        public void startRepeatedReport(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += test;
            timer.Start();
        }

        public void test(object sender, ElapsedEventArgs e)
        {
            Dictionary<string, Dictionary<string, double>> stats = new Dictionary<string, Dictionary<string, double>>();
            foreach (var entry in responseTimes)
            {
                string apiName = entry.Key;
                List<double> apiRespTimes = entry.Value;
                stats.TryAdd(apiName, new Dictionary<string, double>());
                stats[apiName].Add("max", max(apiRespTimes));
                stats[apiName].Add("avg", avg(apiRespTimes));
            }

            foreach (var entry in timeStamps)
            {
                string apiName = entry.Key;
                List<double> apiTimestamps = entry.Value;
                stats.TryAdd(apiName, new Dictionary<string, double>());
                stats[apiName].Add("count", (double)apiTimestamps.Count);
            }
            Console.WriteLine(JsonSerializer.Serialize(stats));
        }

        private double max(List<Double> dataset)
        {//省略代码实现
        }
        private double avg(List<Double> dataset)
        {//省略代码实现
        }

    }
}