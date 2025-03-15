using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PsipSwitch {
    public partial class AddAccessControlEntryWindow : Form {
        private MainWindow mainWindow;

        public AddAccessControlEntryWindow() {
            InitializeComponent();
        }

        private void saveEntryButton_Click(object sender, EventArgs e) {
            var ace = new AccessControlEntry {
                Action = (AccessControlEntryAction) actionComboBox.SelectedIndex,
                Protocol = (AccessControlEntryProtocol) protocolComboBox.SelectedIndex,
                SourceMacAddress = !string.IsNullOrEmpty(srcMacTextBox.Text) ? PhysicalAddress.Parse(srcMacTextBox.Text.ToUpper().Replace(':', '-')) : null,
                DestinationMacAddress = !string.IsNullOrEmpty(dstMacTextBox.Text) ? PhysicalAddress.Parse(dstMacTextBox.Text.ToUpper().Replace(':', '-')) : null,
                SourceIpV4Address = !string.IsNullOrEmpty(srcIpTextBox.Text) ? IPAddress.Parse(srcIpTextBox.Text) : null,
                DestinationIpV4Address = !string.IsNullOrEmpty(dstIpTextBox.Text) ? IPAddress.Parse(dstIpTextBox.Text) : null,
                SourcePort = (ushort) srcPortNumericUpDown.Value,
                DestinationPort = (ushort) dstPortNumericUpDown.Value,
                Direction = (AccessControlEntryDirection) directionComboBox.SelectedIndex,
                Interface = (byte) (interfaceComboBox.SelectedIndex + 1),
                ICMPType = (ICMPType) Enum.GetValues(typeof(ICMPType)).GetValue(icmpComboBox.SelectedIndex),
            };

            lock (this) {
                if (mainWindow.aceTable.IndexOf(ace) != -1) {
                    MessageBox.Show("ACE already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                mainWindow.aceTable.Add(ace);
                mainWindow.RefreshAclGrid(mainWindow.aceTable, mainWindow.bindingSourceAcl);
            }

            mainWindow?.RemoveOwnedForm(this);
            Close();
        }

        private void AddAccessControlEntryWindow_Load(object sender, EventArgs e) {
            mainWindow = (MainWindow) Owner;

            foreach (var action in Enum.GetValues(typeof(AccessControlEntryAction))) {
                actionComboBox.Items.Add(action.ToString());
            }

            foreach (var protocol in Enum.GetValues(typeof(AccessControlEntryProtocol))) {
                protocolComboBox.Items.Add(protocol.ToString());
            }

            protocolComboBox.SelectedIndex = protocolComboBox.Items.IndexOf(AccessControlEntryProtocol.Any.ToString());

            foreach (var direction in Enum.GetValues(typeof(AccessControlEntryDirection))) {
                directionComboBox.Items.Add(direction.ToString());
            }

            interfaceComboBox.Items.Add("Interface 1");
            interfaceComboBox.Items.Add("Interface 2");

            foreach (var icmpType in Enum.GetValues(typeof(ICMPType))) {
                icmpComboBox.Items.Add(Regex.Replace(icmpType.ToString(), "([a-z])([A-Z])", "$1 $2"));
            }

            icmpComboBox.SelectedIndex = icmpComboBox.Items.IndexOf(ICMPType.Any.ToString());
            icmpComboBox.Enabled = false;
            srcPortNumericUpDown.Enabled = false;
            dstPortNumericUpDown.Enabled = false;
        }

        private void AddAccessControlEntryWindow_FormClosing(object sender, FormClosingEventArgs e) {
            mainWindow?.RemoveOwnedForm(this);
        }

        private void InputValidation(object sender, EventArgs e) {
            var enableButton = actionComboBox.SelectedIndex != -1 &&
                directionComboBox.SelectedIndex != -1 &&
                interfaceComboBox.SelectedIndex != -1;

            enableButton &= (string.IsNullOrEmpty(srcMacTextBox.Text) || IsValidMacAddress(srcMacTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(dstMacTextBox.Text) || IsValidMacAddress(dstMacTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(srcIpTextBox.Text) || IsValidIpAddress(srcIpTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(dstIpTextBox.Text) || IsValidIpAddress(dstIpTextBox.Text));

            saveEntryButton.Enabled = enableButton;

            if (sender == protocolComboBox) {
                var protocol = (AccessControlEntryProtocol) protocolComboBox.SelectedIndex;
                icmpComboBox.Enabled = protocol == AccessControlEntryProtocol.ICMP;
                srcPortNumericUpDown.Enabled = protocol == AccessControlEntryProtocol.TCP || protocol == AccessControlEntryProtocol.UDP;
                dstPortNumericUpDown.Enabled = protocol == AccessControlEntryProtocol.TCP || protocol == AccessControlEntryProtocol.UDP;

                if (!icmpComboBox.Enabled) {
                    icmpComboBox.SelectedIndex = icmpComboBox.Items.IndexOf(ICMPType.Any.ToString());
                }

                if (!srcPortNumericUpDown.Enabled) {
                    srcPortNumericUpDown.Value = 0;
                    dstPortNumericUpDown.Value = 0;
                }
            }
        }

        private bool IsValidMacAddress(string macAddress) {
            try {
                var _ = PhysicalAddress.Parse(macAddress.ToUpper().Replace(':', '-'));

                return true;
            } catch {
                return false;
            }
        }

        private bool IsValidIpAddress(string ipAddress) {
            return IPAddress.TryParse(ipAddress, out var _);
        }
    }
}
