using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcapdotNET.Protocols.ICMP;
using PcapdotNET.Protocols.UDP;

namespace ParserForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Element that choise file with current extensions *.cap & *.pcap
        private OpenFileDialog ofd = new OpenFileDialog();

        private void pickfile_Click(object sender, EventArgs e)
        {

            ofd.Filter = "Packet Capture files|*.cap;*.pcap";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filenametextbox.Text = ofd.FileName;
                dataGridView1.Rows.Clear();
                startbutton.Enabled = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
                startbutton.MouseClick += FillTheTableWithParsedFile;
                startbutton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void FillTheTableWithParsedFile(object obj, EventArgs evargs)
        {
            Button _button = (Button) obj;
            var _frame = new UDPParser();
            _frame.FileReader(ofd.FileName);
            for (int i = 0; i < _frame.GetUDPFrameList().Count; ++i)
            {
                dataGridView1.Rows.Add();
                var _currentframe = (UdpFrame)_frame.GetUDPFrameList()[i];
                dataGridView1.Rows[i].Cells["numbercolumn"].Value = i + 1;
                dataGridView1.Rows[i].Cells["protocolcolumn"].Value = _currentframe.GetProtocolName();
                dataGridView1.Rows[i].Cells["sourceipcolumn"].Value = _currentframe.GetSourceIp();
                dataGridView1.Rows[i].Cells["sourceportcolumn"].Value = _currentframe.GetSourcePort();
                dataGridView1.Rows[i].Cells["destinationipcolumn"].Value = _currentframe.GetDestinationIp();
                dataGridView1.Rows[i].Cells["destinationport"].Value = _currentframe.GetDestinationPort();
                dataGridView1.Rows[i].Cells["lengthcolumn"].Value = _currentframe.GetFrameLength();

            }
        }

    }
}
