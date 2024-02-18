namespace LSystem
{
    partial class Form3L
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenGL.GlControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.code읽기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.code저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화면저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nbrStep = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDivergenceAngle1 = new System.Windows.Forms.TrackBar();
            this.lbDivergenceAngle1 = new System.Windows.Forms.Label();
            this.lbDivergenceAngle2 = new System.Windows.Forms.Label();
            this.tbDivergenceAngle2 = new System.Windows.Forms.TrackBar();
            this.lbBranchingAngle = new System.Windows.Forms.Label();
            this.tbBranchingAngle = new System.Windows.Forms.TrackBar();
            this.tbElongationRate = new System.Windows.Forms.TrackBar();
            this.lbElongationRate = new System.Windows.Forms.Label();
            this.tbWidthIncreaseRate = new System.Windows.Forms.TrackBar();
            this.lbWidthIncreaseRate = new System.Windows.Forms.Label();
            this.caTrophism = new System.Windows.Forms.CircleAnglePicker();
            this.lbTrophismVector = new System.Windows.Forms.Label();
            this.lbBendingConstant = new System.Windows.Forms.Label();
            this.tbVectorLength = new System.Windows.Forms.TrackBar();
            this.tbBendingConstant = new System.Windows.Forms.TrackBar();
            this.btnRandom = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbLeafWidth = new System.Windows.Forms.TrackBar();
            this.lbLeafWidth = new System.Windows.Forms.Label();
            this.tbLeafHeight = new System.Windows.Forms.TrackBar();
            this.lbLeafHeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmLeafRotCount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.nbrResolution = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBranchingAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbElongationRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWidthIncreaseRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVectorLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBendingConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeafWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeafHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmLeafRotCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.Animation = true;
            this.glControl1.AutoSize = true;
            this.glControl1.BackColor = System.Drawing.Color.Gray;
            this.glControl1.ColorBits = ((uint)(24u));
            this.glControl1.DepthBits = ((uint)(24u));
            this.glControl1.Location = new System.Drawing.Point(4, 27);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.glControl1.MultisampleBits = ((uint)(0u));
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(614, 724);
            this.glControl1.StencilBits = ((uint)(8u));
            this.glControl1.SwapInterval = -1;
            this.glControl1.TabIndex = 1;
            this.glControl1.Render += new System.EventHandler<OpenGL.GlControlEventArgs>(this.glControl1_Render);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDoubleClick);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseWheel);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(675, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "!(1)F(200)/(45)A";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(761, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(127, 35);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "모두지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.도구ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.code읽기ToolStripMenuItem,
            this.code저장ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // code읽기ToolStripMenuItem
            // 
            this.code읽기ToolStripMenuItem.Name = "code읽기ToolStripMenuItem";
            this.code읽기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.code읽기ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.code읽기ToolStripMenuItem.Text = "code 읽기";
            this.code읽기ToolStripMenuItem.Click += new System.EventHandler(this.code읽기ToolStripMenuItem_Click_1);
            // 
            // code저장ToolStripMenuItem
            // 
            this.code저장ToolStripMenuItem.Name = "code저장ToolStripMenuItem";
            this.code저장ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.code저장ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.code저장ToolStripMenuItem.Text = "code 저장";
            this.code저장ToolStripMenuItem.Click += new System.EventHandler(this.code저장ToolStripMenuItem_Click_1);
            // 
            // 도구ToolStripMenuItem
            // 
            this.도구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.화면저장ToolStripMenuItem});
            this.도구ToolStripMenuItem.Name = "도구ToolStripMenuItem";
            this.도구ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.도구ToolStripMenuItem.Text = "도구";
            // 
            // 화면저장ToolStripMenuItem
            // 
            this.화면저장ToolStripMenuItem.Name = "화면저장ToolStripMenuItem";
            this.화면저장ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.화면저장ToolStripMenuItem.Text = "화면 저장";
            this.화면저장ToolStripMenuItem.Click += new System.EventHandler(this.화면저장ToolStripMenuItem_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(628, 384);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(127, 35);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "생성하기";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(625, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Axiom";
            // 
            // nbrStep
            // 
            this.nbrStep.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStep.Location = new System.Drawing.Point(675, 96);
            this.nbrStep.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nbrStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbrStep.Name = "nbrStep";
            this.nbrStep.Size = new System.Drawing.Size(120, 25);
            this.nbrStep.TabIndex = 10;
            this.nbrStep.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nbrStep.ValueChanged += new System.EventHandler(this.nbrStep_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(625, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Step";
            // 
            // tbDivergenceAngle1
            // 
            this.tbDivergenceAngle1.Location = new System.Drawing.Point(793, 129);
            this.tbDivergenceAngle1.Maximum = 360;
            this.tbDivergenceAngle1.Name = "tbDivergenceAngle1";
            this.tbDivergenceAngle1.Size = new System.Drawing.Size(250, 45);
            this.tbDivergenceAngle1.TabIndex = 12;
            this.tbDivergenceAngle1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbDivergenceAngle1.Value = 179;
            this.tbDivergenceAngle1.Scroll += new System.EventHandler(this.tbDivergenceAngle1_Scroll);
            // 
            // lbDivergenceAngle1
            // 
            this.lbDivergenceAngle1.AutoSize = true;
            this.lbDivergenceAngle1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDivergenceAngle1.Location = new System.Drawing.Point(625, 129);
            this.lbDivergenceAngle1.Name = "lbDivergenceAngle1";
            this.lbDivergenceAngle1.Size = new System.Drawing.Size(136, 18);
            this.lbDivergenceAngle1.TabIndex = 13;
            this.lbDivergenceAngle1.Text = "DivergenceAngle1";
            // 
            // lbDivergenceAngle2
            // 
            this.lbDivergenceAngle2.AutoSize = true;
            this.lbDivergenceAngle2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDivergenceAngle2.Location = new System.Drawing.Point(625, 156);
            this.lbDivergenceAngle2.Name = "lbDivergenceAngle2";
            this.lbDivergenceAngle2.Size = new System.Drawing.Size(136, 18);
            this.lbDivergenceAngle2.TabIndex = 14;
            this.lbDivergenceAngle2.Text = "DivergenceAngle2";
            // 
            // tbDivergenceAngle2
            // 
            this.tbDivergenceAngle2.Location = new System.Drawing.Point(793, 156);
            this.tbDivergenceAngle2.Maximum = 360;
            this.tbDivergenceAngle2.Name = "tbDivergenceAngle2";
            this.tbDivergenceAngle2.Size = new System.Drawing.Size(250, 45);
            this.tbDivergenceAngle2.TabIndex = 15;
            this.tbDivergenceAngle2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbDivergenceAngle2.Value = 252;
            this.tbDivergenceAngle2.Scroll += new System.EventHandler(this.tbDivergenceAngle2_Scroll);
            // 
            // lbBranchingAngle
            // 
            this.lbBranchingAngle.AutoSize = true;
            this.lbBranchingAngle.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBranchingAngle.Location = new System.Drawing.Point(625, 183);
            this.lbBranchingAngle.Name = "lbBranchingAngle";
            this.lbBranchingAngle.Size = new System.Drawing.Size(120, 18);
            this.lbBranchingAngle.TabIndex = 16;
            this.lbBranchingAngle.Text = "BranchingAngle";
            // 
            // tbBranchingAngle
            // 
            this.tbBranchingAngle.Location = new System.Drawing.Point(793, 183);
            this.tbBranchingAngle.Maximum = 90;
            this.tbBranchingAngle.Name = "tbBranchingAngle";
            this.tbBranchingAngle.Size = new System.Drawing.Size(250, 45);
            this.tbBranchingAngle.TabIndex = 17;
            this.tbBranchingAngle.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBranchingAngle.Value = 35;
            this.tbBranchingAngle.Scroll += new System.EventHandler(this.tbBranchingAngle_Scroll);
            // 
            // tbElongationRate
            // 
            this.tbElongationRate.Location = new System.Drawing.Point(793, 210);
            this.tbElongationRate.Maximum = 2000;
            this.tbElongationRate.Minimum = 1000;
            this.tbElongationRate.Name = "tbElongationRate";
            this.tbElongationRate.Size = new System.Drawing.Size(250, 45);
            this.tbElongationRate.TabIndex = 19;
            this.tbElongationRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbElongationRate.Value = 1700;
            this.tbElongationRate.Scroll += new System.EventHandler(this.tbElongationRate_Scroll);
            // 
            // lbElongationRate
            // 
            this.lbElongationRate.AutoSize = true;
            this.lbElongationRate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbElongationRate.Location = new System.Drawing.Point(625, 210);
            this.lbElongationRate.Name = "lbElongationRate";
            this.lbElongationRate.Size = new System.Drawing.Size(120, 18);
            this.lbElongationRate.TabIndex = 18;
            this.lbElongationRate.Text = "ElongationRate";
            // 
            // tbWidthIncreaseRate
            // 
            this.tbWidthIncreaseRate.Location = new System.Drawing.Point(793, 237);
            this.tbWidthIncreaseRate.Maximum = 9000;
            this.tbWidthIncreaseRate.Minimum = 1000;
            this.tbWidthIncreaseRate.Name = "tbWidthIncreaseRate";
            this.tbWidthIncreaseRate.Size = new System.Drawing.Size(250, 45);
            this.tbWidthIncreaseRate.TabIndex = 21;
            this.tbWidthIncreaseRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbWidthIncreaseRate.Value = 1070;
            this.tbWidthIncreaseRate.Scroll += new System.EventHandler(this.tbWidthIncreaseRate_Scroll);
            // 
            // lbWidthIncreaseRate
            // 
            this.lbWidthIncreaseRate.AutoSize = true;
            this.lbWidthIncreaseRate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWidthIncreaseRate.Location = new System.Drawing.Point(625, 237);
            this.lbWidthIncreaseRate.Name = "lbWidthIncreaseRate";
            this.lbWidthIncreaseRate.Size = new System.Drawing.Size(144, 18);
            this.lbWidthIncreaseRate.TabIndex = 20;
            this.lbWidthIncreaseRate.Text = "WidthIncreaseRate";
            // 
            // caTrophism
            // 
            this.caTrophism.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.caTrophism.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.caTrophism.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.caTrophism.Location = new System.Drawing.Point(978, 270);
            this.caTrophism.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.caTrophism.Name = "caTrophism";
            this.caTrophism.Size = new System.Drawing.Size(64, 62);
            this.caTrophism.TabIndex = 22;
            this.caTrophism.Value = 45;
            this.caTrophism.ValueChanged += new System.EventHandler(this.caTrophism_ValueChanged);
            // 
            // lbTrophismVector
            // 
            this.lbTrophismVector.AutoSize = true;
            this.lbTrophismVector.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrophismVector.Location = new System.Drawing.Point(625, 270);
            this.lbTrophismVector.Name = "lbTrophismVector";
            this.lbTrophismVector.Size = new System.Drawing.Size(136, 18);
            this.lbTrophismVector.TabIndex = 23;
            this.lbTrophismVector.Text = "TropismVecLength";
            // 
            // lbBendingConstant
            // 
            this.lbBendingConstant.AutoSize = true;
            this.lbBendingConstant.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBendingConstant.Location = new System.Drawing.Point(625, 300);
            this.lbBendingConstant.Name = "lbBendingConstant";
            this.lbBendingConstant.Size = new System.Drawing.Size(128, 18);
            this.lbBendingConstant.TabIndex = 24;
            this.lbBendingConstant.Text = "BendingConstant";
            // 
            // tbVectorLength
            // 
            this.tbVectorLength.Location = new System.Drawing.Point(809, 270);
            this.tbVectorLength.Maximum = 10000;
            this.tbVectorLength.Minimum = 100;
            this.tbVectorLength.Name = "tbVectorLength";
            this.tbVectorLength.Size = new System.Drawing.Size(149, 45);
            this.tbVectorLength.TabIndex = 26;
            this.tbVectorLength.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbVectorLength.Value = 100;
            this.tbVectorLength.Scroll += new System.EventHandler(this.tbVectorLength_Scroll);
            // 
            // tbBendingConstant
            // 
            this.tbBendingConstant.Location = new System.Drawing.Point(809, 300);
            this.tbBendingConstant.Maximum = 1000;
            this.tbBendingConstant.Name = "tbBendingConstant";
            this.tbBendingConstant.Size = new System.Drawing.Size(149, 45);
            this.tbBendingConstant.TabIndex = 27;
            this.tbBendingConstant.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBendingConstant.Value = 33;
            this.tbBendingConstant.Scroll += new System.EventHandler(this.tbBendingConstant_Scroll);
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(628, 343);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(127, 35);
            this.btnRandom.TabIndex = 28;
            this.btnRandom.Text = "랜덤설정";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(628, 425);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(628, 577);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 146);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tbLeafWidth
            // 
            this.tbLeafWidth.Location = new System.Drawing.Point(794, 446);
            this.tbLeafWidth.Maximum = 1000;
            this.tbLeafWidth.Name = "tbLeafWidth";
            this.tbLeafWidth.Size = new System.Drawing.Size(248, 45);
            this.tbLeafWidth.TabIndex = 32;
            this.tbLeafWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbLeafWidth.Value = 33;
            this.tbLeafWidth.Scroll += new System.EventHandler(this.tbLeafWidth_Scroll);
            // 
            // lbLeafWidth
            // 
            this.lbLeafWidth.AutoSize = true;
            this.lbLeafWidth.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeafWidth.Location = new System.Drawing.Point(791, 425);
            this.lbLeafWidth.Name = "lbLeafWidth";
            this.lbLeafWidth.Size = new System.Drawing.Size(80, 18);
            this.lbLeafWidth.TabIndex = 31;
            this.lbLeafWidth.Text = "LeafWidth";
            // 
            // tbLeafHeight
            // 
            this.tbLeafHeight.Location = new System.Drawing.Point(794, 494);
            this.tbLeafHeight.Maximum = 1000;
            this.tbLeafHeight.Name = "tbLeafHeight";
            this.tbLeafHeight.Size = new System.Drawing.Size(248, 45);
            this.tbLeafHeight.TabIndex = 34;
            this.tbLeafHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbLeafHeight.Value = 33;
            this.tbLeafHeight.Scroll += new System.EventHandler(this.tbLeafHeight_Scroll);
            // 
            // lbLeafHeight
            // 
            this.lbLeafHeight.AutoSize = true;
            this.lbLeafHeight.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeafHeight.Location = new System.Drawing.Point(791, 473);
            this.lbLeafHeight.Name = "lbLeafHeight";
            this.lbLeafHeight.Size = new System.Drawing.Size(88, 18);
            this.lbLeafHeight.TabIndex = 33;
            this.lbLeafHeight.Text = "LeafHeight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(806, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Step";
            // 
            // nmLeafRotCount
            // 
            this.nmLeafRotCount.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmLeafRotCount.Location = new System.Drawing.Point(856, 530);
            this.nmLeafRotCount.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nmLeafRotCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmLeafRotCount.Name = "nmLeafRotCount";
            this.nmLeafRotCount.Size = new System.Drawing.Size(120, 25);
            this.nmLeafRotCount.TabIndex = 35;
            this.nmLeafRotCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmLeafRotCount.ValueChanged += new System.EventHandler(this.nmLeafRotCount_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(794, 688);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 35);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "저장하기";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nbrResolution
            // 
            this.nbrResolution.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrResolution.Location = new System.Drawing.Point(900, 96);
            this.nbrResolution.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.nbrResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbrResolution.Name = "nbrResolution";
            this.nbrResolution.Size = new System.Drawing.Size(120, 25);
            this.nbrResolution.TabIndex = 38;
            this.nbrResolution.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nbrResolution.ValueChanged += new System.EventHandler(this.nbrResolution_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(806, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Resolution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(625, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(675, 35);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(368, 25);
            this.tbName.TabIndex = 41;
            this.tbName.Text = "treeTest";
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // Form3L
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1055, 763);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nbrResolution);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmLeafRotCount);
            this.Controls.Add(this.tbLeafHeight);
            this.Controls.Add(this.lbLeafHeight);
            this.Controls.Add(this.tbLeafWidth);
            this.Controls.Add(this.lbLeafWidth);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.tbBendingConstant);
            this.Controls.Add(this.tbVectorLength);
            this.Controls.Add(this.lbBendingConstant);
            this.Controls.Add(this.lbTrophismVector);
            this.Controls.Add(this.caTrophism);
            this.Controls.Add(this.tbWidthIncreaseRate);
            this.Controls.Add(this.lbWidthIncreaseRate);
            this.Controls.Add(this.tbElongationRate);
            this.Controls.Add(this.lbElongationRate);
            this.Controls.Add(this.tbBranchingAngle);
            this.Controls.Add(this.lbBranchingAngle);
            this.Controls.Add(this.tbDivergenceAngle2);
            this.Controls.Add(this.lbDivergenceAngle2);
            this.Controls.Add(this.lbDivergenceAngle1);
            this.Controls.Add(this.tbDivergenceAngle1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nbrStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3L";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3L";
            this.Load += new System.EventHandler(this.Form3L_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBranchingAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbElongationRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWidthIncreaseRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVectorLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBendingConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeafWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeafHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmLeafRotCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenGL.GlControl glControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem code읽기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem code저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화면저장ToolStripMenuItem;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nbrStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbDivergenceAngle1;
        private System.Windows.Forms.Label lbDivergenceAngle1;
        private System.Windows.Forms.Label lbDivergenceAngle2;
        private System.Windows.Forms.TrackBar tbDivergenceAngle2;
        private System.Windows.Forms.Label lbBranchingAngle;
        private System.Windows.Forms.TrackBar tbBranchingAngle;
        private System.Windows.Forms.TrackBar tbElongationRate;
        private System.Windows.Forms.Label lbElongationRate;
        private System.Windows.Forms.TrackBar tbWidthIncreaseRate;
        private System.Windows.Forms.Label lbWidthIncreaseRate;
        private System.Windows.Forms.CircleAnglePicker caTrophism;
        private System.Windows.Forms.Label lbTrophismVector;
        private System.Windows.Forms.Label lbBendingConstant;
        private System.Windows.Forms.TrackBar tbVectorLength;
        private System.Windows.Forms.TrackBar tbBendingConstant;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar tbLeafWidth;
        private System.Windows.Forms.Label lbLeafWidth;
        private System.Windows.Forms.TrackBar tbLeafHeight;
        private System.Windows.Forms.Label lbLeafHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmLeafRotCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nbrResolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
    }
}