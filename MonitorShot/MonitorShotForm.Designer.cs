
namespace MonitorShot
{
    partial class MonitorShotForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.embedTime = new System.Windows.Forms.CheckBox();
            this.showCursorPosition = new System.Windows.Forms.CheckBox();
            this.shotButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // embedTime
            // 
            this.embedTime.AutoSize = true;
            this.embedTime.Checked = true;
            this.embedTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.embedTime.Location = new System.Drawing.Point(12, 12);
            this.embedTime.Name = "embedTime";
            this.embedTime.Size = new System.Drawing.Size(101, 16);
            this.embedTime.TabIndex = 0;
            this.embedTime.Text = "時刻を埋め込む";
            this.embedTime.UseVisualStyleBackColor = true;
            // 
            // showCursorPosition
            // 
            this.showCursorPosition.AutoSize = true;
            this.showCursorPosition.Checked = true;
            this.showCursorPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCursorPosition.Location = new System.Drawing.Point(12, 34);
            this.showCursorPosition.Name = "showCursorPosition";
            this.showCursorPosition.Size = new System.Drawing.Size(119, 16);
            this.showCursorPosition.TabIndex = 1;
            this.showCursorPosition.Text = "カーソル位置を表示";
            this.showCursorPosition.UseVisualStyleBackColor = true;
            // 
            // shotButton
            // 
            this.shotButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shotButton.Location = new System.Drawing.Point(161, 12);
            this.shotButton.Name = "shotButton";
            this.shotButton.Size = new System.Drawing.Size(225, 38);
            this.shotButton.TabIndex = 2;
            this.shotButton.Text = "スクショ取得";
            this.shotButton.UseVisualStyleBackColor = true;
            this.shotButton.Click += new System.EventHandler(this.shotButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logTextBox.Location = new System.Drawing.Point(0, 69);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(398, 94);
            this.logTextBox.TabIndex = 3;
            // 
            // MonitorShotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 163);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.shotButton);
            this.Controls.Add(this.showCursorPosition);
            this.Controls.Add(this.embedTime);
            this.Name = "MonitorShotForm";
            this.Text = "MonitorShot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorShotForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox embedTime;
        private System.Windows.Forms.CheckBox showCursorPosition;
        private System.Windows.Forms.Button shotButton;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

