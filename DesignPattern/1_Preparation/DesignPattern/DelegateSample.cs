using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _1_LauguageCharacter
{
    public class DelegateSample
    {
        public IList<string> Output { get; set; } = new List<string>();
        public DelegateSample()
        {
            Timer slowTimer = new Timer(new TimerCallback(OnTimerInterval), "slow", 2500, 2500);
            Timer fastTimer = new Timer(new TimerCallback(OnTimerInterval), "fast", 2000, 2000);
            Output.Add("method");
        }

        private void OnTimerInterval(object state)
        {
            Output.Add(state as string);
        }

    }
}
