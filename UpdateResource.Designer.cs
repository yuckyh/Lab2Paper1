using System.ComponentModel;

namespace Lab2Paper1;

partial class UpdateResource
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
            this.chkListBoxSkills = new System.Windows.Forms.CheckedListBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkListBoxSkills
            // 
            this.chkListBoxSkills.FormattingEnabled = true;
            this.chkListBoxSkills.Location = new System.Drawing.Point(463, 392);
            this.chkListBoxSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkListBoxSkills.Name = "chkListBoxSkills";
            this.chkListBoxSkills.Size = new System.Drawing.Size(159, 136);
            this.chkListBoxSkills.TabIndex = 21;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(467, 265);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(160, 28);
            this.comboBoxType.TabIndex = 20;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(467, 334);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(132, 27);
            this.tbQuantity.TabIndex = 19;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(467, 202);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(132, 27);
            this.tbName.TabIndex = 18;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(467, 546);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 35);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update Resource";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(268, 392);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 35);
            this.label5.TabIndex = 16;
            this.label5.Text = "Allocated Skill(s):";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(268, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 35);
            this.label4.TabIndex = 15;
            this.label4.Text = "Available Quantity:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 269);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "Resource Type:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 35);
            this.label2.TabIndex = 13;
            this.label2.Text = "Resource Name:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(467, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Update Resource";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(21, 17);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // UpdateResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 692);
            this.Controls.Add(this.chkListBoxSkills);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UpdateResource";
            this.Text = "Update Resource";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private System.Windows.Forms.Button btnUpdate;

    private System.Windows.Forms.CheckedListBox chkListBoxSkills;
    private System.Windows.Forms.ComboBox comboBoxType;
    private System.Windows.Forms.TextBox tbQuantity;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnBack;

    #endregion
}