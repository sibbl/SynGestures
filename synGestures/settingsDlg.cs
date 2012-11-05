using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using synGestures.Config;
using synGestures.Helper;
using System.Xml;

namespace synGestures
{
    public partial class frmSettings : Form
    {
        public Configuration config;

        public bool startWithWindows = false;
        public InvokeActionManager actionManager;
        public readonly int[] settingsHeight = {220, 250, 485, 470};

        public frmSettings()
        {
            //checkUpdate();
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            setHeight(settingsHeight[0]);
            var defaultActions = DefaultActions.getDefaultActions();
            var defaultActionList =
                        (from action in defaultActions
                        select new
                        {
                            DisplayMember = action.Key,
                            ValueMember = action.Value
                        }).ToList();
            comboSingleTap.DisplayMember = "DisplayMember";
            comboSingleTap.ValueMember = "ValueMember";
            comboSingleTap.DataSource = defaultActionList;
            comboSingleTap.SelectedValue = config.MouseTapOne == null ? DefaultAction.NoAction : config.MouseTapOne.GetValue();
            comboSingleTap.SelectedValueChanged += comboTapsChanged;

            comboLongSingleTap.BindingContext = new BindingContext();
            comboLongSingleTap.DisplayMember = "DisplayMember";
            comboLongSingleTap.ValueMember = "ValueMember";
            comboLongSingleTap.DataSource = defaultActionList;
            comboLongSingleTap.SelectedValue = config.MouseTapOneLong == null ? DefaultAction.NoAction : config.MouseTapOneLong.GetValue();
            comboLongSingleTap.SelectedValueChanged += comboTapsChanged;

            comboTwoTaps.BindingContext = new BindingContext();
            comboTwoTaps.DisplayMember = "DisplayMember";
            comboTwoTaps.ValueMember = "ValueMember";
            comboTwoTaps.DataSource = defaultActionList;
            comboTwoTaps.SelectedValue = config.MouseTapTwo == null ? DefaultAction.NoAction : config.MouseTapTwo.GetValue();
            comboTwoTaps.SelectedValueChanged += comboTapsChanged;

            comboLongTwoTaps.BindingContext = new BindingContext();
            comboLongTwoTaps.DisplayMember = "DisplayMember";
            comboLongTwoTaps.ValueMember = "ValueMember";
            comboLongTwoTaps.DataSource = defaultActionList;
            comboLongTwoTaps.SelectedValue = config.MouseTapTwoLong == null ? DefaultAction.NoAction : config.MouseTapTwoLong.GetValue();
            comboLongTwoTaps.SelectedValueChanged += comboTapsChanged;

            comboThreeTaps.BindingContext = new BindingContext();
            comboThreeTaps.DisplayMember = "DisplayMember";
            comboThreeTaps.ValueMember = "ValueMember";
            comboThreeTaps.DataSource = defaultActionList;
            comboThreeTaps.SelectedValue = config.MouseTapThree == null ? DefaultAction.NoAction : config.MouseTapThree.GetValue();
            comboThreeTaps.SelectedValueChanged += comboTapsChanged;

            comboLongThreeTaps.BindingContext = new BindingContext();
            comboLongThreeTaps.DisplayMember = "DisplayMember";
            comboLongThreeTaps.ValueMember = "ValueMember";
            comboLongThreeTaps.DataSource = defaultActionList;
            comboLongThreeTaps.SelectedValue = config.MouseTapThreeLong == null ? DefaultAction.NoAction : config.MouseTapThreeLong.GetValue();
            comboLongThreeTaps.SelectedValueChanged += comboTapsChanged;

            trackTapTolerance.Value = config.MouseTapsLongMovingArea;
            trackLongTapTime.Value = config.MouseTapsLongMs;
            lblTapTolerance.Text = trackTapTolerance.Value + " px";
            lblLongTapTime.Text = trackLongTapTime.Value + " ms";


            trackScrollingAcceleration.Value = trackScrollingAcceleration.Maximum - config.ScrollAcceleration + trackScrollingAcceleration.Minimum;
            trackScrollingSpeed.Value = config.ScrollSpeed;
            chkScrollingVertical.Checked = config.ScrollVertical;
            chkScrollingHorizontal.Checked = config.ScrollHorizontal;
            chkScrollingReverse.Checked = config.ScrollReverse;
            chkScrollingAcceleration.Checked = config.ScrollAccelerationEnabled;

            startWithWindows = Autostart.IsAutoStartEnabled();
            chkWindows.Checked = startWithWindows;
            chkWindows.CheckedChanged += windowsAutoStartChanged;


            cbSwipe2L.BindingContext = new BindingContext();
            cbSwipe2L.DisplayMember = "DisplayMember";
            cbSwipe2L.ValueMember = "ValueMember";
            cbSwipe2L.DataSource = defaultActionList;
            cbSwipe2L.SelectedValue = config.SwipeTwoLeft == null ? DefaultAction.NoAction : config.SwipeTwoLeft.GetValue();
            cbSwipe2L.SelectedValueChanged += comboSwipesChanged;

            cbSwipe2R.BindingContext = new BindingContext();
            cbSwipe2R.DisplayMember = "DisplayMember";
            cbSwipe2R.ValueMember = "ValueMember";
            cbSwipe2R.DataSource = defaultActionList;
            cbSwipe2R.SelectedValue = config.SwipeTwoRight == null ? DefaultAction.NoAction : config.SwipeTwoRight.GetValue();
            cbSwipe2R.SelectedValueChanged += comboSwipesChanged;

            cbSwipe3U.BindingContext = new BindingContext();
            cbSwipe3U.DisplayMember = "DisplayMember";
            cbSwipe3U.ValueMember = "ValueMember";
            cbSwipe3U.DataSource = defaultActionList;
            cbSwipe3U.SelectedValue = config.SwipeThreeUp == null ? DefaultAction.NoAction : config.SwipeThreeUp.GetValue();
            cbSwipe3U.SelectedValueChanged += comboSwipesChanged;

            cbSwipe3D.BindingContext = new BindingContext();
            cbSwipe3D.DisplayMember = "DisplayMember";
            cbSwipe3D.ValueMember = "ValueMember";
            cbSwipe3D.DataSource = defaultActionList;
            cbSwipe3D.SelectedValue = config.SwipeThreeDown == null ? DefaultAction.NoAction : config.SwipeThreeDown.GetValue();
            cbSwipe3D.SelectedValueChanged += comboSwipesChanged;

            cbSwipe3L.BindingContext = new BindingContext();
            cbSwipe3L.DisplayMember = "DisplayMember";
            cbSwipe3L.ValueMember = "ValueMember";
            cbSwipe3L.DataSource = defaultActionList;
            cbSwipe3L.SelectedValue = config.SwipeThreeLeft == null ? DefaultAction.NoAction : config.SwipeThreeLeft.GetValue();
            cbSwipe3L.SelectedValueChanged += comboSwipesChanged;

            cbSwipe3R.BindingContext = new BindingContext();
            cbSwipe3R.DisplayMember = "DisplayMember";
            cbSwipe3R.ValueMember = "ValueMember";
            cbSwipe3R.DataSource = defaultActionList;
            cbSwipe3R.SelectedValue = config.SwipeThreeRight == null ? DefaultAction.NoAction : config.SwipeThreeRight.GetValue();
            cbSwipe3R.SelectedValueChanged += comboSwipesChanged;

            cbSwipeBorderT.BindingContext = new BindingContext();
            cbSwipeBorderT.DisplayMember = "DisplayMember";
            cbSwipeBorderT.ValueMember = "ValueMember";
            cbSwipeBorderT.DataSource = defaultActionList;
            cbSwipeBorderT.SelectedValue = config.SwipeBorderTop == null ? DefaultAction.NoAction : config.SwipeBorderTop.GetValue();
            cbSwipeBorderT.SelectedValueChanged += comboSwipesChanged;

            cbSwipeBorderB.BindingContext = new BindingContext();
            cbSwipeBorderB.DisplayMember = "DisplayMember";
            cbSwipeBorderB.ValueMember = "ValueMember";
            cbSwipeBorderB.DataSource = defaultActionList;
            cbSwipeBorderB.SelectedValue = config.SwipeBorderBottom == null ? DefaultAction.NoAction : config.SwipeBorderBottom.GetValue();
            cbSwipeBorderB.SelectedValueChanged += comboSwipesChanged;

            cbSwipeBorderL.BindingContext = new BindingContext();
            cbSwipeBorderL.DisplayMember = "DisplayMember";
            cbSwipeBorderL.ValueMember = "ValueMember";
            cbSwipeBorderL.DataSource = defaultActionList;
            cbSwipeBorderL.SelectedValue = config.SwipeBorderLeft == null ? DefaultAction.NoAction : config.SwipeBorderLeft.GetValue();
            cbSwipeBorderL.SelectedValueChanged += comboSwipesChanged;

            cbSwipeBorderR.BindingContext = new BindingContext();
            cbSwipeBorderR.DisplayMember = "DisplayMember";
            cbSwipeBorderR.ValueMember = "ValueMember";
            cbSwipeBorderR.DataSource = defaultActionList;
            cbSwipeBorderR.SelectedValue = config.SwipeBorderRight == null ? DefaultAction.NoAction : config.SwipeBorderRight.GetValue();
            cbSwipeBorderR.SelectedValueChanged += comboSwipesChanged;

        }
        private void applyConfig()
        {
            actionManager.loadConfig(config);
        }

