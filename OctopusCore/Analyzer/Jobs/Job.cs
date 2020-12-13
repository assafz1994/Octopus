using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Analyzer.Jobs
{
    public abstract class Job
    {
        public object Result { get; private set; }
        public bool HasExecuted { get; private set; }

        public void Execute()
        {
            Result = ExecuteInternal();

            HasExecuted = true;
        }

        protected abstract object ExecuteInternal();
    }
}