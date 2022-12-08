namespace OOO_Povarenok
{
    partial class FormTemplate
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTemplate));
            this.TableLayPanTempUp = new System.Windows.Forms.TableLayoutPanel();
            this.ButTempExit = new System.Windows.Forms.Button();
            this.PicBoxTempLogo = new System.Windows.Forms.PictureBox();
            this.LabelTemp = new System.Windows.Forms.Label();
            this.TableLayPanTempDown = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayPanTempUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTempLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayPanTempUp
            // 
            this.TableLayPanTempUp.ColumnCount = 3;
            this.TableLayPanTempUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.38423F));
            this.TableLayPanTempUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.58448F));
            this.TableLayPanTempUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.15645F));
            this.TableLayPanTempUp.Controls.Add(this.ButTempExit, 2, 0);
            this.TableLayPanTempUp.Controls.Add(this.PicBoxTempLogo, 0, 0);
            this.TableLayPanTempUp.Controls.Add(this.LabelTemp, 1, 0);
            this.TableLayPanTempUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayPanTempUp.Location = new System.Drawing.Point(0, 0);
            this.TableLayPanTempUp.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayPanTempUp.Name = "TableLayPanTempUp";
            this.TableLayPanTempUp.RowCount = 1;
            this.TableLayPanTempUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanTempUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanTempUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanTempUp.Size = new System.Drawing.Size(1067, 65);
            this.TableLayPanTempUp.TabIndex = 0;
            // 
            // ButTempExit
            // 
            this.ButTempExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButTempExit.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButTempExit.Location = new System.Drawing.Point(802, 4);
            this.ButTempExit.Margin = new System.Windows.Forms.Padding(4);
            this.ButTempExit.Name = "ButTempExit";
            this.ButTempExit.Size = new System.Drawing.Size(261, 57);
            this.ButTempExit.TabIndex = 2;
            this.ButTempExit.Text = "Выход";
            this.ButTempExit.UseVisualStyleBackColor = true;
            // 
            // PicBoxTempLogo
            // 
            this.PicBoxTempLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxTempLogo.Image = global::OOO_Povarenok.Properties.Resources.logo;
            this.PicBoxTempLogo.Location = new System.Drawing.Point(4, 4);
            this.PicBoxTempLogo.Margin = new System.Windows.Forms.Padding(4);
            this.PicBoxTempLogo.Name = "PicBoxTempLogo";
            this.PicBoxTempLogo.Size = new System.Drawing.Size(70, 57);
            this.PicBoxTempLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxTempLogo.TabIndex = 2;
            this.PicBoxTempLogo.TabStop = false;
            // 
            // LabelTemp
            // 
            this.LabelTemp.AutoSize = true;
            this.LabelTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTemp.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTemp.Location = new System.Drawing.Point(82, 0);
            this.LabelTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTemp.Name = "LabelTemp";
            this.LabelTemp.Size = new System.Drawing.Size(712, 65);
            this.LabelTemp.TabIndex = 3;
            this.LabelTemp.Text = "Название Формы";
            this.LabelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableLayPanTempDown
            // 
            this.TableLayPanTempDown.ColumnCount = 1;
            this.TableLayPanTempDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanTempDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayPanTempDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableLayPanTempDown.Location = new System.Drawing.Point(0, 489);
            this.TableLayPanTempDown.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayPanTempDown.Name = "TableLayPanTempDown";
            this.TableLayPanTempDown.RowCount = 1;
            this.TableLayPanTempDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayPanTempDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.TableLayPanTempDown.Size = new System.Drawing.Size(1067, 65);
            this.TableLayPanTempDown.TabIndex = 1;
            // 
            // FormTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.TableLayPanTempDown);
            this.Controls.Add(this.TableLayPanTempUp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTemplate";
            this.Text = "Шаблон";
            this.TableLayPanTempUp.ResumeLayout(false);
            this.TableLayPanTempUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTempLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayPanTempUp;
        private System.Windows.Forms.PictureBox PicBoxTempLogo;
        private System.Windows.Forms.Label LabelTemp;
        private System.Windows.Forms.TableLayoutPanel TableLayPanTempDown;
        private System.Windows.Forms.Button ButTempExit;
    }
}

