namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    partial class MainForm
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
            this.m_world.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openglControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timerRotaion = new System.Windows.Forms.Timer(this.components);
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.panelControls = new System.Windows.Forms.Panel();
            this.domainUpDownScaleZ = new System.Windows.Forms.NumericUpDown();
            this.labelScaleY = new System.Windows.Forms.Label();
            this.domainUpDownScaleX = new System.Windows.Forms.NumericUpDown();
            this.domainUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.domainUpDownRotation = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelRotation = new System.Windows.Forms.Label();
            this.labelScaleX = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownScaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownRotation)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl
            // 
            this.openglControl.AccumBits = ((byte)(0));
            this.openglControl.AutoCheckErrors = false;
            this.openglControl.AutoFinish = false;
            this.openglControl.AutoMakeCurrent = true;
            this.openglControl.AutoSwapBuffers = true;
            this.openglControl.BackColor = System.Drawing.Color.Black;
            this.openglControl.ColorBits = ((byte)(32));
            this.openglControl.DepthBits = ((byte)(16));
            this.openglControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openglControl.Location = new System.Drawing.Point(0, 0);
            this.openglControl.Name = "openglControl";
            this.openglControl.Size = new System.Drawing.Size(784, 561);
            this.openglControl.StencilBits = ((byte)(0));
            this.openglControl.TabIndex = 1;
            this.openglControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.openglControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGlControlKeyDown);
            this.openglControl.Resize += new System.EventHandler(this.OpenGlControlResize);
            // 
            // timerRotaion
            // 
            this.timerRotaion.Enabled = true;
            this.timerRotaion.Tick += new System.EventHandler(this.timerRotaion_Tick);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.domainUpDownScaleZ);
            this.panelControls.Controls.Add(this.labelScaleY);
            this.panelControls.Controls.Add(this.domainUpDownScaleX);
            this.panelControls.Controls.Add(this.domainUpDownHeight);
            this.panelControls.Controls.Add(this.domainUpDownRotation);
            this.panelControls.Controls.Add(this.labelHeight);
            this.panelControls.Controls.Add(this.labelRotation);
            this.panelControls.Controls.Add(this.labelScaleX);
            this.panelControls.Location = new System.Drawing.Point(0, 439);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(143, 122);
            this.panelControls.TabIndex = 3;
            // 
            // domainUpDownScaleZ
            // 
            this.domainUpDownScaleZ.DecimalPlaces = 1;
            this.domainUpDownScaleZ.Increment = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.domainUpDownScaleZ.Location = new System.Drawing.Point(75, 90);
            this.domainUpDownScaleZ.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.domainUpDownScaleZ.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.domainUpDownScaleZ.Name = "domainUpDownScaleZ";
            this.domainUpDownScaleZ.Size = new System.Drawing.Size(52, 20);
            this.domainUpDownScaleZ.TabIndex = 4;
            this.domainUpDownScaleZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDownScaleZ.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.domainUpDownScaleZ.ValueChanged += new System.EventHandler(this.domainUpDownScaleZ_ValueChanged);
            // 
            // labelScaleY
            // 
            this.labelScaleY.AutoSize = true;
            this.labelScaleY.Location = new System.Drawing.Point(19, 92);
            this.labelScaleY.Name = "labelScaleY";
            this.labelScaleY.Size = new System.Drawing.Size(47, 13);
            this.labelScaleY.TabIndex = 13;
            this.labelScaleY.Text = "Scale Y:";
            // 
            // domainUpDownScaleX
            // 
            this.domainUpDownScaleX.DecimalPlaces = 1;
            this.domainUpDownScaleX.Increment = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.domainUpDownScaleX.Location = new System.Drawing.Point(75, 64);
            this.domainUpDownScaleX.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.domainUpDownScaleX.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.domainUpDownScaleX.Name = "domainUpDownScaleX";
            this.domainUpDownScaleX.Size = new System.Drawing.Size(52, 20);
            this.domainUpDownScaleX.TabIndex = 3;
            this.domainUpDownScaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDownScaleX.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.domainUpDownScaleX.ValueChanged += new System.EventHandler(this.domainUpDownScaleX_ValueChanged);
            // 
            // domainUpDownHeight
            // 
            this.domainUpDownHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.domainUpDownHeight.Location = new System.Drawing.Point(75, 12);
            this.domainUpDownHeight.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.domainUpDownHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            -2147483648});
            this.domainUpDownHeight.Name = "domainUpDownHeight";
            this.domainUpDownHeight.Size = new System.Drawing.Size(52, 20);
            this.domainUpDownHeight.TabIndex = 1;
            this.domainUpDownHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDownHeight.ValueChanged += new System.EventHandler(this.domainUpDownHeight_ValueChanged);
            // 
            // domainUpDownRotation
            // 
            this.domainUpDownRotation.Location = new System.Drawing.Point(75, 38);
            this.domainUpDownRotation.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.domainUpDownRotation.Name = "domainUpDownRotation";
            this.domainUpDownRotation.Size = new System.Drawing.Size(52, 20);
            this.domainUpDownRotation.TabIndex = 2;
            this.domainUpDownRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDownRotation.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.domainUpDownRotation.ValueChanged += new System.EventHandler(this.domainUpDownRotation_ValueChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(25, 14);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(41, 13);
            this.labelHeight.TabIndex = 8;
            this.labelHeight.Text = "Height:";
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Location = new System.Drawing.Point(16, 40);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(50, 13);
            this.labelRotation.TabIndex = 5;
            this.labelRotation.Text = "Rotation:";
            // 
            // labelScaleX
            // 
            this.labelScaleX.AutoSize = true;
            this.labelScaleX.Location = new System.Drawing.Point(19, 66);
            this.labelScaleX.Name = "labelScaleX";
            this.labelScaleX.Size = new System.Drawing.Size(47, 13);
            this.labelScaleX.TabIndex = 3;
            this.labelScaleX.Text = "Scale X:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.openglControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Svemirski brod";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownScaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainUpDownRotation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openglControl;
        private System.Windows.Forms.Timer timerRotaion;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.NumericUpDown domainUpDownScaleX;
        private System.Windows.Forms.NumericUpDown domainUpDownHeight;
        private System.Windows.Forms.NumericUpDown domainUpDownRotation;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelRotation;
        private System.Windows.Forms.Label labelScaleX;
        private System.Windows.Forms.NumericUpDown domainUpDownScaleZ;
        private System.Windows.Forms.Label labelScaleY;
    }
}

