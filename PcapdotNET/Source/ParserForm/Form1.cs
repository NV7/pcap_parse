﻿using System;
using System.Collections;
using System.Windows.Forms;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.Ethernet;
using PcapdotNET.Protocols.ICMP;
using PcapdotNET.Protocols.TCP;
using PcapdotNET.Protocols.UDP;

namespace ParserForm
{
    public partial class Form1 : Form
    {
        // Element that choise file with current extensions *.cap & *.pcap
        private readonly OpenFileDialog ofd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

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

        private void FillTheTableWithParsedFile(object obj, EventArgs evargs)
        {
            var _button = (Button) obj;
            var _frame = new ProtocolChecker();

            _frame.ReadFile(ofd.FileName);
            for (var i = 0; i < _frame.ProtocolList.GetFrameList().Count; ++i)
            {
                dataGridView1.Rows.Add();
                ArrayList LengthOfEachFrame = _frame.ProtocolList.GetFrameLengthSequence();
                

                switch ((uint)_frame.ProtocolList.GetProtocolsSequence()[i])
                {
                    case 1:
                        {
                            var _currentframe = (ICMPFrame)_frame.ProtocolList.GetFrameList()[i];
                            dataGridView1.Rows[i].Cells["numbercolumn"].Value = i + 1;
                            dataGridView1.Rows[i].Cells["protocolcolumn"].Value = _currentframe.GetProtocolName();
                            dataGridView1.Rows[i].Cells["sourceipcolumn"].Value = _currentframe.GetSourceIp();
                            dataGridView1.Rows[i].Cells["sourceportcolumn"].Value = _currentframe.GetSourcePort();
                            dataGridView1.Rows[i].Cells["destinationipcolumn"].Value = _currentframe.GetDestinationIp();
                            dataGridView1.Rows[i].Cells["destinationport"].Value = _currentframe.GetDestinationPort();
                            dataGridView1.Rows[i].Cells["lengthcolumn"].Value = LengthOfEachFrame[i];
                            break;
                        }

                    case 6:
                        {
                            var _currentframe = (TCPFrame)_frame.ProtocolList.GetFrameList()[i];
                            dataGridView1.Rows[i].Cells["numbercolumn"].Value = i + 1;
                            dataGridView1.Rows[i].Cells["protocolcolumn"].Value = _currentframe.GetProtocolName();
                            dataGridView1.Rows[i].Cells["sourceipcolumn"].Value = _currentframe.GetSourceIp();
                            dataGridView1.Rows[i].Cells["sourceportcolumn"].Value = _currentframe.GetSourcePort();
                            dataGridView1.Rows[i].Cells["destinationipcolumn"].Value = _currentframe.GetDestinationIp();
                            dataGridView1.Rows[i].Cells["destinationport"].Value = _currentframe.GetDestinationPort();
                            dataGridView1.Rows[i].Cells["lengthcolumn"].Value = LengthOfEachFrame[i];
                            break;
                        }

                    case 17:
                        {
                            var _currentframe = (UDPFrame)_frame.ProtocolList.GetFrameList()[i];
                            dataGridView1.Rows[i].Cells["numbercolumn"].Value = i + 1;
                            dataGridView1.Rows[i].Cells["protocolcolumn"].Value = _currentframe.GetProtocolName();
                            dataGridView1.Rows[i].Cells["sourceipcolumn"].Value = _currentframe.GetSourceIp();
                            dataGridView1.Rows[i].Cells["sourceportcolumn"].Value = _currentframe.GetSourcePort();
                            dataGridView1.Rows[i].Cells["destinationipcolumn"].Value = _currentframe.GetDestinationIp();
                            dataGridView1.Rows[i].Cells["destinationport"].Value = _currentframe.GetDestinationPort();
                            dataGridView1.Rows[i].Cells["lengthcolumn"].Value = LengthOfEachFrame[i];
                            break;
                        }

                    default:
                        {
                            dataGridView1.Rows[i].Cells["numbercolumn"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["protocolcolumn"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["sourceipcolumn"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["sourceportcolumn"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["destinationipcolumn"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["destinationport"].Value = "UNSUPP";
                            dataGridView1.Rows[i].Cells["lengthcolumn"].Value = "UNSUPP";
                            break;
                        }
                }
            }
        }
    }
}