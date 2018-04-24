namespace Forest
{
    partial class DeleteCheckDialog
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
            this.labelDeleteMessage = new System.Windows.Forms.Label();
            this.deleteMemberList = new System.Windows.Forms.DataGridView();
            this.deleteMemberListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteMemberListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteMemberListGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteMemberListLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deleteMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDeleteMessage
            // 
            this.labelDeleteMessage.AutoSize = true;
            this.labelDeleteMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteMessage.Location = new System.Drawing.Point(26, 9);
            this.labelDeleteMessage.Name = "labelDeleteMessage";
            this.labelDeleteMessage.Size = new System.Drawing.Size(258, 19);
            this.labelDeleteMessage.TabIndex = 0;
            this.labelDeleteMessage.Text = "以下のメンバーを削除してよろしいですか？";
            // 
            // deleteMemberList
            // 
            this.deleteMemberList.AllowUserToAddRows = false;
            this.deleteMemberList.AllowUserToDeleteRows = false;
            this.deleteMemberList.AllowUserToResizeColumns = false;
            this.deleteMemberList.AllowUserToResizeRows = false;
            this.deleteMemberList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deleteMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deleteMemberListId,
            this.deleteMemberListName,
            this.deleteMemberListGender,
            this.deleteMemberListLevel});
            this.deleteMemberList.Location = new System.Drawing.Point(30, 40);
            this.deleteMemberList.Name = "deleteMemberList";
            this.deleteMemberList.RowHeadersVisible = false;
            this.deleteMemberList.RowTemplate.Height = 21;
            this.deleteMemberList.Size = new System.Drawing.Size(305, 359);
            this.deleteMemberList.TabIndex = 4;
            // 
            // deleteMemberListId
            // 
            this.deleteMemberListId.HeaderText = "ID";
            this.deleteMemberListId.Name = "deleteMemberListId";
            this.deleteMemberListId.Visible = false;
            // 
            // deleteMemberListName
            // 
            this.deleteMemberListName.HeaderText = "名前";
            this.deleteMemberListName.Name = "deleteMemberListName";
            this.deleteMemberListName.ReadOnly = true;
            // 
            // deleteMemberListGender
            // 
            this.deleteMemberListGender.HeaderText = "性別";
            this.deleteMemberListGender.Name = "deleteMemberListGender";
            this.deleteMemberListGender.ReadOnly = true;
            // 
            // deleteMemberListLevel
            // 
            this.deleteMemberListLevel.HeaderText = "レベル";
            this.deleteMemberListLevel.Name = "deleteMemberListLevel";
            this.deleteMemberListLevel.ReadOnly = true;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stopButton.Location = new System.Drawing.Point(276, 426);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "中止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.Stop);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deleteButton.Location = new System.Drawing.Point(189, 426);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.Delete);
            // 
            // DeleteCheckDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 461);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.deleteMemberList);
            this.Controls.Add(this.labelDeleteMessage);
            this.Name = "DeleteCheckDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteCheckDialog";
            this.Load += new System.EventHandler(this.LoadDeleteCheckDialog);
            ((System.ComponentModel.ISupportInitialize)(this.deleteMemberList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeleteMessage;
        private System.Windows.Forms.DataGridView deleteMemberList;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteMemberListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteMemberListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteMemberListGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteMemberListLevel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button deleteButton;
    }
}