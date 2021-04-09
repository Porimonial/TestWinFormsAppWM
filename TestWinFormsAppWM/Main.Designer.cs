
namespace TestWinFormsAppWM
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.dgwPersons = new System.Windows.Forms.DataGridView();
            this.btnClearData = new System.Windows.Forms.Button();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.tbMidname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAgeTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.tbAgeFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ofdOpenXML = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwPersons
            // 
            this.dgwPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPersons.Location = new System.Drawing.Point(12, 12);
            this.dgwPersons.Name = "dgwPersons";
            this.dgwPersons.RowHeadersWidth = 51;
            this.dgwPersons.RowTemplate.Height = 24;
            this.dgwPersons.Size = new System.Drawing.Size(677, 378);
            this.dgwPersons.TabIndex = 0;
            this.dgwPersons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPersons_CellContentClick);
            this.dgwPersons.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgwPersons_CellPainting_1);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(480, 396);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(209, 41);
            this.btnClearData.TabIndex = 1;
            this.btnClearData.Text = "Очистить таблицу";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // bsData
            // 
            this.bsData.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(14, 171);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(170, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(33, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(84, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(84, 62);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 22);
            this.tbSurname.TabIndex = 6;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(13, 62);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(65, 17);
            this.lblSurname.TabIndex = 5;
            this.lblSurname.Text = "Surname";
            // 
            // tbMidname
            // 
            this.tbMidname.Location = new System.Drawing.Point(84, 90);
            this.tbMidname.Name = "tbMidname";
            this.tbMidname.Size = new System.Drawing.Size(100, 22);
            this.tbMidname.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "MidName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Age";
            // 
            // tbAgeTo
            // 
            this.tbAgeTo.Location = new System.Drawing.Point(123, 143);
            this.tbAgeTo.Name = "tbAgeTo";
            this.tbAgeTo.Size = new System.Drawing.Size(61, 22);
            this.tbAgeTo.TabIndex = 11;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(97, 143);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 17);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "to";
            // 
            // tbAgeFrom
            // 
            this.tbAgeFrom.Location = new System.Drawing.Point(123, 118);
            this.tbAgeFrom.Name = "tbAgeFrom";
            this.tbAgeFrom.Size = new System.Drawing.Size(61, 22);
            this.tbAgeFrom.TabIndex = 13;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(81, 118);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 17);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "from";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.tbAgeFrom);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbAgeTo);
            this.groupBox1.Controls.Add(this.lblSurname);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.tbSurname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbMidname);
            this.groupBox1.Location = new System.Drawing.Point(718, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 205);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация данных";
            // 
            // ofdOpenXML
            // 
            this.ofdOpenXML.Filter = "XML files|*.xml";
            this.ofdOpenXML.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 396);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(176, 41);
            this.btnLoadData.TabIndex = 16;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 458);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.dgwPersons);
            this.Name = "frmMain";
            this.Text = "Persons";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPersons;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox tbMidname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAgeTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox tbAgeFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog ofdOpenXML;
        private System.Windows.Forms.Button btnLoadData;
    }
}

