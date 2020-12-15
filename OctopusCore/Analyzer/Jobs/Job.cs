using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore.Analyzer.Jobs
{
    public abstract class Job
    {
        public object Result { get; private set; }
        public bool HasExecuted { get; private set; }

        public async Task ExecuteAsync()
        {
            Result = await ExecuteInternalAsync();

            HasExecuted = true;
        }

        protected abstract Task<ExecutionResult> ExecuteInternalAsync();
    }
}