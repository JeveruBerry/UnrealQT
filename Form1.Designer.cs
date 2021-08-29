
namespace UnrealQT
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.BTN_Save_Configuration = new System.Windows.Forms.Button();
      this.TXT_VS_Path = new System.Windows.Forms.TextBox();
      this.BTN_VS_Path = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.TXT_UE_Engine_Path = new System.Windows.Forms.TextBox();
      this.BTN_Engine_Path = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.LBL_Project_Includes_Name = new System.Windows.Forms.Label();
      this.LBL_Project_Name = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.TXT_Project_Path = new System.Windows.Forms.TextBox();
      this.BTN_Project_Path = new System.Windows.Forms.Button();
      this.BTN_Generate = new System.Windows.Forms.Button();
      this.BTN_Quit = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.BTN_Save_Configuration);
      this.groupBox1.Controls.Add(this.TXT_VS_Path);
      this.groupBox1.Controls.Add(this.BTN_VS_Path);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.TXT_UE_Engine_Path);
      this.groupBox1.Controls.Add(this.BTN_Engine_Path);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(388, 106);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Configure";
      // 
      // BTN_Save_Configuration
      // 
      this.BTN_Save_Configuration.Location = new System.Drawing.Point(227, 75);
      this.BTN_Save_Configuration.Name = "BTN_Save_Configuration";
      this.BTN_Save_Configuration.Size = new System.Drawing.Size(155, 23);
      this.BTN_Save_Configuration.TabIndex = 6;
      this.BTN_Save_Configuration.Text = "Save Configuration";
      this.BTN_Save_Configuration.UseVisualStyleBackColor = true;
      this.BTN_Save_Configuration.Click += new System.EventHandler(this.BTN_Save_Configuration_Click);
      // 
      // TXT_VS_Path
      // 
      this.TXT_VS_Path.Location = new System.Drawing.Point(114, 48);
      this.TXT_VS_Path.Name = "TXT_VS_Path";
      this.TXT_VS_Path.ReadOnly = true;
      this.TXT_VS_Path.Size = new System.Drawing.Size(235, 20);
      this.TXT_VS_Path.TabIndex = 5;
      // 
      // BTN_VS_Path
      // 
      this.BTN_VS_Path.Location = new System.Drawing.Point(355, 46);
      this.BTN_VS_Path.Name = "BTN_VS_Path";
      this.BTN_VS_Path.Size = new System.Drawing.Size(27, 23);
      this.BTN_VS_Path.TabIndex = 4;
      this.BTN_VS_Path.Text = "...";
      this.BTN_VS_Path.UseVisualStyleBackColor = true;
      this.BTN_VS_Path.Click += new System.EventHandler(this.BTN_VS_Path_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(96, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Visual Studio Path:";
      // 
      // TXT_UE_Engine_Path
      // 
      this.TXT_UE_Engine_Path.Location = new System.Drawing.Point(114, 22);
      this.TXT_UE_Engine_Path.Name = "TXT_UE_Engine_Path";
      this.TXT_UE_Engine_Path.ReadOnly = true;
      this.TXT_UE_Engine_Path.Size = new System.Drawing.Size(235, 20);
      this.TXT_UE_Engine_Path.TabIndex = 2;
      // 
      // BTN_Engine_Path
      // 
      this.BTN_Engine_Path.Location = new System.Drawing.Point(355, 20);
      this.BTN_Engine_Path.Name = "BTN_Engine_Path";
      this.BTN_Engine_Path.Size = new System.Drawing.Size(27, 23);
      this.BTN_Engine_Path.TabIndex = 1;
      this.BTN_Engine_Path.Text = "...";
      this.BTN_Engine_Path.UseVisualStyleBackColor = true;
      this.BTN_Engine_Path.Click += new System.EventHandler(this.BTN_Engine_Path_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Unreal Engine Path:";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.LBL_Project_Includes_Name);
      this.groupBox2.Controls.Add(this.LBL_Project_Name);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.TXT_Project_Path);
      this.groupBox2.Controls.Add(this.BTN_Project_Path);
      this.groupBox2.Location = new System.Drawing.Point(12, 124);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(388, 100);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Project";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 76);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(81, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Includes Name:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 57);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(74, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Project Name:";
      // 
      // LBL_Project_Includes_Name
      // 
      this.LBL_Project_Includes_Name.AutoSize = true;
      this.LBL_Project_Includes_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LBL_Project_Includes_Name.Location = new System.Drawing.Point(111, 76);
      this.LBL_Project_Includes_Name.Name = "LBL_Project_Includes_Name";
      this.LBL_Project_Includes_Name.Size = new System.Drawing.Size(165, 13);
      this.LBL_Project_Includes_Name.TabIndex = 10;
      this.LBL_Project_Includes_Name.Text = "<PROJECT_INCLUDES_NAME>";
      // 
      // LBL_Project_Name
      // 
      this.LBL_Project_Name.AutoSize = true;
      this.LBL_Project_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LBL_Project_Name.Location = new System.Drawing.Point(111, 57);
      this.LBL_Project_Name.Name = "LBL_Project_Name";
      this.LBL_Project_Name.Size = new System.Drawing.Size(105, 13);
      this.LBL_Project_Name.TabIndex = 9;
      this.LBL_Project_Name.Text = "<PROJECT_NAME>";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 22);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Project Path:";
      // 
      // TXT_Project_Path
      // 
      this.TXT_Project_Path.Location = new System.Drawing.Point(114, 19);
      this.TXT_Project_Path.Name = "TXT_Project_Path";
      this.TXT_Project_Path.ReadOnly = true;
      this.TXT_Project_Path.Size = new System.Drawing.Size(235, 20);
      this.TXT_Project_Path.TabIndex = 7;
      this.TXT_Project_Path.TextChanged += new System.EventHandler(this.TXT_Project_Path_TextChanged);
      // 
      // BTN_Project_Path
      // 
      this.BTN_Project_Path.Location = new System.Drawing.Point(355, 17);
      this.BTN_Project_Path.Name = "BTN_Project_Path";
      this.BTN_Project_Path.Size = new System.Drawing.Size(27, 23);
      this.BTN_Project_Path.TabIndex = 6;
      this.BTN_Project_Path.Text = "...";
      this.BTN_Project_Path.UseVisualStyleBackColor = true;
      this.BTN_Project_Path.Click += new System.EventHandler(this.BTN_Project_Path_Click);
      // 
      // BTN_Generate
      // 
      this.BTN_Generate.Location = new System.Drawing.Point(239, 230);
      this.BTN_Generate.Name = "BTN_Generate";
      this.BTN_Generate.Size = new System.Drawing.Size(161, 23);
      this.BTN_Generate.TabIndex = 2;
      this.BTN_Generate.Text = "Generate Qt Project Files";
      this.BTN_Generate.UseVisualStyleBackColor = true;
      this.BTN_Generate.Click += new System.EventHandler(this.BTN_Generate_Click);
      // 
      // BTN_Quit
      // 
      this.BTN_Quit.Location = new System.Drawing.Point(12, 230);
      this.BTN_Quit.Name = "BTN_Quit";
      this.BTN_Quit.Size = new System.Drawing.Size(75, 23);
      this.BTN_Quit.TabIndex = 3;
      this.BTN_Quit.Text = "Quit";
      this.BTN_Quit.UseVisualStyleBackColor = true;
      this.BTN_Quit.Click += new System.EventHandler(this.BTN_Quit_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(413, 263);
      this.Controls.Add(this.BTN_Quit);
      this.Controls.Add(this.BTN_Generate);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "UnrealQT";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox TXT_UE_Engine_Path;
    private System.Windows.Forms.Button BTN_Engine_Path;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TXT_VS_Path;
    private System.Windows.Forms.Button BTN_VS_Path;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox TXT_Project_Path;
    private System.Windows.Forms.Button BTN_Project_Path;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label LBL_Project_Includes_Name;
    private System.Windows.Forms.Label LBL_Project_Name;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button BTN_Generate;
    private System.Windows.Forms.Button BTN_Quit;
    private System.Windows.Forms.Button BTN_Save_Configuration;
  }
}

