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
            this.label01 = new System.Windows.Forms.Label();
            this.label02 = new System.Windows.Forms.Label();
            this.label03 = new System.Windows.Forms.Label();
            this.list01 = new System.Windows.Forms.DataGridView();
            this.List01Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.List01Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List01Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List01Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List01Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.list02 = new System.Windows.Forms.DataGridView();
            this.List02Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.List02Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List02Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List02Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List02Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button01 = new System.Windows.Forms.Button();
            this.button02 = new System.Windows.Forms.Button();
            this.button03 = new System.Windows.Forms.Button();
            this.button04 = new System.Windows.Forms.Button();
            this.button05 = new System.Windows.Forms.Button();
            this.button06 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.list01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.list02)).BeginInit();
            this.SuspendLayout();
            // 
            // label01
            // 
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label01.Location = new System.Drawing.Point(12, 28);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(80, 26);
            this.label01.TabIndex = 0;
            this.label01.Text = "メンバー";
            this.label01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label02
            // 
            this.label02.AutoSize = true;
            this.label02.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label02.Location = new System.Drawing.Point(501, 28);
            this.label02.Name = "label02";
            this.label02.Size = new System.Drawing.Size(124, 26);
            this.label02.TabIndex = 1;
            this.label02.Text = "参加メンバー";
            this.label02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label03
            // 
            this.label03.AutoSize = true;
            this.label03.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label03.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label03.Location = new System.Drawing.Point(201, 63);
            this.label03.Name = "label03";
            this.label03.Size = new System.Drawing.Size(164, 19);
            this.label03.TabIndex = 2;
            this.label03.Text = "登録人数を表示するところ";
            this.label03.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list01
            // 
            this.list01.AllowUserToAddRows = false;
            this.list01.AllowUserToDeleteRows = false;
            this.list01.AllowUserToResizeColumns = false;
            this.list01.AllowUserToResizeRows = false;
            this.list01.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.list01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.List01Check,
            this.List01Id,
            this.List01Name,
            this.List01Gender,
            this.List01Level});
            this.list01.Location = new System.Drawing.Point(12, 85);
            this.list01.Name = "list01";
            this.list01.RowHeadersVisible = false;
            this.list01.RowTemplate.Height = 21;
            this.list01.Size = new System.Drawing.Size(353, 350);
            this.list01.TabIndex = 3;
            this.list01.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ManageBelongedPersonList);
            this.list01.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.list01_SortCompare);
            // 
            // List01Check
            // 
            this.List01Check.HeaderText = "選択";
            this.List01Check.Name = "List01Check";
            this.List01Check.Width = 50;
            // 
            // List01Id
            // 
            this.List01Id.HeaderText = "ID";
            this.List01Id.Name = "List01Id";
            this.List01Id.Visible = false;
            // 
            // List01Name
            // 
            this.List01Name.HeaderText = "名前";
            this.List01Name.Name = "List01Name";
            this.List01Name.ReadOnly = true;
            // 
            // List01Gender
            // 
            this.List01Gender.HeaderText = "性別";
            this.List01Gender.Name = "List01Gender";
            this.List01Gender.ReadOnly = true;
            // 
            // List01Level
            // 
            this.List01Level.HeaderText = "レベル";
            this.List01Level.Name = "List01Level";
            this.List01Level.ReadOnly = true;
            // 
            // list02
            // 
            this.list02.AllowUserToAddRows = false;
            this.list02.AllowUserToDeleteRows = false;
            this.list02.AllowUserToResizeColumns = false;
            this.list02.AllowUserToResizeRows = false;
            this.list02.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.list02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list02.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.List02Check,
            this.List02Id,
            this.List02Name,
            this.List02Gender,
            this.List02Level});
            this.list02.Location = new System.Drawing.Point(501, 85);
            this.list02.Name = "list02";
            this.list02.RowHeadersVisible = false;
            this.list02.RowTemplate.Height = 21;
            this.list02.Size = new System.Drawing.Size(353, 350);
            this.list02.TabIndex = 4;
            this.list02.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ManageAttendedPersonList);
            // 
            // List02Check
            // 
            this.List02Check.HeaderText = "選択";
            this.List02Check.Name = "List02Check";
            this.List02Check.Width = 50;
            // 
            // List02Id
            // 
            this.List02Id.HeaderText = "ID";
            this.List02Id.Name = "List02Id";
            this.List02Id.Visible = false;
            // 
            // List02Name
            // 
            this.List02Name.HeaderText = "名前";
            this.List02Name.Name = "List02Name";
            this.List02Name.ReadOnly = true;
            // 
            // List02Gender
            // 
            this.List02Gender.HeaderText = "性別";
            this.List02Gender.Name = "List02Gender";
            this.List02Gender.ReadOnly = true;
            // 
            // List02Level
            // 
            this.List02Level.HeaderText = "レベル";
            this.List02Level.Name = "List02Level";
            this.List02Level.ReadOnly = true;
            // 
            // button01
            // 
            this.button01.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button01.Location = new System.Drawing.Point(388, 190);
            this.button01.Name = "button01";
            this.button01.Size = new System.Drawing.Size(90, 25);
            this.button01.TabIndex = 5;
            this.button01.Text = "→";
            this.button01.UseVisualStyleBackColor = true;
            this.button01.Click += new System.EventHandler(this.AddAttendedPersons);
            // 
            // button02
            // 
            this.button02.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button02.Location = new System.Drawing.Point(388, 298);
            this.button02.Name = "button02";
            this.button02.Size = new System.Drawing.Size(90, 25);
            this.button02.TabIndex = 6;
            this.button02.Text = "←";
            this.button02.UseVisualStyleBackColor = true;
            this.button02.Click += new System.EventHandler(this.DeleteAttendedPersons);
            // 
            // button03
            // 
            this.button03.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button03.Location = new System.Drawing.Point(12, 501);
            this.button03.Name = "button03";
            this.button03.Size = new System.Drawing.Size(90, 25);
            this.button03.TabIndex = 7;
            this.button03.Text = "追加";
            this.button03.UseVisualStyleBackColor = true;
            // 
            // button04
            // 
            this.button04.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button04.Location = new System.Drawing.Point(151, 501);
            this.button04.Name = "button04";
            this.button04.Size = new System.Drawing.Size(90, 25);
            this.button04.TabIndex = 8;
            this.button04.Text = "削除";
            this.button04.UseVisualStyleBackColor = true;
            // 
            // button05
            // 
            this.button05.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button05.Location = new System.Drawing.Point(290, 501);
            this.button05.Name = "button05";
            this.button05.Size = new System.Drawing.Size(90, 25);
            this.button05.TabIndex = 9;
            this.button05.Text = "変更";
            this.button05.UseVisualStyleBackColor = true;
            // 
            // button06
            // 
            this.button06.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button06.Location = new System.Drawing.Point(764, 501);
            this.button06.Name = "button06";
            this.button06.Size = new System.Drawing.Size(90, 25);
            this.button06.TabIndex = 10;
            this.button06.Text = "試合開始";
            this.button06.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.button06);
            this.Controls.Add(this.button05);
            this.Controls.Add(this.button04);
            this.Controls.Add(this.button03);
            this.Controls.Add(this.button02);
            this.Controls.Add(this.button01);
            this.Controls.Add(this.list02);
            this.Controls.Add(this.list01);
            this.Controls.Add(this.label03);
            this.Controls.Add(this.label02);
            this.Controls.Add(this.label01);
            this.Name = "MainWindow";
            this.Text = "コート分けアプリ　参加メンバー登録";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.list01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.list02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label label02;
        private System.Windows.Forms.Label label03;
        private System.Windows.Forms.DataGridView list01;
        private System.Windows.Forms.DataGridView list02;
        private System.Windows.Forms.Button button01;
        private System.Windows.Forms.Button button02;
        private System.Windows.Forms.Button button03;
        private System.Windows.Forms.Button button04;
        private System.Windows.Forms.Button button05;
        private System.Windows.Forms.Button button06;
        private System.Windows.Forms.DataGridViewCheckBoxColumn List01Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn List01Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn List01Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn List01Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn List01Level;
        private System.Windows.Forms.DataGridViewCheckBoxColumn List02Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn List02Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn List02Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn List02Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn List02Level;
    }
}

