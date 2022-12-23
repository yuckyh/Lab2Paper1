using System.ComponentModel;

namespace Lab2Paper1;

partial class AddResource
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
        this.btnBack = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.btnAdd = new System.Windows.Forms.Button();
        this.tbName = new System.Windows.Forms.TextBox();
        this.tbQuantity = new System.Windows.Forms.TextBox();
        this.comboBoxType = new System.Windows.Forms.ComboBox();
        this.chkListBoxSkills = new System.Windows.Forms.CheckedListBox();
        this.SuspendLayout();
        // 
        // btnBack
        // 
        this.btnBack.Location = new System.Drawing.Point(11, 14);
        this.btnBack.Name = "btnBack";
        this.btnBack.Size = new System.Drawing.Size(75, 23);
        this.btnBack.TabIndex = 0;
        this.btnBack.Text = "Back";
        this.btnBack.UseVisualStyleBackColor = true;
        this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(337, 61);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(129, 23);
        this.label1.TabIndex = 1;
        this.label1.Text = "Add New Resource";
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(196, 137);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(100, 23);
        this.label2.TabIndex = 2;
        this.label2.Text = "Resource Name:";
        // 
        // label3
        // 
        this.label3.Location = new System.Drawing.Point(196, 178);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(100, 23);
        this.label3.TabIndex = 3;
        this.label3.Text = "Resource Type:";
        // 
        // label4
        // 
        this.label4.Location = new System.Drawing.Point(196, 217);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(111, 23);
        this.label4.TabIndex = 4;
        this.label4.Text = "Available Quantity:";
        // 
        // label5
        // 
        this.label5.Location = new System.Drawing.Point(196, 258);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(100, 23);
        this.label5.TabIndex = 5;
        this.label5.Text = "Allocated Skill(s):";
        // 
        // btnAdd
        // 
        this.btnAdd.Location = new System.Drawing.Point(362, 358);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(75, 23);
        this.btnAdd.TabIndex = 6;
        this.btnAdd.Text = "Add Resource";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // tbName
        // 
        this.tbName.Location = new System.Drawing.Point(345, 134);
        this.tbName.Name = "tbName";
        this.tbName.Size = new System.Drawing.Size(100, 20);
        this.tbName.TabIndex = 7;
        // 
        // tbQuantity
        // 
        this.tbQuantity.Location = new System.Drawing.Point(345, 220);
        this.tbQuantity.Name = "tbQuantity";
        this.tbQuantity.Size = new System.Drawing.Size(100, 20);
        this.tbQuantity.TabIndex = 8;
        // 
        // comboBoxType
        // 
        this.comboBoxType.FormattingEnabled = true;
        this.comboBoxType.Location = new System.Drawing.Point(345, 175);
        this.comboBoxType.Name = "comboBoxType";
        this.comboBoxType.Size = new System.Drawing.Size(121, 21);
        this.comboBoxType.TabIndex = 9;
        // 
        // chkListBoxSkills
        // 
        this.chkListBoxSkills.FormattingEnabled = true;
        this.chkListBoxSkills.Location = new System.Drawing.Point(342, 258);
        this.chkListBoxSkills.Name = "chkListBoxSkills";
        this.chkListBoxSkills.Size = new System.Drawing.Size(120, 94);
        this.chkListBoxSkills.TabIndex = 10;
        // 
        // AddResource
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.chkListBoxSkills);
        this.Controls.Add(this.comboBoxType);
        this.Controls.Add(this.tbQuantity);
        this.Controls.Add(this.tbName);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnBack);
        this.Name = "AddResource";
        this.Text = "Add Resource";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.CheckedListBox chkListBoxSkills;

    private System.Windows.Forms.ComboBox comboBoxType;

    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.TextBox tbQuantity;

    private System.Windows.Forms.Button btnAdd;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button btnBack;

    #endregion
}