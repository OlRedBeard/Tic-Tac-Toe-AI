
namespace MyTicTacToeTournament
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.chkEasy = new System.Windows.Forms.CheckBox();
            this.chkModerate = new System.Windows.Forms.CheckBox();
            this.chkDifficult = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMatches = new System.Windows.Forms.NumericUpDown();
            this.btnTournament = new System.Windows.Forms.Button();
            this.lstMatchResults = new System.Windows.Forms.ListBox();
            this.lstWinRecords = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoX = new System.Windows.Forms.RadioButton();
            this.rdoO = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOpp = new System.Windows.Forms.ComboBox();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkEasy
            // 
            this.chkEasy.AutoSize = true;
            this.chkEasy.Location = new System.Drawing.Point(12, 41);
            this.chkEasy.Name = "chkEasy";
            this.chkEasy.Size = new System.Drawing.Size(84, 19);
            this.chkEasy.TabIndex = 1;
            this.chkEasy.Text = "Easy Player";
            this.chkEasy.UseVisualStyleBackColor = true;
            // 
            // chkModerate
            // 
            this.chkModerate.AutoSize = true;
            this.chkModerate.Location = new System.Drawing.Point(102, 41);
            this.chkModerate.Name = "chkModerate";
            this.chkModerate.Size = new System.Drawing.Size(112, 19);
            this.chkModerate.TabIndex = 2;
            this.chkModerate.Text = "Moderate Player";
            this.chkModerate.UseVisualStyleBackColor = true;
            // 
            // chkDifficult
            // 
            this.chkDifficult.AutoSize = true;
            this.chkDifficult.Location = new System.Drawing.Point(220, 41);
            this.chkDifficult.Name = "chkDifficult";
            this.chkDifficult.Size = new System.Drawing.Size(103, 19);
            this.chkDifficult.TabIndex = 3;
            this.chkDifficult.Text = "Difficult Player";
            this.chkDifficult.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Players to Include:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Games:";
            // 
            // numMatches
            // 
            this.numMatches.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMatches.Location = new System.Drawing.Point(156, 73);
            this.numMatches.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMatches.Name = "numMatches";
            this.numMatches.Size = new System.Drawing.Size(167, 23);
            this.numMatches.TabIndex = 6;
            this.numMatches.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTournament
            // 
            this.btnTournament.Location = new System.Drawing.Point(156, 102);
            this.btnTournament.Name = "btnTournament";
            this.btnTournament.Size = new System.Drawing.Size(167, 23);
            this.btnTournament.TabIndex = 7;
            this.btnTournament.Text = "Begin Tournament";
            this.btnTournament.UseVisualStyleBackColor = true;
            this.btnTournament.Click += new System.EventHandler(this.btnTournament_Click);
            // 
            // lstMatchResults
            // 
            this.lstMatchResults.FormattingEnabled = true;
            this.lstMatchResults.ItemHeight = 15;
            this.lstMatchResults.Location = new System.Drawing.Point(358, 9);
            this.lstMatchResults.Name = "lstMatchResults";
            this.lstMatchResults.Size = new System.Drawing.Size(430, 319);
            this.lstMatchResults.TabIndex = 8;
            this.lstMatchResults.SelectedIndexChanged += new System.EventHandler(this.lstMatchResults_SelectedIndexChanged);
            // 
            // lstWinRecords
            // 
            this.lstWinRecords.FormattingEnabled = true;
            this.lstWinRecords.ItemHeight = 15;
            this.lstWinRecords.Location = new System.Drawing.Point(12, 144);
            this.lstWinRecords.Name = "lstWinRecords";
            this.lstWinRecords.Size = new System.Drawing.Size(311, 184);
            this.lstWinRecords.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Play Tic-Tac-Toe:";
            // 
            // rdoX
            // 
            this.rdoX.AutoSize = true;
            this.rdoX.Location = new System.Drawing.Point(17, 375);
            this.rdoX.Name = "rdoX";
            this.rdoX.Size = new System.Drawing.Size(57, 19);
            this.rdoX.TabIndex = 11;
            this.rdoX.TabStop = true;
            this.rdoX.Text = "Play X";
            this.rdoX.UseVisualStyleBackColor = true;
            // 
            // rdoO
            // 
            this.rdoO.AutoSize = true;
            this.rdoO.Location = new System.Drawing.Point(17, 400);
            this.rdoO.Name = "rdoO";
            this.rdoO.Size = new System.Drawing.Size(59, 19);
            this.rdoO.TabIndex = 12;
            this.rdoO.TabStop = true;
            this.rdoO.Text = "Play O";
            this.rdoO.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Choose Opponent:";
            // 
            // cboOpp
            // 
            this.cboOpp.FormattingEnabled = true;
            this.cboOpp.Items.AddRange(new object[] {
            "Easy",
            "Moderate",
            "Difficult"});
            this.cboOpp.Location = new System.Drawing.Point(93, 400);
            this.cboOpp.Name = "cboOpp";
            this.cboOpp.Size = new System.Drawing.Size(121, 23);
            this.cboOpp.TabIndex = 14;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(248, 399);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 15;
            this.btnPlay.Text = "Play Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.cboOpp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdoO);
            this.Controls.Add(this.rdoX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstWinRecords);
            this.Controls.Add(this.lstMatchResults);
            this.Controls.Add(this.btnTournament);
            this.Controls.Add(this.numMatches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkDifficult);
            this.Controls.Add(this.chkModerate);
            this.Controls.Add(this.chkEasy);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkEasy;
        private System.Windows.Forms.CheckBox chkModerate;
        private System.Windows.Forms.CheckBox chkDifficult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMatches;
        private System.Windows.Forms.Button btnTournament;
        private System.Windows.Forms.ListBox lstMatchResults;
        private System.Windows.Forms.ListBox lstWinRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoX;
        private System.Windows.Forms.RadioButton rdoO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOpp;
        private System.Windows.Forms.Button btnPlay;
    }
}

