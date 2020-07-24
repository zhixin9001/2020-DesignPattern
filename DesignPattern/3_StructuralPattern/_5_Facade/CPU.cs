using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Facade
{
    public class SubSystemBase
    {
        private string SubsystemName { get; set; }
        public SubSystemBase(string subsystemName)
        {
            this.SubsystemName = subsystemName;
        }
        public void Startup()
        {
            Console.WriteLine($"{this.SubsystemName} startup");
        }

        public void Shutdown()
        {
            Console.WriteLine($"{this.SubsystemName} shutdown");
        }

    }
    public class CPU : SubSystemBase
    {
        public CPU() : base("CPU") { }
    }

    public class Disk : SubSystemBase
    {
        public Disk() : base("Disk") { }
    }

    public class Memory : SubSystemBase
    {
        public Memory() : base("Memory") { }
    }

    //外观模式提供的统一接口
    public class ComputerFacade
    {
        CPU cpu = new CPU();
        Disk disk = new Disk();
        Memory memory = new Memory();

        public void Startup()
        {
            cpu.Startup();
            disk.Startup();
            memory.Startup();
        }

        public void Shutdown()
        {
            cpu.Shutdown();
            disk.Shutdown();
            memory.Shutdown();
        }
    }
}
