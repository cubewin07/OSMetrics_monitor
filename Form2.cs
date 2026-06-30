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
using System.Windows.Forms.Design.Behavior;

namespace Metrics
{
    public partial class Form2 : Form
    {
        private DateTime _lastCpuTime;
        private TimeSpan _lastTotalProcessorTime;
        private int _pid;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ProcessSnapshot snapshot)
        {
            InitializeComponent();
            Render(snapshot);
            _pid = snapshot.PID;
        }

        public void UpdateCPU(Process process)
        {
            // Access denied
            //var currentTime = DateTime.UtcNow;
            //var currentProcessorTime = process.TotalProcessorTime;

            //double cpuUsed = (currentProcessorTime - _lastTotalProcessorTime).TotalMilliseconds;
            //double elapsed = (currentTime - _lastCpuTime).TotalMilliseconds;

            //float cpuPercent = (float)(cpuUsed / (elapsed * Environment.ProcessorCount) * 100);

            //_lastCpuTime = currentTime;
            //_lastTotalProcessorTime = currentProcessorTime;

            var name = process.ProcessName.Split(' ')[0];

            label1.Text = name;
        }

        public void Update(ProcessSnapshot snapshot)
        {
            if (InvokeRequired)
            {
                Invoke(() => Render(snapshot));
            }
            Render(snapshot);
            
        }

        private void Render(ProcessSnapshot snapshot)
        {
            if (snapshot.PID != _pid)
                return;
            label1.Text = snapshot.MemoryMD.ToString();
            label2.Text = snapshot.Name;
            label3.Text = snapshot.PID.ToString();
        }
    }
}
