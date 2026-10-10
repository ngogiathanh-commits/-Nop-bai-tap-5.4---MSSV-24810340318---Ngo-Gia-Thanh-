namespace bt_10_10_4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            labelView = new Label();
            cboViewMode = new ComboBox();
            splitContainer1 = new SplitContainer();
            tvDepartments = new TreeView();
            lsvEmployees = new ListView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelView);
            panelTop.Controls.Add(cboViewMode);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(882, 50);
            panelTop.TabIndex = 0;
            // 
            // labelView
            // 
            labelView.AutoSize = true;
            labelView.Location = new Point(15, 15);
            labelView.Name = "labelView";
            labelView.Size = new Size(125, 20);
            labelView.TabIndex = 0;
            labelView.Text = "Chế độ hiển thị:";
            // 
            // cboViewMode
            // 
            cboViewMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboViewMode.FormattingEnabled = true;
            cboViewMode.Location = new Point(146, 12);
            cboViewMode.Name = "cboViewMode";
            cboViewMode.Size = new Size(180, 28);
            cboViewMode.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 50);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvDepartments);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lsvEmployees);
            splitContainer1.Size = new Size(882, 503);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 1;
            // 
            // tvDepartments
            // 
            tvDepartments.Dock = DockStyle.Fill;
            tvDepartments.Location = new Point(0, 0);
            tvDepartments.Name = "tvDepartments";
            tvDepartments.Size = new Size(280, 503);
            tvDepartments.TabIndex = 0;
            tvDepartments.AfterSelect += tvDepartments_AfterSelect;
            // 
            // lsvEmployees
            // 
            lsvEmployees.Dock = DockStyle.Fill;
            lsvEmployees.Location = new Point(0, 0);
            lsvEmployees.Name = "lsvEmployees";
            lsvEmployees.Size = new Size(598, 503);
            lsvEmployees.TabIndex = 0;
            lsvEmployees.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(splitContainer1);
            Controls.Add(panelTop);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Nhân Viên - TreeView & ListView";
            Load += Form1_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label labelView;
        private ComboBox cboViewMode;
        private SplitContainer splitContainer1;
        private TreeView tvDepartments;
        private ListView lsvEmployees;
    }
}