namespace ProLab2_1.Forms
{
    partial class MapForm
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
            this.components = new System.ComponentModel.Container();
            this.GameMap = new System.Windows.Forms.PictureBox();
            this.GameEvent = new System.Windows.Forms.Timer(this.components);
            this.MoveObjectTimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_counMovements = new System.Windows.Forms.Label();
            this.lbl_chestCounts = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_generateMap = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).BeginInit();
            this.SuspendLayout();
            // 
            // GameMap
            // 
            this.GameMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GameMap.Location = new System.Drawing.Point(9, 10);
            this.GameMap.Margin = new System.Windows.Forms.Padding(2);
            this.GameMap.Name = "GameMap";
            this.GameMap.Size = new System.Drawing.Size(751, 751);
            this.GameMap.TabIndex = 0;
            this.GameMap.TabStop = false;
            this.GameMap.Paint += new System.Windows.Forms.PaintEventHandler(this.GameMap_Paint);
            // 
            // GameEvent
            // 
            this.GameEvent.Interval = 50;
            this.GameEvent.Tick += new System.EventHandler(this.GameTimerTick);
            // 
            // MoveObjectTimer
            // 
            this.MoveObjectTimer.Interval = 50;
            this.MoveObjectTimer.Tick += new System.EventHandler(this.MoveObjectEvent);
            // 
            // lbl_counMovements
            // 
            this.lbl_counMovements.AutoSize = true;
            this.lbl_counMovements.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_counMovements.Location = new System.Drawing.Point(765, 10);
            this.lbl_counMovements.Name = "lbl_counMovements";
            this.lbl_counMovements.Size = new System.Drawing.Size(163, 29);
            this.lbl_counMovements.TabIndex = 1;
            this.lbl_counMovements.Text = "Adım Sayısı :";
            // 
            // lbl_chestCounts
            // 
            this.lbl_chestCounts.AutoSize = true;
            this.lbl_chestCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_chestCounts.Location = new System.Drawing.Point(765, 57);
            this.lbl_chestCounts.Name = "lbl_chestCounts";
            this.lbl_chestCounts.Size = new System.Drawing.Size(249, 29);
            this.lbl_chestCounts.TabIndex = 2;
            this.lbl_chestCounts.Text = "Kalan sandık sayısı :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(770, 110);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(378, 210);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btn_generateMap
            // 
            this.btn_generateMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generateMap.Location = new System.Drawing.Point(852, 326);
            this.btn_generateMap.Name = "btn_generateMap";
            this.btn_generateMap.Size = new System.Drawing.Size(209, 58);
            this.btn_generateMap.TabIndex = 4;
            this.btn_generateMap.Text = "Harita Oluştur";
            this.btn_generateMap.UseVisualStyleBackColor = true;
            this.btn_generateMap.Click += new System.EventHandler(this.GenerateMapButtonClicked);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F);
            this.btn_start.Location = new System.Drawing.Point(852, 390);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(209, 58);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Başlat";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 749);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_generateMap);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbl_chestCounts);
            this.Controls.Add(this.lbl_counMovements);
            this.Controls.Add(this.GameMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameMap;
        private System.Windows.Forms.Timer GameEvent;
        private System.Windows.Forms.Timer MoveObjectTimer;
        private System.Windows.Forms.Label lbl_counMovements;
        private System.Windows.Forms.Label lbl_chestCounts;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_generateMap;
        private System.Windows.Forms.Button btn_start;
    }
}