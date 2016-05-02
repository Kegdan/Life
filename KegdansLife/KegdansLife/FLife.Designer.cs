namespace KegdansLife
{
    partial class FLife
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
            this.mTBFieldSize = new System.Windows.Forms.MaskedTextBox();
            this.bSetFieldSize = new System.Windows.Forms.Button();
            this.cBIsSetAlive = new System.Windows.Forms.CheckBox();
            this.bNextStep = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mTBFieldSize
            // 
            this.mTBFieldSize.Location = new System.Drawing.Point(615, 12);
            this.mTBFieldSize.Mask = "00";
            this.mTBFieldSize.Name = "mTBFieldSize";
            this.mTBFieldSize.Size = new System.Drawing.Size(20, 20);
            this.mTBFieldSize.TabIndex = 0;
            // 
            // bSetFieldSize
            // 
            this.bSetFieldSize.Location = new System.Drawing.Point(549, 38);
            this.bSetFieldSize.Name = "bSetFieldSize";
            this.bSetFieldSize.Size = new System.Drawing.Size(86, 26);
            this.bSetFieldSize.TabIndex = 1;
            this.bSetFieldSize.Text = "Set field size";
            this.bSetFieldSize.UseVisualStyleBackColor = true;
            this.bSetFieldSize.Click += new System.EventHandler(this.bSetFieldSize_Click);
            // 
            // cBIsSetAlive
            // 
            this.cBIsSetAlive.AutoSize = true;
            this.cBIsSetAlive.Checked = true;
            this.cBIsSetAlive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBIsSetAlive.Location = new System.Drawing.Point(554, 75);
            this.cBIsSetAlive.Name = "cBIsSetAlive";
            this.cBIsSetAlive.Size = new System.Drawing.Size(86, 17);
            this.cBIsSetAlive.TabIndex = 2;
            this.cBIsSetAlive.Text = "Set alive cell";
            this.cBIsSetAlive.UseVisualStyleBackColor = true;
            this.cBIsSetAlive.CheckedChanged += new System.EventHandler(this.cBIsSetAlive_CheckedChanged);
            // 
            // bNextStep
            // 
            this.bNextStep.Location = new System.Drawing.Point(549, 98);
            this.bNextStep.Name = "bNextStep";
            this.bNextStep.Size = new System.Drawing.Size(86, 29);
            this.bNextStep.TabIndex = 3;
            this.bNextStep.Text = "Next step";
            this.bNextStep.UseVisualStyleBackColor = true;
            this.bNextStep.Click += new System.EventHandler(this.bNextStep_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(549, 133);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(86, 29);
            this.bClear.TabIndex = 4;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(549, 168);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(86, 26);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bNextXStep_Click);
            // 
            // bCancel
            // 
            this.bCancel.Enabled = false;
            this.bCancel.Location = new System.Drawing.Point(549, 200);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(86, 32);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // FLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 529);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bNextStep);
            this.Controls.Add(this.cBIsSetAlive);
            this.Controls.Add(this.bSetFieldSize);
            this.Controls.Add(this.mTBFieldSize);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FLife";
            this.Text = "Kegdan\'s life (torsion edition)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mTBFieldSize;
        private System.Windows.Forms.Button bSetFieldSize;
        private System.Windows.Forms.CheckBox cBIsSetAlive;
        private System.Windows.Forms.Button bNextStep;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bCancel;
    }
}

