using AspDotNetCoreSignalRWithAngular.Host.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AspDotNetCoreSignalRWithAngular.Host.DataManagers
{
    public static class DataManager
    {
      
        public static List<ChartModel> GetData()
        {
            var r = new Random();
            return new List<ChartModel>()
        {
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data1" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data2" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data3" },
           new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data4" }
        };
        }

        public static CPUUsases GetCPUData(bool isFirstLoad = false)
        {
            int counter = isFirstLoad ? 10 : 1;
            var cpuUsases = new CPUUsases();
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            cpuCounter.NextValue();
            ramCounter.NextValue();

            for (int i = 0; i < counter; i++)
            { 
                cpuUsases.CPUPer.Add(cpuCounter.NextValue());
                cpuUsases.MemoryMb.Add(ramCounter.NextValue());
            }

           // PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", "ACService", true);
            return cpuUsases;
        }
    }

    public class CPUUsases
    {
        public CPUUsases()
        {
            CPUPer = new List<float>();
            MemoryMb = new List<float>();
        }
        public List<float> CPUPer { get; set; }
        public List<float> MemoryMb { get; set; }
    }
}
