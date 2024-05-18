namespace GraphBase
{
    partial class Manual
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            vScrollBar1 = new VScrollBar();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 82);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 223);
            textBox1.TabIndex = 0;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(347, 82);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(34, 223);
            vScrollBar1.TabIndex = 1;
            // 
            // Manual
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(vScrollBar1);
            Controls.Add(textBox1);
            Name = "Manual";
            Size = new Size(503, 413);
            Load += Manual_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private VScrollBar vScrollBar1;
    }
}
