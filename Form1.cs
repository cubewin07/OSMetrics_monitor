using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Metrics
{
    public partial class Form1 : Form
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PerformanceCounter CpuCounter { get; set; } = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PerformanceCounter RamCounter { get; set; } = new PerformanceCounter("Memory", "Available MBytes");

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedPID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ProcessSnapshot> Psnapshots { get; set; } = [];

        public Form1()
        {
            InitializeComponent();
            Custom();
        }

        public void UpdadingMetrics(Object sender, EventArgs e)
        {
            Process[] current = Process.GetProcesses();

            var snapshot = current.Select(p => new ProcessSnapshot
            {
                Name = p.ProcessName,
                PID = p.Id,
                MemoryMD = p.WorkingSet64 / 1024 / 1024,
                RawProcces = p
            }).ToList();

            Psnapshots = snapshot;

            RefreshList(dataGridView1, Psnapshots);
            MoveBackToSelectedProcess(SelectedPID);

            // CPU
            float cpuCounter = CpuCounter.NextValue();
            progressBar1.Value = (int)Math.Clamp(cpuCounter * 100, 0, 10000);

            //Ram
            float ramCounter = RamCounter.NextValue();
            progressBar2.Value = (int)Math.Clamp(ramCounter * 100, 0, 1600000);

            label1.Text = cpuCounter.ToString();
            label2.Text = RamCounter.NextValue().ToString();

        }
        public static void RefreshList<T>(DataGridView target, List<T> list)
        {
            target.DataSource = null;
            target.DataSource = list;
        }

        public void MoveBackToSelectedProcess(int id)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((int)row.Cells["PID"].Value == id)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int pid = (int)dataGridView1.Rows[e.RowIndex].Cells["PID"].Value;
                if (e.ColumnIndex == dataGridView1.Columns["Kill"].Index)
                {
                    try
                    {
                        Process.GetProcessById(pid).Kill();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                label3.Text = pid.ToString();
                SelectedPID = pid;

            }
        }

        private void ShowingDetail(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int pid = (int)dataGridView1.Rows[e.RowIndex].Cells["PID"].Value;
            var rowProcess = Psnapshots.First(p => p.PID == pid);
            if (rowProcess != null)
            {
                //PUt code here
            }
        }
    }

    public class ProcessSnapshot
    {
        public required string Name { get; set; }
        public int PID { get; set; }
        public float MemoryMD { get; set; }
        public required Process RawProcces { get; set; }
    }
}
