namespace synGestures
{
    partial class frmSettings
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.LinkGooglePlus = new System.Windows.Forms.LinkLabel();
            this.linkFacebook = new System.Windows.Forms.LinkLabel();
            this.linkTwitter = new System.Windows.Forms.LinkLabel();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkWindows = new System.Windows.Forms.CheckBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.scrollingTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.trackScrollingSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.chkScrollingAcceleration = new System.Windows.Forms.CheckBox();
            this.chkScrollingReverse = new System.Windows.Forms.CheckBox();
            this.chkScrollingHorizontal = new System.Windows.Forms.CheckBox();
            this.chkScrollingVertical = new System.Windows.Forms.CheckBox();
            this.trackScrollingAcceleration = new System.Windows.Forms.TrackBar();
            this.swipeTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSwipeBorderR = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbSwipeBorderL = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSwipeBorderB = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbSwipeBorderT = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSwipe3R = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbSwipe3L = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbSwipe3D = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbSwipe3U = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSwipe2R = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSwipe2L = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.clickingTab = new System.Windows.Forms.TabPage();
            this.lblLongTapTime = new System.Windows.Forms.Label();
            this.lblTapTolerance = new System.Windows.Forms.Label();
            this.trackLongTapTime = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackTapTolerance = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelThreeTaps = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLongThreeTaps = new System.Windows.Forms.ComboBox();
            this.comboThreeTaps = new System.Windows.Forms.ComboBox();
            this.lblThreeTaps = new System.Windows.Forms.Label();
            this.panelTwoTaps = new System.Windows.Forms.Panel();
            this.lblLongTwoTaps = new System.Windows.Forms.Label();
            this.comboLongTwoTaps = new System.Windows.Forms.ComboBox();
            this.comboTwoTaps = new System.Windows.Forms.ComboBox();
            this.lblTwoTaps = new System.Windows.Forms.Label();
            this.panelSingleTap = new System.Windows.Forms.Panel();
            this.lblLongSingleTap = new System.Windows.Forms.Label();
            this.comboLongSingleTap = new System.Windows.Forms.ComboBox();
            this.comboSingleTap = new System.Windows.Forms.ComboBox();
            this.lblSingleTap = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.scrollingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScrollingSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackScrollingAcceleration)).BeginInit();
            this.swipeTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.clickingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongTapTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTapTolerance)).BeginInit();
            this.panelThreeTaps.SuspendLayout();
            this.panelTwoTaps.SuspendLayout();
            this.panelSingleTap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.scrollingTab);
            this.tabControl1.Controls.Add(this.swipeTab);
            this.tabControl1.Controls.Add(this.clickingTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 429);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.LinkGooglePlus);
            this.generalTab.Controls.Add(this.linkFacebook);
            this.generalTab.Controls.Add(this.linkTwitter);
            this.generalTab.Controls.Add(this.label20);
            this.generalTab.Controls.Add(this.label9);
            this.generalTab.Controls.Add(this.chkWindows);
            this.generalTab.Controls.Add(this.shapeContainer1);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(458, 403);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // LinkGooglePlus
            // 
            this.LinkGooglePlus.AutoSize = true;
            this.LinkGooglePlus.Location = new System.Drawing.Point(385, 91);
            this.LinkGooglePlus.Name = "LinkGooglePlus";
            this.LinkGooglePlus.Size = new System.Drawing.Size(47, 13);
            this.LinkGooglePlus.TabIndex = 27;
            this.LinkGooglePlus.TabStop = true;
            this.LinkGooglePlus.Text = "Google+";
            this.LinkGooglePlus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGooglePlus_LinkClicked);
            // 
            // linkFacebook
            // 
            this.linkFacebook.AutoSize = true;
            this.linkFacebook.Location = new System.Drawing.Point(324, 91);
            this.linkFacebook.Name = "linkFacebook";
            this.linkFacebook.Size = new System.Drawing.Size(55, 13);
            this.linkFacebook.TabIndex = 26;
            this.linkFacebook.TabStop = true;
            this.linkFacebook.Text = "Facebook";
            this.linkFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFacebook_LinkClicked);
            // 
            // linkTwitter
            // 
            this.linkTwitter.AutoSize = true;
            this.linkTwitter.Location = new System.Drawing.Point(279, 91);
            this.linkTwitter.Name = "linkTwitter";
            this.linkTwitter.Size = new System.Drawing.Size(39, 13);
            this.linkTwitter.TabIndex = 25;
            this.linkTwitter.TabStop = true;
            this.linkTwitter.Text = "Twitter";
            this.linkTwitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTwitter_LinkClicked);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(93, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "v0.2 Beta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "SynGestures";
            // 
            // chkWindows
            // 
            this.chkWindows.AutoSize = true;
            this.chkWindows.Location = new System.Drawing.Point(16, 20);
            this.chkWindows.Name = "chkWindows";
            this.chkWindows.Size = new System.Drawing.Size(114, 17);
            this.chkWindows.TabIndex = 0;
            this.chkWindows.Text = "Start with windows";
            this.chkWindows.UseVisualStyleBackColor = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(452, 397);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 18;
            this.lineShape1.X2 = 428;
            this.lineShape1.Y1 = 68;
            this.lineShape1.Y2 = 68;
            // 
            // scrollingTab
            // 
            this.scrollingTab.Controls.Add(this.label1);
            this.scrollingTab.Controls.Add(this.trackScrollingSpeed);
            this.scrollingTab.Controls.Add(this.label2);
            this.scrollingTab.Controls.Add(this.chkScrollingAcceleration);
            this.scrollingTab.Controls.Add(this.chkScrollingReverse);
            this.scrollingTab.Controls.Add(this.chkScrollingHorizontal);
            this.scrollingTab.Controls.Add(this.chkScrollingVertical);
            this.scrollingTab.Controls.Add(this.trackScrollingAcceleration);
            this.scrollingTab.Location = new System.Drawing.Point(4, 22);
            this.scrollingTab.Name = "scrollingTab";
            this.scrollingTab.Padding = new System.Windows.Forms.Padding(3);
            this.scrollingTab.Size = new System.Drawing.Size(458, 403);
            this.scrollingTab.TabIndex = 1;
            this.scrollingTab.Text = "Scrolling";
            this.scrollingTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Scrolling acceleration:";
            // 
            // trackScrollingSpeed
            // 
            this.trackScrollingSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.trackScrollingSpeed.Location = new System.Drawing.Point(16, 104);
            this.trackScrollingSpeed.Maximum = 100;
            this.trackScrollingSpeed.Minimum = 10;
            this.trackScrollingSpeed.Name = "trackScrollingSpeed";
            this.trackScrollingSpeed.Size = new System.Drawing.Size(187, 45);
            this.trackScrollingSpeed.TabIndex = 14;
            this.trackScrollingSpeed.TickFrequency = 5;
            this.trackScrollingSpeed.Value = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Scrolling speed:";
            // 
            // chkScrollingAcceleration
            // 
            this.chkScrollingAcceleration.AutoSize = true;
            this.chkScrollingAcceleration.Location = new System.Drawing.Point(256, 44);
            this.chkScrollingAcceleration.Name = "chkScrollingAcceleration";
            this.chkScrollingAcceleration.Size = new System.Drawing.Size(161, 17);
            this.chkScrollingAcceleration.TabIndex = 12;
            this.chkScrollingAcceleration.Text = "Enable scrolling acceleration\r\n";
            this.chkScrollingAcceleration.UseVisualStyleBackColor = true;
            this.chkScrollingAcceleration.CheckedChanged += new System.EventHandler(this.chkScrollingAcceleration_CheckedChanged);
            // 
            // chkScrollingReverse
            // 
            this.chkScrollingReverse.AutoSize = true;
            this.chkScrollingReverse.Location = new System.Drawing.Point(256, 20);
            this.chkScrollingReverse.Name = "chkScrollingReverse";
            this.chkScrollingReverse.Size = new System.Drawing.Size(144, 17);
            this.chkScrollingReverse.TabIndex = 11;
            this.chkScrollingReverse.Text = "Enable reversed scrolling";
            this.chkScrollingReverse.UseVisualStyleBackColor = true;
            this.chkScrollingReverse.CheckedChanged += new System.EventHandler(this.chkScrollingReverse_CheckedChanged);
            // 
            // chkScrollingHorizontal
            // 
            this.chkScrollingHorizontal.AutoSize = true;
            this.chkScrollingHorizontal.Location = new System.Drawing.Point(16, 43);
            this.chkScrollingHorizontal.Name = "chkScrollingHorizontal";
            this.chkScrollingHorizontal.Size = new System.Drawing.Size(224, 17);
            this.chkScrollingHorizontal.TabIndex = 10;
            this.chkScrollingHorizontal.Text = "Enable horizontal scrolling with two fingers";
            this.chkScrollingHorizontal.UseVisualStyleBackColor = true;
            this.chkScrollingHorizontal.CheckedChanged += new System.EventHandler(this.chkScrollingHorizontal_CheckedChanged);
            // 
            // chkScrollingVertical
            // 
            this.chkScrollingVertical.AutoSize = true;
            this.chkScrollingVertical.Location = new System.Drawing.Point(16, 20);
            this.chkScrollingVertical.Name = "chkScrollingVertical";
            this.chkScrollingVertical.Size = new System.Drawing.Size(213, 17);
            this.chkScrollingVertical.TabIndex = 9;
            this.chkScrollingVertical.Text = "Enable vertical scrolling with two fingers";
            this.chkScrollingVertical.UseVisualStyleBackColor = true;
            this.chkScrollingVertical.CheckedChanged += new System.EventHandler(this.chkScrollingVertical_CheckedChanged);
            // 
            // trackScrollingAcceleration
            // 
            this.trackScrollingAcceleration.BackColor = System.Drawing.SystemColors.Window;
            this.trackScrollingAcceleration.LargeChange = 10;
            this.trackScrollingAcceleration.Location = new System.Drawing.Point(256, 104);
            this.trackScrollingAcceleration.Maximum = 300;
            this.trackScrollingAcceleration.Minimum = 2;
            this.trackScrollingAcceleration.Name = "trackScrollingAcceleration";
            this.trackScrollingAcceleration.Size = new System.Drawing.Size(187, 45);
            this.trackScrollingAcceleration.TabIndex = 8;
            this.trackScrollingAcceleration.TickFrequency = 20;
            this.trackScrollingAcceleration.Value = 80;
            this.trackScrollingAcceleration.ValueChanged += new System.EventHandler(this.trackScrollingAcceleration_ValueChanged);
            // 
            // swipeTab
            // 
            this.swipeTab.Controls.Add(this.groupBox3);
            this.swipeTab.Controls.Add(this.groupBox2);
            this.swipeTab.Controls.Add(this.groupBox1);
            this.swipeTab.Location = new System.Drawing.Point(4, 22);
            this.swipeTab.Name = "swipeTab";
            this.swipeTab.Size = new System.Drawing.Size(458, 403);
            this.swipeTab.TabIndex = 2;
            this.swipeTab.Text = "Swiping";
            this.swipeTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSwipeBorderR);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cbSwipeBorderL);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbSwipeBorderB);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cbSwipeBorderT);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Location = new System.Drawing.Point(3, 251);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 117);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Border swipes";
            // 
            // cbSwipeBorderR
            // 
            this.cbSwipeBorderR.FormattingEnabled = true;
            this.cbSwipeBorderR.Location = new System.Drawing.Point(227, 84);
            this.cbSwipeBorderR.Name = "cbSwipeBorderR";
            this.cbSwipeBorderR.Size = new System.Drawing.Size(214, 21);
            this.cbSwipeBorderR.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(224, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Swipe in from right";
            // 
            // cbSwipeBorderL
            // 
            this.cbSwipeBorderL.FormattingEnabled = true;
            this.cbSwipeBorderL.Location = new System.Drawing.Point(7, 84);
            this.cbSwipeBorderL.Name = "cbSwipeBorderL";
            this.cbSwipeBorderL.Size = new System.Drawing.Size(214, 21);
            this.cbSwipeBorderL.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Swipe in from left";
            // 
            // cbSwipeBorderB
            // 
            this.cbSwipeBorderB.FormattingEnabled = true;
            this.cbSwipeBorderB.Location = new System.Drawing.Point(227, 38);
            this.cbSwipeBorderB.Name = "cbSwipeBorderB";
            this.cbSwipeBorderB.Size = new System.Drawing.Size(214, 21);
            this.cbSwipeBorderB.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(224, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(125, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Swipe in from bottom";
            // 
            // cbSwipeBorderT
            // 
            this.cbSwipeBorderT.FormattingEnabled = true;
            this.cbSwipeBorderT.Location = new System.Drawing.Point(7, 38);
            this.cbSwipeBorderT.Name = "cbSwipeBorderT";
            this.cbSwipeBorderT.Size = new System.Drawing.Size(214, 21);
            this.cbSwipeBorderT.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(4, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Swipe in from top";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSwipe3R);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbSwipe3L);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbSwipe3D);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbSwipe3U);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(5, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Three finger swipes";
            // 
            // cbSwipe3R
            // 
            this.cbSwipe3R.FormattingEnabled = true;
            this.cbSwipe3R.Location = new System.Drawing.Point(227, 84);
            this.cbSwipe3R.Name = "cbSwipe3R";
            this.cbSwipe3R.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe3R.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(224, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Three finger swipe to the right";
            // 
            // cbSwipe3L
            // 
            this.cbSwipe3L.FormattingEnabled = true;
            this.cbSwipe3L.Location = new System.Drawing.Point(7, 84);
            this.cbSwipe3L.Name = "cbSwipe3L";
            this.cbSwipe3L.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe3L.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(171, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Three finger swipe to the left";
            // 
            // cbSwipe3D
            // 
            this.cbSwipe3D.FormattingEnabled = true;
            this.cbSwipe3D.Location = new System.Drawing.Point(227, 38);
            this.cbSwipe3D.Name = "cbSwipe3D";
            this.cbSwipe3D.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe3D.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(224, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Three finger swipe to the bottom";
            // 
            // cbSwipe3U
            // 
            this.cbSwipe3U.FormattingEnabled = true;
            this.cbSwipe3U.Location = new System.Drawing.Point(7, 38);
            this.cbSwipe3U.Name = "cbSwipe3U";
            this.cbSwipe3U.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe3U.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Three finger swipe to the top";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbSwipe2R);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbSwipe2L);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Two finger swipes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(341, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Please note that two finger swipes can overlap with horizontal scrolling.";
            // 
            // cbSwipe2R
            // 
            this.cbSwipe2R.FormattingEnabled = true;
            this.cbSwipe2R.Location = new System.Drawing.Point(227, 36);
            this.cbSwipe2R.Name = "cbSwipe2R";
            this.cbSwipe2R.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe2R.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(224, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Two finger swipe to the right";
            // 
            // cbSwipe2L
            // 
            this.cbSwipe2L.FormattingEnabled = true;
            this.cbSwipe2L.Location = new System.Drawing.Point(7, 36);
            this.cbSwipe2L.Name = "cbSwipe2L";
            this.cbSwipe2L.Size = new System.Drawing.Size(214, 21);
            this.cbSwipe2L.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Two finger swipe to the left";
            // 
            // clickingTab
            // 
            this.clickingTab.Controls.Add(this.lblLongTapTime);
            this.clickingTab.Controls.Add(this.lblTapTolerance);
            this.clickingTab.Controls.Add(this.trackLongTapTime);
            this.clickingTab.Controls.Add(this.label7);
            this.clickingTab.Controls.Add(this.label6);
            this.clickingTab.Controls.Add(this.trackTapTolerance);
            this.clickingTab.Controls.Add(this.label5);
            this.clickingTab.Controls.Add(this.label4);
            this.clickingTab.Controls.Add(this.panelThreeTaps);
            this.clickingTab.Controls.Add(this.panelTwoTaps);
            this.clickingTab.Controls.Add(this.panelSingleTap);
            this.clickingTab.Location = new System.Drawing.Point(4, 22);
            this.clickingTab.Name = "clickingTab";
            this.clickingTab.Size = new System.Drawing.Size(458, 403);
            this.clickingTab.TabIndex = 3;
            this.clickingTab.Text = "Tapping";
            this.clickingTab.UseVisualStyleBackColor = true;
            // 
            // lblLongTapTime
            // 
            this.lblLongTapTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongTapTime.Location = new System.Drawing.Point(405, 324);
            this.lblLongTapTime.Name = "lblLongTapTime";
            this.lblLongTapTime.Size = new System.Drawing.Size(50, 13);
            this.lblLongTapTime.TabIndex = 10;
            this.lblLongTapTime.Text = "ms";
            this.lblLongTapTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTapTolerance
            // 
            this.lblTapTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTolerance.Location = new System.Drawing.Point(402, 256);
            this.lblTapTolerance.Name = "lblTapTolerance";
            this.lblTapTolerance.Size = new System.Drawing.Size(50, 13);
            this.lblTapTolerance.TabIndex = 9;
            this.lblTapTolerance.Text = "px";
            this.lblTapTolerance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTapTolerance.Visible = false;
            // 
            // trackLongTapTime
            // 
            this.trackLongTapTime.BackColor = System.Drawing.SystemColors.Window;
            this.trackLongTapTime.LargeChange = 500;
            this.trackLongTapTime.Location = new System.Drawing.Point(232, 324);
            this.trackLongTapTime.Maximum = 2000;
            this.trackLongTapTime.Minimum = 100;
            this.trackLongTapTime.Name = "trackLongTapTime";
            this.trackLongTapTime.Size = new System.Drawing.Size(168, 45);
            this.trackLongTapTime.SmallChange = 10;
            this.trackLongTapTime.TabIndex = 8;
            this.trackLongTapTime.TickFrequency = 100;
            this.trackLongTapTime.Value = 500;
            this.trackLongTapTime.ValueChanged += new System.EventHandler(this.trackLongTapTime_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "How long a tap last to be a long tap";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Long tap time";
            // 
            // trackTapTolerance
            // 
            this.trackTapTolerance.BackColor = System.Drawing.SystemColors.Window;
            this.trackTapTolerance.LargeChange = 10;
            this.trackTapTolerance.Location = new System.Drawing.Point(232, 256);
            this.trackTapTolerance.Maximum = 300;
            this.trackTapTolerance.Minimum = 50;
            this.trackTapTolerance.Name = "trackTapTolerance";
            this.trackTapTolerance.Size = new System.Drawing.Size(168, 45);
            this.trackTapTolerance.TabIndex = 5;
            this.trackTapTolerance.TickFrequency = 14;
            this.trackTapTolerance.Value = 150;
            this.trackTapTolerance.ValueChanged += new System.EventHandler(this.trackTapTolerance_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "How far may you move your fingers\r\nbetween first tap and release";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Long tap tolerance";
            // 
            // panelThreeTaps
            // 
            this.panelThreeTaps.Controls.Add(this.label3);
            this.panelThreeTaps.Controls.Add(this.comboLongThreeTaps);
            this.panelThreeTaps.Controls.Add(this.comboThreeTaps);
            this.panelThreeTaps.Controls.Add(this.lblThreeTaps);
            this.panelThreeTaps.Location = new System.Drawing.Point(3, 166);
            this.panelThreeTaps.Name = "panelThreeTaps";
            this.panelThreeTaps.Size = new System.Drawing.Size(452, 76);
            this.panelThreeTaps.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Long triple tap";
            // 
            // comboLongThreeTaps
            // 
            this.comboLongThreeTaps.FormattingEnabled = true;
            this.comboLongThreeTaps.Location = new System.Drawing.Point(229, 37);
            this.comboLongThreeTaps.Name = "comboLongThreeTaps";
            this.comboLongThreeTaps.Size = new System.Drawing.Size(214, 21);
            this.comboLongThreeTaps.TabIndex = 3;
            // 
            // comboThreeTaps
            // 
            this.comboThreeTaps.FormattingEnabled = true;
            this.comboThreeTaps.Location = new System.Drawing.Point(10, 37);
            this.comboThreeTaps.Name = "comboThreeTaps";
            this.comboThreeTaps.Size = new System.Drawing.Size(214, 21);
            this.comboThreeTaps.TabIndex = 2;
            // 
            // lblThreeTaps
            // 
            this.lblThreeTaps.AutoSize = true;
            this.lblThreeTaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreeTaps.Location = new System.Drawing.Point(7, 13);
            this.lblThreeTaps.Name = "lblThreeTaps";
            this.lblThreeTaps.Size = new System.Drawing.Size(61, 13);
            this.lblThreeTaps.TabIndex = 1;
            this.lblThreeTaps.Text = "Triple tap";
            // 
            // panelTwoTaps
            // 
            this.panelTwoTaps.Controls.Add(this.lblLongTwoTaps);
            this.panelTwoTaps.Controls.Add(this.comboLongTwoTaps);
            this.panelTwoTaps.Controls.Add(this.comboTwoTaps);
            this.panelTwoTaps.Controls.Add(this.lblTwoTaps);
            this.panelTwoTaps.Location = new System.Drawing.Point(3, 84);
            this.panelTwoTaps.Name = "panelTwoTaps";
            this.panelTwoTaps.Size = new System.Drawing.Size(452, 76);
            this.panelTwoTaps.TabIndex = 1;
            // 
            // lblLongTwoTaps
            // 
            this.lblLongTwoTaps.AutoSize = true;
            this.lblLongTwoTaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongTwoTaps.Location = new System.Drawing.Point(226, 13);
            this.lblLongTwoTaps.Name = "lblLongTwoTaps";
            this.lblLongTwoTaps.Size = new System.Drawing.Size(99, 13);
            this.lblLongTwoTaps.TabIndex = 4;
            this.lblLongTwoTaps.Text = "Long double tap";
            // 
            // comboLongTwoTaps
            // 
            this.comboLongTwoTaps.FormattingEnabled = true;
            this.comboLongTwoTaps.Location = new System.Drawing.Point(229, 37);
            this.comboLongTwoTaps.Name = "comboLongTwoTaps";
            this.comboLongTwoTaps.Size = new System.Drawing.Size(214, 21);
            this.comboLongTwoTaps.TabIndex = 3;
            // 
            // comboTwoTaps
            // 
            this.comboTwoTaps.FormattingEnabled = true;
            this.comboTwoTaps.Location = new System.Drawing.Point(10, 37);
            this.comboTwoTaps.Name = "comboTwoTaps";
            this.comboTwoTaps.Size = new System.Drawing.Size(214, 21);
            this.comboTwoTaps.TabIndex = 2;
            // 
            // lblTwoTaps
            // 
            this.lblTwoTaps.AutoSize = true;
            this.lblTwoTaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwoTaps.Location = new System.Drawing.Point(7, 13);
            this.lblTwoTaps.Name = "lblTwoTaps";
            this.lblTwoTaps.Size = new System.Drawing.Size(69, 13);
            this.lblTwoTaps.TabIndex = 1;
            this.lblTwoTaps.Text = "Double tap";
            // 
            // panelSingleTap
            // 
            this.panelSingleTap.Controls.Add(this.lblLongSingleTap);
            this.panelSingleTap.Controls.Add(this.comboLongSingleTap);
            this.panelSingleTap.Controls.Add(this.comboSingleTap);
            this.panelSingleTap.Controls.Add(this.lblSingleTap);
            this.panelSingleTap.Location = new System.Drawing.Point(3, 2);
            this.panelSingleTap.Name = "panelSingleTap";
            this.panelSingleTap.Size = new System.Drawing.Size(452, 76);
            this.panelSingleTap.TabIndex = 0;
            // 
            // lblLongSingleTap
            // 
            this.lblLongSingleTap.AutoSize = true;
            this.lblLongSingleTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongSingleTap.Location = new System.Drawing.Point(226, 13);
            this.lblLongSingleTap.Name = "lblLongSingleTap";
            this.lblLongSingleTap.Size = new System.Drawing.Size(94, 13);
            this.lblLongSingleTap.TabIndex = 4;
            this.lblLongSingleTap.Text = "Long single tap";
            // 
            // comboLongSingleTap
            // 
            this.comboLongSingleTap.FormattingEnabled = true;
            this.comboLongSingleTap.Location = new System.Drawing.Point(229, 37);
            this.comboLongSingleTap.Name = "comboLongSingleTap";
            this.comboLongSingleTap.Size = new System.Drawing.Size(214, 21);
            this.comboLongSingleTap.TabIndex = 3;
            // 
            // comboSingleTap
            // 
            this.comboSingleTap.FormattingEnabled = true;
            this.comboSingleTap.Location = new System.Drawing.Point(10, 37);
            this.comboSingleTap.Name = "comboSingleTap";
            this.comboSingleTap.Size = new System.Drawing.Size(214, 21);
            this.comboSingleTap.TabIndex = 2;
            // 
            // lblSingleTap
            // 
            this.lblSingleTap.AutoSize = true;
            this.lblSingleTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingleTap.Location = new System.Drawing.Point(7, 13);
            this.lblSingleTap.Name = "lblSingleTap";
            this.lblSingleTap.Size = new System.Drawing.Size(64, 13);
            this.lblSingleTap.TabIndex = 1;
            this.lblSingleTap.Text = "Single tap";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(380, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(285, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(470, 462);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SynGestures settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.scrollingTab.ResumeLayout(false);
            this.scrollingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScrollingSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackScrollingAcceleration)).EndInit();
            this.swipeTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.clickingTab.ResumeLayout(false);
            this.clickingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongTapTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTapTolerance)).EndInit();
            this.panelThreeTaps.ResumeLayout(false);
            this.panelThreeTaps.PerformLayout();
            this.panelTwoTaps.ResumeLayout(false);
            this.panelTwoTaps.PerformLayout();
            this.panelSingleTap.ResumeLayout(false);
            this.panelSingleTap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage scrollingTab;
        private System.Windows.Forms.TabPage swipeTab;
        private System.Windows.Forms.TabPage clickingTab;
        private System.Windows.Forms.Panel panelSingleTap;
        private System.Windows.Forms.ComboBox comboSingleTap;
        private System.Windows.Forms.Label lblSingleTap;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblLongSingleTap;
        private System.Windows.Forms.ComboBox comboLongSingleTap;
        private System.Windows.Forms.Panel panelTwoTaps;
        private System.Windows.Forms.Label lblLongTwoTaps;
        private System.Windows.Forms.ComboBox comboLongTwoTaps;
        private System.Windows.Forms.ComboBox comboTwoTaps;
        private System.Windows.Forms.Label lblTwoTaps;
        private System.Windows.Forms.Panel panelThreeTaps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboLongThreeTaps;
        private System.Windows.Forms.ComboBox comboThreeTaps;
        private System.Windows.Forms.Label lblThreeTaps;
        private System.Windows.Forms.TrackBar trackTapTolerance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLongTapTime;
        private System.Windows.Forms.Label lblTapTolerance;
        private System.Windows.Forms.TrackBar trackLongTapTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkWindows;
        private System.Windows.Forms.CheckBox chkScrollingReverse;
        private System.Windows.Forms.CheckBox chkScrollingHorizontal;
        private System.Windows.Forms.CheckBox chkScrollingVertical;
        private System.Windows.Forms.TrackBar trackScrollingAcceleration;
        private System.Windows.Forms.CheckBox chkScrollingAcceleration;
        private System.Windows.Forms.TrackBar trackScrollingSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbSwipeBorderR;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbSwipeBorderL;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbSwipeBorderB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbSwipeBorderT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbSwipe3R;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSwipe3L;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbSwipe3D;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbSwipe3U;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbSwipe2R;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSwipe2L;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel LinkGooglePlus;
        private System.Windows.Forms.LinkLabel linkFacebook;
        private System.Windows.Forms.LinkLabel linkTwitter;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;

    }
}

