using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PsipSwitch {
    public partial class AddAclRuleWindow : Form {
        private MainWindow mainWindow;

        public AddAclRuleWindow() {
            InitializeComponent();
        }

        private void saveAclRuleButton_Click(object sender, EventArgs e) {
            var aclRule = new AccessControlListRule {
                Action = (AccessControlListAction) actionComboBox.SelectedIndex,
                Protocol = (AccessControlListProtocol) protocolComboBox.SelectedIndex,
                SourceMacAddress = !string.IsNullOrEmpty(srcMacTextBox.Text) ? PhysicalAddress.Parse(srcMacTextBox.Text.ToUpper().Replace(':', '-')) : null,
                DestinationMacAddress = !string.IsNullOrEmpty(dstMacTextBox.Text) ? PhysicalAddress.Parse(dstMacTextBox.Text.ToUpper().Replace(':', '-')) : null,
                SourceIpV4Address = !string.IsNullOrEmpty(srcIpTextBox.Text) ? IPAddress.Parse(srcIpTextBox.Text) : null,
                DestinationIpV4Address = !string.IsNullOrEmpty(dstIpTextBox.Text) ? IPAddress.Parse(dstIpTextBox.Text) : null,
                SourcePort = (ushort) srcPortNumericUpDown.Value,
                DestinationPort = (ushort) dstPortNumericUpDown.Value,
                Direction = (AccessControlListDirection) directionComboBox.SelectedIndex,
                Interface = (byte) (interfaceComboBox.SelectedIndex + 1),
                ICMPType = (ICMPType) Enum.GetValues(typeof(ICMPType)).GetValue(icmpComboBox.SelectedIndex),
            };

            lock (this) {
                if (mainWindow.aclTable.IndexOf(aclRule) != -1) {
                    MessageBox.Show("ACL rule already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                mainWindow.aclTable.Add(aclRule);
                mainWindow.RefreshAclGrid(mainWindow.aclTable, mainWindow.bindingSourceAcl);
            }

            mainWindow?.RemoveOwnedForm(this);
            Close();
        }

        private void AddAclRuleWindow_Load(object sender, EventArgs e) {
            mainWindow = (MainWindow) Owner;

            foreach (var action in Enum.GetValues(typeof(AccessControlListAction))) {
                actionComboBox.Items.Add(action.ToString());
            }

            foreach (var protocol in Enum.GetValues(typeof(AccessControlListProtocol))) {
                protocolComboBox.Items.Add(protocol.ToString());
            }

            protocolComboBox.SelectedIndex = protocolComboBox.Items.IndexOf(AccessControlListProtocol.Any.ToString());

            foreach (var direction in Enum.GetValues(typeof(AccessControlListDirection))) {
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

        private void AddAclRuleWindow_FormClosing(object sender, FormClosingEventArgs e) {
            mainWindow?.RemoveOwnedForm(this);
        }

        private void inputValidation(object sender, EventArgs e) {
            var enableButton = actionComboBox.SelectedIndex != -1 &&
                directionComboBox.SelectedIndex != -1 &&
                interfaceComboBox.SelectedIndex != -1;

            enableButton &= (string.IsNullOrEmpty(srcMacTextBox.Text) || IsValidMacAddress(srcMacTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(dstMacTextBox.Text) || IsValidMacAddress(dstMacTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(srcIpTextBox.Text) || IsValidIpAddress(srcIpTextBox.Text));
            enableButton &= (string.IsNullOrEmpty(dstIpTextBox.Text) || IsValidIpAddress(dstIpTextBox.Text));

            saveAclRuleButton.Enabled = enableButton;

            if (sender == protocolComboBox) {
                var protocol = (AccessControlListProtocol) protocolComboBox.SelectedIndex;
                icmpComboBox.Enabled = protocol == AccessControlListProtocol.ICMP;
                srcPortNumericUpDown.Enabled = protocol == AccessControlListProtocol.TCP || protocol == AccessControlListProtocol.UDP;
                dstPortNumericUpDown.Enabled = protocol == AccessControlListProtocol.TCP || protocol == AccessControlListProtocol.UDP;

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
