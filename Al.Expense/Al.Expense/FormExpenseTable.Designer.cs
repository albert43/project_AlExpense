namespace Al.Expense
{
    partial class FormExpenseTable
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
            this.dataGridViewExpense = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpense
            // 
            this.dataGridViewExpense.AllowUserToOrderColumns = true;
            this.dataGridViewExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Description,
            this.Amount,
            this.Category,
            this.Check});
            this.dataGridViewExpense.Location = new System.Drawing.Point(22, 84);
            this.dataGridViewExpense.Name = "dataGridViewExpense";
            this.dataGridViewExpense.RowTemplate.Height = 24;
            this.dataGridViewExpense.Size = new System.Drawing.Size(641, 233);
            this.dataGridViewExpense.TabIndex = 0;
            // 
            // Date
            // 
            this.Date.HeaderText = "ColumnDate";
            this.Date.MaxInputLength = 10;
            this.Date.Name = "Date";
            // 
            // Description
            // 
            this.Description.HeaderText = "ColumnDescription";
            this.Description.MaxInputLength = 100;
            this.Description.Name = "Description";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "ColumnAmount";
            this.Amount.Name = "Amount";
            // 
            // Category
            // 
            this.Category.HeaderText = "ColumnCategory";
            this.Category.Name = "Category";
            // 
            // Check
            // 
            this.Check.HeaderText = "ColumnCheck";
            this.Check.Name = "Check";
            // 
            // FormExpenseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 345);
            this.Controls.Add(this.dataGridViewExpense);
            this.Name = "FormExpenseTable";
            this.Text = "FormExpenseTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check;
    }
}