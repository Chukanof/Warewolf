/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Diagnostics;
using System.Timers;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Instrumentation;

namespace Dev2.Data
{
    public class PulseLogger : IPulseLogger, IDisposable
    {
        internal readonly Timer _timer;

        public PulseLogger(double intervalMs)
        {
            Interval = intervalMs;
            _timer = new Timer(Interval);
            _timer.Elapsed += _timer_Elapsed;       
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dev2Logger.Info(String.Format(@"
    Process Memory Usage(mb): {0}
    Number of Requests: {1} 
    Time Taken(Ms): {2}   
    Uptime: {3}",
                    GC.GetTotalMemory(false) / 10000000,
                    ServerStats.TotalRequests,
                    ServerStats.TotalTime,
                    DateTime.Now - Process.GetCurrentProcess().StartTime), "Warewolf System Data");
            }                
            catch (Exception err)
            {
                Dev2Logger.Warn(err.Message, "Warewolf Warn");
            }
        }

        #region Implementation of IPulseLogger

        public bool Start()
        {
            try
            {
                _timer.Start();
                return true;
            }
            catch(Exception)
            {

                return false;
            }
            
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public double Interval { get; private set; }

        #endregion
    }

    public class PulseTracker : IPulseLogger, IDisposable
    {
        readonly Timer _timer;

        public PulseTracker(double intervalMs)
        {
            Interval = intervalMs;
            _timer = new Timer(Interval);
            _timer.Elapsed += _timer_Elapsed;       
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (WorkflowExecutionWatcher.HasAWorkflowBeenExecuted)
                {                   
                    WorkflowExecutionWatcher.HasAWorkflowBeenExecuted = false;
                }
            }
            catch (Exception err)
            {
                Dev2Logger.Warn(err.Message, "Warewolf Warn");
            }
        }

        #region Implementation of IPulseLogger

        public bool Start()
        {
            try
            {
                _timer.Start();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public double Interval { get; private set; }

        #endregion
    }
}
