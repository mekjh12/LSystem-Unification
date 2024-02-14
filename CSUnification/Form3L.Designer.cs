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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDivergenceAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBranchingAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbElongationRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWidthIncreaseRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVectorLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBendingConstant)).BeginInit();
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
            this.glControl1.Size = new System.Drawing.Size(614, 658);
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
            this.textBox1.Location = new System.Drawing.Point(675, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "!(1)F(200)/(45)A";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(761, 348);
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
            this.code읽기ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.code읽기ToolStripMenuItem.Text = "code 읽기";
            this.code읽기ToolStripMenuItem.Click += new System.EventHandler(this.code읽기ToolStripMenuItem_Click_1);
            // 
            // code저장ToolStripMenuItem
            // 
            this.code저장ToolStripMenuItem.Name = "code저장ToolStripMenuItem";
            this.code저장ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.btnCreate.Location = new System.Drawing.Point(628, 348);
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
            this.label1.Location = new System.Drawing.Point(625, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Axiom";
            // 
            // nbrStep
            // 
            this.nbrStep.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStep.Location = new System.Drawing.Point(675, 60);
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
            this.label2.Location = new System.Drawing.Point(625, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Step";
            // 
            // tbDivergenceAngle1
            // 
            this.tbDivergenceAngle1.Location = new System.Drawing.Point(793, 93);
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
            this.lbDivergenceAngle1.Location = new System.Drawing.Point(625, 93);
            this.lbDivergenceAngle1.Name = "lbDivergenceAngle1";
            this.lbDivergenceAngle1.Size = new System.Drawing.Size(136, 18);
            this.lbDivergenceAngle1.TabIndex = 13;
            this.lbDivergenceAngle1.Text = "DivergenceAngle1";
            // 
            // lbDivergenceAngle2
            // 
            this.lbDivergenceAngle2.AutoSize = true;
            this.lbDivergenceAngle2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDivergenceAngle2.Location = new System.Drawing.Point(625, 120);
            this.lbDivergenceAngle2.Name = "lbDivergenceAngle2";
            this.lbDivergenceAngle2.Size = new System.Drawing.Size(136, 18);
            this.lbDivergenceAngle2.TabIndex = 14;
            this.lbDivergenceAngle2.Text = "DivergenceAngle2";
            // 
            // tbDivergenceAngle2
            // 
            this.tbDivergenceAngle2.Location = new System.Drawing.Point(793, 120);
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
            this.lbBranchingAngle.Location = new System.Drawing.Point(625, 147);
            this.lbBranchingAngle.Name = "lbBranchingAngle";
            this.lbBranchingAngle.Size = new System.Drawing.Size(120, 18);
            this.lbBranchingAngle.TabIndex = 16;
            this.lbBranchingAngle.Text = "BranchingAngle";
            // 
            // tbBranchingAngle
            // 
            this.tbBranchingAngle.Location = new System.Drawing.Point(793, 147);
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
            this.tbElongationRate.Location = new System.Drawing.Point(793, 174);
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
            this.lbElongationRate.Location = new System.Drawing.Point(625, 174);
            this.lbElongationRate.Name = "lbElongationRate";
            this.lbElongationRate.Size = new System.Drawing.Size(120, 18);
            this.lbElongationRate.TabIndex = 18;
            this.lbElongationRate.Text = "ElongationRate";
            // 
            // tbWidthIncreaseRate
            // 
            this.tbWidthIncreaseRate.Location = new System.Drawing.Point(793, 201);
            this.tbWidthIncreaseRate.Maximum = 2000;
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
            this.lbWidthIncreaseRate.Location = new System.Drawing.Point(625, 201);
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
            this.caTrophism.Location = new System.Drawing.Point(978, 234);
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
            this.lbTrophismVector.Location = new System.Drawing.Point(625, 234);
            this.lbTrophismVector.Name = "lbTrophismVector";
            this.lbTrophismVector.Size = new System.Drawing.Size(136, 18);
            this.lbTrophismVector.TabIndex = 23;
            this.lbTrophismVector.Text = "TropismVecLength";
            // 
            // lbBendingConstant
            // 
            this.lbBendingConstant.AutoSize = true;
            this.lbBendingConstant.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBendingConstant.Location = new System.Drawing.Point(625, 264);
            this.lbBendingConstant.Name = "lbBendingConstant";
            this.lbBendingConstant.Size = new System.Drawing.Size(128, 18);
            this.lbBendingConstant.TabIndex = 24;
            this.lbBendingConstant.Text = "BendingConstant";
            // 
            // tbVectorLength
            // 
            this.tbVectorLength.Location = new System.Drawing.Point(809, 234);
            this.tbVectorLength.Maximum = 1000;
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
            this.tbBendingConstant.Location = new System.Drawing.Point(809, 264);
            this.tbBendingConstant.Maximum = 1000;
            this.tbBendingConstant.Name = "tbBendingConstant";
            this.tbBendingConstant.Size = new System.Drawing.Size(149, 45);
            this.tbBendingConstant.TabIndex = 27;
            this.tbBendingConstant.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBendingConstant.Value = 33;
            this.tbBendingConstant.Scroll += new System.EventHandler(this.tbBendingConstant_Scroll);
            // 
            // Form3L
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1055, 697);
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
    }
}