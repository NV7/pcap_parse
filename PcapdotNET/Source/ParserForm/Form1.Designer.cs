namespace ParserForm
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pickfilebutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filenametextbox = new System.Windows.Forms.TextBox();
            this.filenamelabel = new System.Windows.Forms.Label();
            this.startbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numbercolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protocolcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceipcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceportcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationipcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitbutton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pickfilebutton
            // 
            this.pickfilebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pickfilebutton.Location = new System.Drawing.Point(12, 12);
            this.pickfilebutton.Name = "pickfilebutton";
            this.pickfilebutton.Size = new System.Drawing.Size(610, 23);
            this.pickfilebutton.TabIndex = 0;
            this.pickfilebutton.Text = "Выберете .pcap файл для обработки";
            this.pickfilebutton.UseVisualStyleBackColor = true;
            this.pickfilebutton.Click += new System.EventHandler(this.pickfile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.filenametextbox);
            this.groupBox1.Controls.Add(this.filenamelabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбранный файл";
            // 
            // filenametextbox
            // 
            this.filenametextbox.Location = new System.Drawing.Point(72, 19);
            this.filenametextbox.MaximumSize = new System.Drawing.Size(440, 20);
            this.filenametextbox.Name = "filenametextbox";
            this.filenametextbox.Size = new System.Drawing.Size(440, 20);
            this.filenametextbox.TabIndex = 0;
            // 
            // filenamelabel
            // 
            this.filenamelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenamelabel.AutoSize = true;
            this.filenamelabel.Location = new System.Drawing.Point(6, 22);
            this.filenamelabel.Name = "filenamelabel";
            this.filenamelabel.Size = new System.Drawing.Size(64, 13);
            this.filenamelabel.TabIndex = 3;
            this.filenamelabel.Text = "Имя файла";
            // 
            // startbutton
            // 
            this.startbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startbutton.Location = new System.Drawing.Point(489, 265);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(133, 23);
            this.startbutton.TabIndex = 2;
            this.startbutton.Text = "Старт!";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numbercolumn,
            this.protocolcolumn,
            this.sourceipcolumn,
            this.sourceportcolumn,
            this.destinationipcolumn,
            this.destinationport,
            this.lengthcolumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.Size = new System.Drawing.Size(610, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // numbercolumn
            // 
            this.numbercolumn.HeaderText = "№";
            this.numbercolumn.Name = "numbercolumn";
            this.numbercolumn.ReadOnly = true;
            // 
            // protocolcolumn
            // 
            this.protocolcolumn.HeaderText = "Протокол";
            this.protocolcolumn.Name = "protocolcolumn";
            // 
            // sourceipcolumn
            // 
            this.sourceipcolumn.HeaderText = "IP Отправителя";
            this.sourceipcolumn.Name = "sourceipcolumn";
            // 
            // sourceportcolumn
            // 
            this.sourceportcolumn.HeaderText = "Порт";
            this.sourceportcolumn.Name = "sourceportcolumn";
            // 
            // destinationipcolumn
            // 
            this.destinationipcolumn.HeaderText = "IP Получателя";
            this.destinationipcolumn.Name = "destinationipcolumn";
            // 
            // destinationport
            // 
            this.destinationport.HeaderText = "Порт";
            this.destinationport.Name = "destinationport";
            // 
            // lengthcolumn
            // 
            this.lengthcolumn.HeaderText = "Длина";
            this.lengthcolumn.Name = "lengthcolumn";
            // 
            // exitbutton
            // 
            this.exitbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbutton.Location = new System.Drawing.Point(12, 265);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(133, 23);
            this.exitbutton.TabIndex = 4;
            this.exitbutton.Text = "Выход";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 300);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pickfilebutton);
            this.Name = "Form1";
            this.Text = "PCAP Parse";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pickfilebutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label filenamelabel;
        private System.Windows.Forms.TextBox filenametextbox;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbercolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn protocolcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceipcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceportcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationipcolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationport;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthcolumn;
    }
}

