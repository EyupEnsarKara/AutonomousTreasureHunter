﻿namespace ProLab2_1.Forms
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
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).BeginInit();
            this.SuspendLayout();
            // 
            // GameMap
            // 
            this.GameMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GameMap.Location = new System.Drawing.Point(12, 12);
            this.GameMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameMap.Name = "GameMap";
            this.GameMap.Size = new System.Drawing.Size(687, 382);
            this.GameMap.TabIndex = 0;
            this.GameMap.TabStop = false;
            this.GameMap.Paint += new System.Windows.Forms.PaintEventHandler(this.GameMap_Paint);
            // 
            // GameEvent
            // 
            this.GameEvent.Interval = 10;
            this.GameEvent.Tick += new System.EventHandler(this.GameTimerTick);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 405);
            this.Controls.Add(this.GameMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameMap;
        private System.Windows.Forms.Timer GameEvent;
    }
}