        private void windowsAutoStartChanged(object sender, EventArgs e)
        {
            startWithWindows = chkWindows.Checked;
        }
        private void comboSwipesChanged(object sender, EventArgs e)
        {
            if (cbSwipe2L.SelectedValue != null)
                config.SwipeTwoLeft = new ConfigInvokeItem((DefaultAction)cbSwipe2L.SelectedValue);
            if (cbSwipe2R.SelectedValue != null)
                config.SwipeTwoRight = new ConfigInvokeItem((DefaultAction)cbSwipe2R.SelectedValue);
            if (cbSwipe3U.SelectedValue != null)
                config.SwipeThreeUp = new ConfigInvokeItem((DefaultAction)cbSwipe3U.SelectedValue);
            if (cbSwipe3D.SelectedValue != null)
                config.SwipeThreeDown = new ConfigInvokeItem((DefaultAction)cbSwipe3D.SelectedValue);
            if (cbSwipe3L.SelectedValue != null)
                config.SwipeThreeLeft = new ConfigInvokeItem((DefaultAction)cbSwipe3L.SelectedValue);
            if (cbSwipe3R.SelectedValue != null)
                config.SwipeThreeRight = new ConfigInvokeItem((DefaultAction)cbSwipe3R.SelectedValue);
            if (cbSwipeBorderT.SelectedValue != null)
                config.SwipeBorderTop = new ConfigInvokeItem((DefaultAction)cbSwipeBorderT.SelectedValue);
            if (cbSwipeBorderB.SelectedValue != null)
                config.SwipeBorderBottom = new ConfigInvokeItem((DefaultAction)cbSwipeBorderB.SelectedValue);
            if (cbSwipeBorderL.SelectedValue != null)
                config.SwipeBorderLeft = new ConfigInvokeItem((DefaultAction)cbSwipeBorderL.SelectedValue);
            if (cbSwipeBorderR.SelectedValue != null)
                config.SwipeBorderRight = new ConfigInvokeItem((DefaultAction)cbSwipeBorderR.SelectedValue);
            applyConfig();
        }
        private void comboTapsChanged(object sender, EventArgs e)
        {
            if (comboSingleTap.SelectedValue != null)
                config.MouseTapOne = new ConfigInvokeItem((DefaultAction)comboSingleTap.SelectedValue);
            if (comboLongSingleTap.SelectedValue != null)
                config.MouseTapOneLong = new ConfigInvokeItem((DefaultAction)comboLongSingleTap.SelectedValue);
            if (comboTwoTaps.SelectedValue != null)
                config.MouseTapTwo = new ConfigInvokeItem((DefaultAction)comboTwoTaps.SelectedValue);
            if (comboLongTwoTaps.SelectedValue != null)
                config.MouseTapTwoLong = new ConfigInvokeItem((DefaultAction)comboLongTwoTaps.SelectedValue);
            if (comboThreeTaps.SelectedValue != null)
                config.MouseTapThree = new ConfigInvokeItem((DefaultAction)comboThreeTaps.SelectedValue);
            if (comboLongThreeTaps.SelectedValue != null)
                config.MouseTapThreeLong = new ConfigInvokeItem((DefaultAction)comboLongThreeTaps.SelectedValue);
            applyConfig();
        }

