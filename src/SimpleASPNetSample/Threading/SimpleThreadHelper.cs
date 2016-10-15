﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Threading
{
    public static class SimpleThreadHelper
    {
        private static readonly Action<Task> DefaultErrorContination =
        t =>
        {
            try { t.Wait(); }
            catch { }
        };

        public static void Run(Action action, Action<Exception> handler = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var task = Task.Run(action);  // Adapt as necessary for .NET 4.0.

            if (handler == null)
            {
                task.ContinueWith(
                    DefaultErrorContination,
                    TaskContinuationOptions.ExecuteSynchronously |
                    TaskContinuationOptions.NotOnRanToCompletion);
            }
            else
            {
                task.ContinueWith(
                    t => handler(t.Exception.GetBaseException()),
                    TaskContinuationOptions.ExecuteSynchronously |
                    TaskContinuationOptions.NotOnRanToCompletion);
            }
        }
    }
}
