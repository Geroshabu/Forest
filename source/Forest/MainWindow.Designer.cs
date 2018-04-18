namespace Forest
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.memberLabel = new System.Windows.Forms.Label();
            this.attendMemberLabel = new System.Windows.Forms.Label();
            this.memberCountLabel = new System.Windows.Forms.Label();
            this.allMemberList = new System.Windows.Forms.DataGridView();
            this.attendMemberList = new System.Windows.Forms.DataGridView();
            this.attendMemberListCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.attendMemberListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendMemberListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendMemberListGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendMemberListLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendButton = new System.Windows.Forms.Button();
            this.attendCancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.allMemberListCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allMemberListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allMemberListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allMemberListGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allMemberListLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.allMemberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendMemberList)).BeginInit();
            this.SuspendLayout();
            // 
            // memberLabel
            // 
            this.memberLabel.AutoSize = true;
            this.memberLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberLabel.Location = new System.Drawing.Point(12, 28);
            this.memberLabel.Name = "memberLabel";
            this.memberLabel.Size = new System.Drawing.Size(80, 26);
            this.memberLabel.TabIndex = 0;
            this.memberLabel.Text = "メンバー";
            this.memberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // attendMemberLabel
            // 
            this.attendMemberLabel.AutoSize = true;
            this.attendMemberLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendMemberLabel.Location = new System.Drawing.Point(501, 28);
            this.attendMemberLabel.Name = "attendMemberLabel";
            this.attendMemberLabel.Size = new System.Drawing.Size(124, 26);
            this.attendMemberLabel.TabIndex = 1;
            this.attendMemberLabel.Text = "参加メンバー";
            this.attendMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memberCountLabel
            // 
            this.memberCountLabel.AutoSize = true;
            this.memberCountLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberCountLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.memberCountLabel.Location = new System.Drawing.Point(201, 63);
            this.memberCountLabel.Name = "memberCountLabel";
            this.memberCountLabel.Size = new System.Drawing.Size(164, 19);
            this.memberCountLabel.TabIndex = 2;
            this.memberCountLabel.Text = "登録人数を表示するところ";
            this.memberCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // allMemberList
            // 
            this.allMemberList.AllowUserToAddRows = false;
            this.allMemberList.AllowUserToDeleteRows = false;
            this.allMemberList.AllowUserToResizeColumns = false;
            this.allMemberList.AllowUserToResizeRows = false;
            this.allMemberList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.allMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.allMemberListCheck,
            this.allMemberListId,
            this.allMemberListName,
            this.allMemberListGender,
            this.allMemberListLevel});
            this.allMemberList.Location = new System.Drawing.Point(12, 85);
            this.allMemberList.Name = "allMemberList";
            this.allMemberList.RowHeadersVisible = false;
            this.allMemberList.RowTemplate.Height = 21;
            this.allMemberList.Size = new System.Drawing.Size(353, 350);
            this.allMemberList.TabIndex = 3;
            this.allMemberList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ManageBelongedPersonList);
            this.allMemberList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.allMemberList_SortCompare);
            // 
            // attendMemberList
            // 
            this.attendMemberList.AllowUserToAddRows = false;
            this.attendMemberList.AllowUserToDeleteRows = false;
            this.attendMemberList.AllowUserToResizeColumns = false;
            this.attendMemberList.AllowUserToResizeRows = false;
            this.attendMemberList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.attendMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attendMemberListCheck,
            this.attendMemberListId,
            this.attendMemberListName,
            this.attendMemberListGender,
            this.attendMemberListLevel});
            this.attendMemberList.Location = new System.Drawing.Point(501, 85);
            this.attendMemberList.Name = "attendMemberList";
            this.attendMemberList.RowHeadersVisible = false;
            this.attendMemberList.RowTemplate.Height = 21;
            this.attendMemberList.Size = new System.Drawing.Size(353, 350);
            this.attendMemberList.TabIndex = 4;
            this.attendMemberList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ManageAttendedPersonList);
            // 
            // attendMemberListCheck
            // 
            this.attendMemberListCheck.HeaderText = "選択";
            this.attendMemberListCheck.Name = "attendMemberListCheck";
            this.attendMemberListCheck.Width = 50;
            // 
            // attendMemberListId
            // 
            this.attendMemberListId.HeaderText = "ID";
            this.attendMemberListId.Name = "attendMemberListId";
            this.attendMemberListId.Visible = false;
            // 
            // attendMemberListName
            // 
            this.attendMemberListName.HeaderText = "名前";
            this.attendMemberListName.Name = "attendMemberListName";
            this.attendMemberListName.ReadOnly = true;
            // 
            // attendMemberListGender
            // 
            this.attendMemberListGender.HeaderText = "性別";
            this.attendMemberListGender.Name = "attendMemberListGender";
            this.attendMemberListGender.ReadOnly = true;
            // 
            // attendMemberListLevel
            // 
            this.attendMemberListLevel.HeaderText = "レベル";
            this.attendMemberListLevel.Name = "attendMemberListLevel";
            this.attendMemberListLevel.ReadOnly = true;
            // 
            // attendButton
            // 
            this.attendButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendButton.Location = new System.Drawing.Point(388, 190);
            this.attendButton.Name = "attendButton";
            this.attendButton.Size = new System.Drawing.Size(90, 25);
            this.attendButton.TabIndex = 5;
            this.attendButton.Text = "→";
            this.attendButton.UseVisualStyleBackColor = true;
            this.attendButton.Click += new System.EventHandler(this.AddAttendedPersons);
            // 
            // attendCancelButton
            // 
            this.attendCancelButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendCancelButton.Location = new System.Drawing.Point(388, 298);
            this.attendCancelButton.Name = "attendCancelButton";
            this.attendCancelButton.Size = new System.Drawing.Size(90, 25);
            this.attendCancelButton.TabIndex = 6;
            this.attendCancelButton.Text = "←";
            this.attendCancelButton.UseVisualStyleBackColor = true;
            this.attendCancelButton.Click += new System.EventHandler(this.DeleteAttendedPersons);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(12, 501);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 25);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "追加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(151, 501);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 25);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(290, 501);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(90, 25);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "変更";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(764, 501);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 25);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "試合開始";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // allMemberListCheck
            // 
            this.allMemberListCheck.HeaderText = "選択";
            this.allMemberListCheck.Name = "allMemberListCheck";
            this.allMemberListCheck.Width = 50;
            // 
            // allMemberListId
            // 
            this.allMemberListId.HeaderText = "ID";
            this.allMemberListId.Name = "allMemberListId";
            this.allMemberListId.Visible = false;
            // 
            // allMemberListName
            // 
            this.allMemberListName.HeaderText = "名前";
            this.allMemberListName.Name = "allMemberListName";
            this.allMemberListName.ReadOnly = true;
            // 
            // allMemberListGender
            // 
            this.allMemberListGender.HeaderText = "性別";
            this.allMemberListGender.Name = "allMemberListGender";
            this.allMemberListGender.ReadOnly = true;
            // 
            // allMemberListLevel
            // 
            this.allMemberListLevel.HeaderText = "レベル";
            this.allMemberListLevel.Name = "allMemberListLevel";
            this.allMemberListLevel.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.attendCancelButton);
            this.Controls.Add(this.attendButton);
            this.Controls.Add(this.attendMemberList);
            this.Controls.Add(this.allMemberList);
            this.Controls.Add(this.memberCountLabel);
            this.Controls.Add(this.attendMemberLabel);
            this.Controls.Add(this.memberLabel);
            this.Name = "MainWindow";
            this.Text = "コート分けアプリ　参加メンバー登録";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allMemberList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendMemberList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label memberLabel;
        private System.Windows.Forms.Label attendMemberLabel;
        private System.Windows.Forms.Label memberCountLabel;
        private System.Windows.Forms.DataGridView allMemberList;
        private System.Windows.Forms.DataGridView attendMemberList;
        private System.Windows.Forms.Button attendButton;
        private System.Windows.Forms.Button attendCancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn attendMemberListCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendMemberListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendMemberListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendMemberListGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendMemberListLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allMemberListCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn allMemberListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn allMemberListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn allMemberListGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn allMemberListLevel;
    }
}

