namespace Forest
{
    partial class InputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonSenior = new System.Windows.Forms.RadioButton();
            this.radioButtonIntermediate = new System.Windows.Forms.RadioButton();
            this.radioButtonBeginner = new System.Windows.Forms.RadioButton();
            this.registerButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.panelGender = new System.Windows.Forms.Panel();
            this.panelLevel = new System.Windows.Forms.Panel();
            this.panelGender.SuspendLayout();
            this.panelLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "名前(20字以内)：";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameTextBox.Location = new System.Drawing.Point(184, 41);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(285, 23);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(32, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "性別：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(32, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "レベル：";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonMale.Location = new System.Drawing.Point(26, 12);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(42, 20);
            this.radioButtonMale.TabIndex = 2;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "男";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.Click += new System.EventHandler(this.radioButtonMale_Click);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonFemale.Location = new System.Drawing.Point(153, 12);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(42, 20);
            this.radioButtonFemale.TabIndex = 3;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "女";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            this.radioButtonFemale.CheckedChanged += new System.EventHandler(this.radioButtonFemale_CheckedChanged);
            // 
            // radioButtonSenior
            // 
            this.radioButtonSenior.AutoSize = true;
            this.radioButtonSenior.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonSenior.Location = new System.Drawing.Point(26, 12);
            this.radioButtonSenior.Name = "radioButtonSenior";
            this.radioButtonSenior.Size = new System.Drawing.Size(74, 20);
            this.radioButtonSenior.TabIndex = 5;
            this.radioButtonSenior.TabStop = true;
            this.radioButtonSenior.Text = "上級者";
            this.radioButtonSenior.UseVisualStyleBackColor = true;
            this.radioButtonSenior.CheckedChanged += new System.EventHandler(this.radioButtonSenior_CheckedChanged);
            // 
            // radioButtonIntermediate
            // 
            this.radioButtonIntermediate.AutoSize = true;
            this.radioButtonIntermediate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonIntermediate.Location = new System.Drawing.Point(106, 12);
            this.radioButtonIntermediate.Name = "radioButtonIntermediate";
            this.radioButtonIntermediate.Size = new System.Drawing.Size(74, 20);
            this.radioButtonIntermediate.TabIndex = 6;
            this.radioButtonIntermediate.TabStop = true;
            this.radioButtonIntermediate.Text = "中級者";
            this.radioButtonIntermediate.UseVisualStyleBackColor = true;
            this.radioButtonIntermediate.CheckedChanged += new System.EventHandler(this.radioButtonIntermediate_CheckedChanged);
            // 
            // radioButtonBeginner
            // 
            this.radioButtonBeginner.AutoSize = true;
            this.radioButtonBeginner.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonBeginner.Location = new System.Drawing.Point(186, 12);
            this.radioButtonBeginner.Name = "radioButtonBeginner";
            this.radioButtonBeginner.Size = new System.Drawing.Size(74, 20);
            this.radioButtonBeginner.TabIndex = 7;
            this.radioButtonBeginner.TabStop = true;
            this.radioButtonBeginner.Text = "初級者";
            this.radioButtonBeginner.UseVisualStyleBackColor = true;
            this.radioButtonBeginner.CheckedChanged += new System.EventHandler(this.radioButtonBeginner_CheckedChanged);
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.registerButton.Location = new System.Drawing.Point(330, 266);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "登録";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.register);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stopButton.Location = new System.Drawing.Point(417, 266);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "中止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // panelGender
            // 
            this.panelGender.Controls.Add(this.radioButtonMale);
            this.panelGender.Controls.Add(this.radioButtonFemale);
            this.panelGender.Location = new System.Drawing.Point(158, 113);
            this.panelGender.Name = "panelGender";
            this.panelGender.Size = new System.Drawing.Size(226, 44);
            this.panelGender.TabIndex = 1;
            // 
            // panelLevel
            // 
            this.panelLevel.Controls.Add(this.radioButtonSenior);
            this.panelLevel.Controls.Add(this.radioButtonIntermediate);
            this.panelLevel.Controls.Add(this.radioButtonBeginner);
            this.panelLevel.Location = new System.Drawing.Point(158, 198);
            this.panelLevel.Name = "panelLevel";
            this.panelLevel.Size = new System.Drawing.Size(299, 41);
            this.panelLevel.TabIndex = 4;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 311);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelGender);
            this.Controls.Add(this.panelLevel);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メンバー情報入力";
            this.Load += new System.EventHandler(this.loadInputForm);
            this.panelGender.ResumeLayout(false);
            this.panelGender.PerformLayout();
            this.panelLevel.ResumeLayout(false);
            this.panelLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonSenior;
        private System.Windows.Forms.RadioButton radioButtonIntermediate;
        private System.Windows.Forms.RadioButton radioButtonBeginner;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Panel panelGender;
        private System.Windows.Forms.Panel panelLevel;
    }
}