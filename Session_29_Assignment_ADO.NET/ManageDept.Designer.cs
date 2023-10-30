namespace Session_29_Assignment_ADO.NET
{
    partial class ManageDept
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
            this.dgDept = new System.Windows.Forms.DataGridView();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empSearchDBDataSet = new Session_29_Assignment_ADO.NET.EmpSearchDBDataSet();
            this.departmentTableAdapter = new Session_29_Assignment_ADO.NET.EmpSearchDBDataSetTableAdapters.DepartmentTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.ChkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empSearchDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDept
            // 
            this.dgDept.AutoGenerateColumns = false;
            this.dgDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptName,
            this.IsActive});
            this.dgDept.DataSource = this.departmentBindingSource;
            this.dgDept.Location = new System.Drawing.Point(81, 65);
            this.dgDept.Name = "dgDept";
            this.dgDept.RowTemplate.Height = 23;
            this.dgDept.Size = new System.Drawing.Size(245, 150);
            this.dgDept.TabIndex = 0;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.empSearchDBDataSet;
            // 
            // empSearchDBDataSet
            // 
            this.empSearchDBDataSet.DataSetName = "EmpSearchDBDataSet";
            this.empSearchDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Department Details";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Location = new System.Drawing.Point(130, 269);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(59, 12);
            this.lblDeptName.TabIndex = 4;
            this.lblDeptName.Text = "Dept Name";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(132, 310);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(53, 12);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "IsActive";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(206, 269);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(100, 21);
            this.txtDeptName.TabIndex = 6;
            // 
            // ChkIsActive
            // 
            this.ChkIsActive.AutoSize = true;
            this.ChkIsActive.Location = new System.Drawing.Point(206, 310);
            this.ChkIsActive.Name = "ChkIsActive";
            this.ChkIsActive.Size = new System.Drawing.Size(15, 14);
            this.ChkIsActive.TabIndex = 7;
            this.ChkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(243, 360);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 245);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 164);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "DeptName";
            this.DeptName.Name = "DeptName";
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            // 
            // ManageDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ChkIsActive);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDept);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ManageDept";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ManageDept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empSearchDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDept;
        private EmpSearchDBDataSet empSearchDBDataSet;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private EmpSearchDBDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.CheckBox ChkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

