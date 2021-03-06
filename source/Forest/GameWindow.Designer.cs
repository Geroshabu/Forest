﻿namespace Forest
{
    partial class GameWindow
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
            this.breakMemberList = new System.Windows.Forms.DataGridView();
            this.endGameButton = new System.Windows.Forms.Button();
            this.breakMemberLabel = new System.Windows.Forms.Label();
            this.courtNameLabel1 = new System.Windows.Forms.Label();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.courtNameLabel2 = new System.Windows.Forms.Label();
            this.playerNameLabel1 = new System.Windows.Forms.Label();
            this.playerNameLabel2 = new System.Windows.Forms.Label();
            this.playerNameLabel3 = new System.Windows.Forms.Label();
            this.playerNameLabel4 = new System.Windows.Forms.Label();
            this.breakMemberListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breakMemberListGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breakMemberListLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.breakMemberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // breakMemberList
            // 
            this.breakMemberList.AllowUserToAddRows = false;
            this.breakMemberList.AllowUserToDeleteRows = false;
            this.breakMemberList.AllowUserToResizeColumns = false;
            this.breakMemberList.AllowUserToResizeRows = false;
            this.breakMemberList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.breakMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.breakMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.breakMemberListName,
            this.breakMemberListGender,
            this.breakMemberListLevel});
            this.breakMemberList.Location = new System.Drawing.Point(518, 61);
            this.breakMemberList.Name = "breakMemberList";
            this.breakMemberList.RowHeadersVisible = false;
            this.breakMemberList.RowTemplate.Height = 21;
            this.breakMemberList.Size = new System.Drawing.Size(220, 230);
            this.breakMemberList.TabIndex = 5;
            this.breakMemberList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.memberListSortCompare);
            // 
            // endGameButton
            // 
            this.endGameButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.endGameButton.Location = new System.Drawing.Point(651, 300);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(87, 23);
            this.endGameButton.TabIndex = 10;
            this.endGameButton.Text = "試合終了";
            this.endGameButton.UseVisualStyleBackColor = true;
            this.endGameButton.Click += new System.EventHandler(this.endGame);
            // 
            // breakMemberLabel
            // 
            this.breakMemberLabel.AutoSize = true;
            this.breakMemberLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakMemberLabel.Location = new System.Drawing.Point(514, 39);
            this.breakMemberLabel.Name = "breakMemberLabel";
            this.breakMemberLabel.Size = new System.Drawing.Size(39, 19);
            this.breakMemberLabel.TabIndex = 11;
            this.breakMemberLabel.Text = "休憩";
            // 
            // courtNameLabel1
            // 
            this.courtNameLabel1.AutoSize = true;
            this.courtNameLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courtNameLabel1.Location = new System.Drawing.Point(107, 39);
            this.courtNameLabel1.Name = "courtNameLabel1";
            this.courtNameLabel1.Size = new System.Drawing.Size(123, 19);
            this.courtNameLabel1.TabIndex = 12;
            this.courtNameLabel1.Text = "courtNameLabel1";
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(12, 12);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(500, 300);
            this.resultPictureBox.TabIndex = 13;
            this.resultPictureBox.TabStop = false;
            // 
            // courtNameLabel2
            // 
            this.courtNameLabel2.AutoSize = true;
            this.courtNameLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courtNameLabel2.Location = new System.Drawing.Point(342, 39);
            this.courtNameLabel2.Name = "courtNameLabel2";
            this.courtNameLabel2.Size = new System.Drawing.Size(123, 19);
            this.courtNameLabel2.TabIndex = 14;
            this.courtNameLabel2.Text = "courtNameLabel2";
            // 
            // playerNameLabel1
            // 
            this.playerNameLabel1.AutoSize = true;
            this.playerNameLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel1.Location = new System.Drawing.Point(107, 130);
            this.playerNameLabel1.Name = "playerNameLabel1";
            this.playerNameLabel1.Size = new System.Drawing.Size(130, 19);
            this.playerNameLabel1.TabIndex = 15;
            this.playerNameLabel1.Text = "playerNameLabel1";
            this.playerNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerNameLabel2
            // 
            this.playerNameLabel2.AutoSize = true;
            this.playerNameLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel2.Location = new System.Drawing.Point(107, 222);
            this.playerNameLabel2.Name = "playerNameLabel2";
            this.playerNameLabel2.Size = new System.Drawing.Size(130, 19);
            this.playerNameLabel2.TabIndex = 16;
            this.playerNameLabel2.Text = "playerNameLabel2";
            this.playerNameLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerNameLabel3
            // 
            this.playerNameLabel3.AutoSize = true;
            this.playerNameLabel3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel3.Location = new System.Drawing.Point(335, 130);
            this.playerNameLabel3.Name = "playerNameLabel3";
            this.playerNameLabel3.Size = new System.Drawing.Size(130, 19);
            this.playerNameLabel3.TabIndex = 17;
            this.playerNameLabel3.Text = "playerNameLabel3";
            this.playerNameLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerNameLabel4
            // 
            this.playerNameLabel4.AutoSize = true;
            this.playerNameLabel4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel4.Location = new System.Drawing.Point(335, 222);
            this.playerNameLabel4.Name = "playerNameLabel4";
            this.playerNameLabel4.Size = new System.Drawing.Size(130, 19);
            this.playerNameLabel4.TabIndex = 18;
            this.playerNameLabel4.Text = "playerNameLabel4";
            this.playerNameLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // breakMemberListName
            // 
            this.breakMemberListName.HeaderText = "名前";
            this.breakMemberListName.Name = "breakMemberListName";
            this.breakMemberListName.ReadOnly = true;
            this.breakMemberListName.Width = 210;
            // 
            // breakMemberListGender
            // 
            this.breakMemberListGender.HeaderText = "性別";
            this.breakMemberListGender.Name = "breakMemberListGender";
            this.breakMemberListGender.Visible = false;
            // 
            // breakMemberListLevel
            // 
            this.breakMemberListLevel.HeaderText = "レベル";
            this.breakMemberListLevel.Name = "breakMemberListLevel";
            this.breakMemberListLevel.Visible = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 331);
            this.Controls.Add(this.playerNameLabel4);
            this.Controls.Add(this.playerNameLabel3);
            this.Controls.Add(this.playerNameLabel2);
            this.Controls.Add(this.playerNameLabel1);
            this.Controls.Add(this.courtNameLabel2);
            this.Controls.Add(this.courtNameLabel1);
            this.Controls.Add(this.breakMemberLabel);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.breakMemberList);
            this.Controls.Add(this.resultPictureBox);
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "組み合わせ結果画面";
            this.Load += new System.EventHandler(this.loadGameWindow);
            ((System.ComponentModel.ISupportInitialize)(this.breakMemberList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView breakMemberList;
        private System.Windows.Forms.Button endGameButton;
        private System.Windows.Forms.Label breakMemberLabel;
        private System.Windows.Forms.Label courtNameLabel1;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Label courtNameLabel2;
        private System.Windows.Forms.Label playerNameLabel1;
        private System.Windows.Forms.Label playerNameLabel2;
        private System.Windows.Forms.Label playerNameLabel3;
        private System.Windows.Forms.Label playerNameLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn breakMemberListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn breakMemberListGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn breakMemberListLevel;
    }
}