        private void trackTapTolerance_ValueChanged(object sender, EventArgs e)
        {
            lblTapTolerance.Text = trackTapTolerance.Value + " px";
            config.MouseTapsLongMovingArea = trackTapTolerance.Value;
            applyConfig();
        }

        private void trackLongTapTime_ValueChanged(object sender, EventArgs e)
        {
            lblLongTapTime.Text = trackLongTapTime.Value + " ms";
            config.MouseTapsLongMs = trackLongTapTime.Value;
            applyConfig();
        }
        
        private void chkScrollingVertical_CheckedChanged(object sender, EventArgs e)
        {
            config.ScrollVertical = chkScrollingVertical.Checked;
            applyConfig();
        }

        private void chkScrollingHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            config.ScrollHorizontal = chkScrollingHorizontal.Checked;
            applyConfig();
        }

        private void chkScrollingReverse_CheckedChanged(object sender, EventArgs e)
        {
            config.ScrollReverse = chkScrollingReverse.Checked;
            applyConfig();
        }

        private void chkScrollingAcceleration_CheckedChanged(object sender, EventArgs e)
        {
            config.ScrollAccelerationEnabled = chkScrollingAcceleration.Checked;
            trackScrollingAcceleration.Enabled = config.ScrollAccelerationEnabled;
        }
        private void trackScrollingAcceleration_ValueChanged(object sender, EventArgs e)
        {
            config.ScrollAcceleration = trackScrollingAcceleration.Maximum - trackScrollingAcceleration.Value + trackScrollingAcceleration.Minimum;
            applyConfig();

        }

