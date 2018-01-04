namespace ToDelLibrary
{
    partial class Feedback
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
            this.Working = new System.Windows.Forms.CheckBox();
            this.Friends = new System.Windows.Forms.CheckBox();
            this.Likes = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Working
            // 
            this.Working.AutoSize = true;
            this.Working.Location = new System.Drawing.Point(12, 12);
            this.Working.Name = "Working";
            this.Working.Size = new System.Drawing.Size(66, 17);
            this.Working.TabIndex = 0;
            this.Working.Text = "Working";
            this.Working.UseVisualStyleBackColor = true;
            // 
            // Friends
            // 
            this.Friends.AutoSize = true;
            this.Friends.Location = new System.Drawing.Point(12, 66);
            this.Friends.Name = "Friends";
            this.Friends.Size = new System.Drawing.Size(60, 17);
            this.Friends.TabIndex = 1;
            this.Friends.Text = "Friends";
            this.Friends.UseVisualStyleBackColor = true;
            // 
            // Likes
            // 
            this.Likes.AutoSize = true;
            this.Likes.Location = new System.Drawing.Point(12, 89);
            this.Likes.Name = "Likes";
            this.Likes.Size = new System.Drawing.Size(51, 17);
            this.Likes.TabIndex = 2;
            this.Likes.Text = "Likes";
            this.Likes.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(12, 135);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(12, 112);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.Likes);
            this.Controls.Add(this.Friends);
            this.Controls.Add(this.Working);
            this.Name = "Feedback";
            this.Text = "Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox Working;
        public System.Windows.Forms.CheckBox Friends;
        public System.Windows.Forms.CheckBox Likes;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.CheckBox checkBox5;
    }
}