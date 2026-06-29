using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrics
{
    public partial class Form2 : Form
    {
        private DateTime _lastCpuTime;
        private TimeSpan _lastTotalProcessorTime;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ProcessSnapshot snapshot)
        {
            InitializeComponent();
            UpdateCPU(snapshot.RawProcces);
        }

        public void UpdateCPU(Process process)
        {
            var currentTime = DateTime.UtcNow;
            var currentProcessorTime = process.TotalProcessorTime;

            double cpuUsed = (currentProcessorTime - _lastTotalProcessorTime).TotalMilliseconds;
            double elapsed = (currentTime - _lastCpuTime).TotalMilliseconds;

            float cpuPercent = (float)(cpuUsed / (elapsed * Environment.ProcessorCount) * 100);

            _lastCpuTime = currentTime;
            _lastTotalProcessorTime = currentProcessorTime;

            label1.Text = cpuPercent.ToString();
        }
    }
}
