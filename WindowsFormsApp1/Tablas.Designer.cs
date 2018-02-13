namespace WindowsFormsApp1
{
    partial class Tablas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new WindowsFormsApp1.DataSet1();
            this.sptjdbctabletypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spt_jdbc_table_typesTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.spt_jdbc_table_typesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptjdbctabletypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 344);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sptjdbctabletypesBindingSource
            // 
            this.sptjdbctabletypesBindingSource.DataMember = "spt_jdbc_table_types";
            this.sptjdbctabletypesBindingSource.DataSource = this.dataSet1;
            // 
            // spt_jdbc_table_typesTableAdapter
            // 
            this.spt_jdbc_table_typesTableAdapter.ClearBeforeFill = true;
            // 
            // Tablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 484);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tablas";
            this.Text = "Tablas";
            this.Load += new System.EventHandler(this.Tablas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptjdbctabletypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource sptjdbctabletypesBindingSource;
        private DataSet1TableAdapters.spt_jdbc_table_typesTableAdapter spt_jdbc_table_typesTableAdapter;
    }
}