        private void trackScrollingSpeed_ValueChanged(object sender, EventArgs e)
        {
            config.ScrollSpeed = trackScrollingSpeed.Value;
            applyConfig();
        }
        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://syngestures.klickin-webdesign.de");

        }

        private void linkTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/SynGestures");
        }

        private void linkFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start("http://facebook.com/SynGestures");
        }

        private void LinkGooglePlus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://plus.google.com/b/108854491805269173201/");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = tabControl1.SelectedIndex;
            if (index >= 0 && index < settingsHeight.Length) animatedResize(settingsHeight[index]);
        }
        private void setHeight(int h)
        {
            this.Height = h;
            tabControl1.Height = h - 71;
            btnCancel.Top = btnOK.Top = h - 65;

        }
        private void animatedResize(int desiredHeight)
        {
            int speed = 1;
            int interval = 50;
            tabControl1.SelectedTab.Hide();
            if (this.Height <= desiredHeight)
            {
                for (int j = this.Height; j < desiredHeight; j += interval)
                {
                    setHeight(j);
                    System.Threading.Thread.Sleep(speed);
                }
                setHeight(desiredHeight);
            }
            else if (this.Height >= desiredHeight)
            {
                for (int j = this.Height; j > desiredHeight; j -= interval)
                {
                    setHeight(j);
                    System.Threading.Thread.Sleep(speed);
                }
                setHeight(desiredHeight);
            }
            tabControl1.SelectedTab.Show();
        }

        private void checkUpdate(bool alertUpdateOnly = true)
        {
            try
            {
                XmlTextReader XmlReader = new XmlTextReader("http://syngestures.klickin-webdesign.de/version.xml");

                int currentVersionId = 1;
                int newVersionId = 0;
                string newVersionString = "";
                string newVersionChanges = "";
                string newVersionUrl = "";
                while (XmlReader.Read())
                {
                    if (XmlReader.Name.ToString() == "id") newVersionId = Int32.Parse(XmlReader.ReadString());
                    if (XmlReader.Name.ToString() == "name") newVersionString = XmlReader.ReadString().Trim();
                    if (XmlReader.Name.ToString() == "changes") newVersionChanges = XmlReader.ReadString().Trim();
                    if (XmlReader.Name.ToString() == "url") newVersionUrl = XmlReader.ReadString().Trim();
                }
                XmlReader.Close();

                if (newVersionId <= currentVersionId)
                {
                    if(!alertUpdateOnly) MessageBox.Show("Congrats! You are using latest version of SynGestures.", "No update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    newVersionChanges = newVersionChanges.Replace("\\n", "\n");
                    var result = MessageBox.Show("A new version of SynGestures was found: " + newVersionString + "\n\nChangelog:\n" + newVersionChanges + "\n\nDo you want to download the new version now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(newVersionUrl);
                    }
                }
            }
            catch (Exception)
            {
                if (!alertUpdateOnly) MessageBox.Show("An error occured while looking for updates. Please try again later.", "Could not check for update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            checkUpdate(false);
        }



    }
}
