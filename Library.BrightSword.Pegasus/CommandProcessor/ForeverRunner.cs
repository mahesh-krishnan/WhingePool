using System;
using System.Threading;

namespace BrightSword.Pegasus.CommandProcessor
{
    public sealed class ForeverRunner
    {
        private const int C_SLEEP_PERIOD_IN_MILLISECONDS = 10000;

        private EventWaitHandle _waitHandle;

        public ForeverRunner(Action action,
                             int periodInMilliseconds = C_SLEEP_PERIOD_IN_MILLISECONDS)
        {
            Action = action;
            PeriodInMilliseconds = periodInMilliseconds;
            AssignWaitHandle();
        }

        public Action Action { get; private set; }

        public int PeriodInMilliseconds { get; private set; }

        private void AssignWaitHandle()
        {
            if (_waitHandle != null)
            {
                throw new NotSupportedException("cannot assign a waithandle again");
            }
            _waitHandle = new AutoResetEvent(true);
        }

        public void Run()
        {
            while (true)
            {
                if (_waitHandle == null)
                {
                    break;
                }

                _waitHandle.WaitOne(PeriodInMilliseconds);

                Action();
            }
        }

        public void Start()
        {
            AssignWaitHandle();
            _waitHandle.Set();
        }

        public void Stop()
        {
            _waitHandle.Reset();
            _waitHandle = null;
        }

        public void Pulse()
        {
            _waitHandle.Set();
        }
    }
}