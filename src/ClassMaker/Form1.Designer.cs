namespace ClassMakerCSharp
{ 
partial class Form1 : System.Windows.Forms.Form
{

    //Form remplace la méthode Dispose pour nettoyer la liste des composants.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    //Requise par le Concepteur Windows Form

    private System.ComponentModel.IContainer components;
    //REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    //Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    //Ne la modifiez pas à l'aide de l'éditeur de code.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox4 = new System.Windows.Forms.CheckBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.TextBox6 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.CheckBox5 = new System.Windows.Forms.CheckBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.CheckBox8 = new System.Windows.Forms.CheckBox();
            this.CheckBox9 = new System.Windows.Forms.CheckBox();
            this.CheckBox10 = new System.Windows.Forms.CheckBox();
            this.CheckBox11 = new System.Windows.Forms.CheckBox();
            this.CheckBox12 = new System.Windows.Forms.CheckBox();
            this.CheckBox13 = new System.Windows.Forms.CheckBox();
            this.CheckBox14 = new System.Windows.Forms.CheckBox();
            this.CheckBox15 = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBox1.Location = new System.Drawing.Point(6, 133);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(290, 68);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "Action#single\r\nComplainNeedIdi#single\r\nComplainNeedIdu#single\r\nComplaining#single" +
    "\r\nPriority#single\r\nSize#single\r\nTargeti#single\r\nTargetu#single\r\nTimer#single";
            // 
            // TextBox2
            // 
            this.TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox2.Location = new System.Drawing.Point(308, 19);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox2.Size = new System.Drawing.Size(513, 544);
            this.TextBox2.TabIndex = 1;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Location = new System.Drawing.Point(308, 569);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(95, 27);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Write Class";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBox3
            // 
            this.TextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBox3.Location = new System.Drawing.Point(6, 238);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(290, 105);
            this.TextBox3.TabIndex = 3;
            this.TextBox3.Text = "Targetu#single;Timer#single";
           
            // 
            // TextBox4
            // 
            this.TextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBox4.Location = new System.Drawing.Point(6, 379);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(290, 20);
            this.TextBox4.TabIndex = 4;
            this.TextBox4.Text = "Entity";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(34, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Fields";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 222);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(85, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Fields for creator";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 363);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(59, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Inherit from";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(302, 3);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(80, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Your new Class";
            // 
            // TextBox5
            // 
            this.TextBox5.Location = new System.Drawing.Point(6, 76);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(290, 20);
            this.TextBox5.TabIndex = 9;
            this.TextBox5.Text = "Prisoner";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 60);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(63, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Class Name";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(3, 117);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(34, 13);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Fields";
            // 
            // CheckBox1
            // 
            this.CheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox1.Location = new System.Drawing.Point(236, 405);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(60, 17);
            this.CheckBox1.TabIndex = 12;
            this.CheckBox1.Text = "Inherits";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox2.Location = new System.Drawing.Point(204, 349);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(92, 17);
            this.CheckBox2.TabIndex = 13;
            this.CheckBox2.Text = "Add creator(s)";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            this.CheckBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox3.Location = new System.Drawing.Point(199, 207);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(97, 17);
            this.CheckBox3.TabIndex = 14;
            this.CheckBox3.Text = "Generate fields";
            this.CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox4.Location = new System.Drawing.Point(176, 102);
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Size = new System.Drawing.Size(120, 17);
            this.CheckBox4.TabIndex = 15;
            this.CheckBox4.Text = "Use this class name";
            this.CheckBox4.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(3, 3);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 13);
            this.Label7.TabIndex = 18;
            this.Label7.Text = "Namespace";
            // 
            // TextBox6
            // 
            this.TextBox6.Location = new System.Drawing.Point(6, 19);
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new System.Drawing.Size(290, 20);
            this.TextBox6.TabIndex = 17;
            this.TextBox6.Text = "PrisonArchitectManager";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(3, 3);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(34, 13);
            this.Label8.TabIndex = 16;
            this.Label8.Text = "Fields";
            // 
            // CheckBox5
            // 
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox5.Location = new System.Drawing.Point(172, 45);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new System.Drawing.Size(124, 17);
            this.CheckBox5.TabIndex = 19;
            this.CheckBox5.Text = "Use this Namespace";
            this.CheckBox5.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button2.Location = new System.Drawing.Point(726, 569);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(95, 27);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Save Class";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button3.Location = new System.Drawing.Point(409, 569);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(95, 27);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "Select All";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button4.Location = new System.Drawing.Point(510, 569);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(102, 27);
            this.Button4.TabIndex = 20;
            this.Button4.Text = "Copy to Clipboard";
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            this.Button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button5.Location = new System.Drawing.Point(618, 569);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(102, 27);
            this.Button5.TabIndex = 21;
            this.Button5.Text = "Open Class in V.S";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox6.Location = new System.Drawing.Point(59, 19);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(70, 17);
            this.CheckBox6.TabIndex = 22;
            this.CheckBox6.Text = "Singleton";
            this.CheckBox6.UseVisualStyleBackColor = true;
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox7.Location = new System.Drawing.Point(29, 42);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(100, 17);
            this.CheckBox7.TabIndex = 23;
            this.CheckBox7.Text = "Factory Method";
            this.CheckBox7.UseVisualStyleBackColor = true;
            // 
            // CheckBox8
            // 
            this.CheckBox8.AutoSize = true;
            this.CheckBox8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox8.Location = new System.Drawing.Point(26, 65);
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Size = new System.Drawing.Size(103, 17);
            this.CheckBox8.TabIndex = 24;
            this.CheckBox8.Text = "Abstract Factory";
            this.CheckBox8.UseVisualStyleBackColor = true;
            // 
            // CheckBox9
            // 
            this.CheckBox9.AutoSize = true;
            this.CheckBox9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox9.Location = new System.Drawing.Point(94, 88);
            this.CheckBox9.Name = "CheckBox9";
            this.CheckBox9.Size = new System.Drawing.Size(35, 17);
            this.CheckBox9.TabIndex = 25;
            this.CheckBox9.Text = "...";
            this.CheckBox9.UseVisualStyleBackColor = true;
            // 
            // CheckBox10
            // 
            this.CheckBox10.AutoSize = true;
            this.CheckBox10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox10.Location = new System.Drawing.Point(193, 65);
            this.CheckBox10.Name = "CheckBox10";
            this.CheckBox10.Size = new System.Drawing.Size(35, 17);
            this.CheckBox10.TabIndex = 26;
            this.CheckBox10.Text = "...";
            this.CheckBox10.UseVisualStyleBackColor = true;
            // 
            // CheckBox11
            // 
            this.CheckBox11.AutoSize = true;
            this.CheckBox11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox11.Location = new System.Drawing.Point(159, 42);
            this.CheckBox11.Name = "CheckBox11";
            this.CheckBox11.Size = new System.Drawing.Size(69, 17);
            this.CheckBox11.TabIndex = 27;
            this.CheckBox11.Text = "Observer";
            this.CheckBox11.UseVisualStyleBackColor = true;
            // 
            // CheckBox12
            // 
            this.CheckBox12.AutoSize = true;
            this.CheckBox12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox12.Location = new System.Drawing.Point(176, 19);
            this.CheckBox12.Name = "CheckBox12";
            this.CheckBox12.Size = new System.Drawing.Size(52, 17);
            this.CheckBox12.TabIndex = 28;
            this.CheckBox12.Text = "Proxy";
            this.CheckBox12.UseVisualStyleBackColor = true;
            // 
            // CheckBox13
            // 
            this.CheckBox13.AutoSize = true;
            this.CheckBox13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox13.Location = new System.Drawing.Point(193, 88);
            this.CheckBox13.Name = "CheckBox13";
            this.CheckBox13.Size = new System.Drawing.Size(35, 17);
            this.CheckBox13.TabIndex = 29;
            this.CheckBox13.Text = "...";
            this.CheckBox13.UseVisualStyleBackColor = true;
            // 
            // CheckBox14
            // 
            this.CheckBox14.AutoSize = true;
            this.CheckBox14.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox14.Location = new System.Drawing.Point(94, 111);
            this.CheckBox14.Name = "CheckBox14";
            this.CheckBox14.Size = new System.Drawing.Size(35, 17);
            this.CheckBox14.TabIndex = 25;
            this.CheckBox14.Text = "...";
            this.CheckBox14.UseVisualStyleBackColor = true;
            // 
            // CheckBox15
            // 
            this.CheckBox15.AutoSize = true;
            this.CheckBox15.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckBox15.Location = new System.Drawing.Point(193, 111);
            this.CheckBox15.Name = "CheckBox15";
            this.CheckBox15.Size = new System.Drawing.Size(35, 17);
            this.CheckBox15.TabIndex = 29;
            this.CheckBox15.Text = "...";
            this.CheckBox15.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox1.Controls.Add(this.CheckBox15);
            this.GroupBox1.Controls.Add(this.CheckBox13);
            this.GroupBox1.Controls.Add(this.CheckBox12);
            this.GroupBox1.Controls.Add(this.CheckBox11);
            this.GroupBox1.Controls.Add(this.CheckBox14);
            this.GroupBox1.Controls.Add(this.CheckBox10);
            this.GroupBox1.Controls.Add(this.CheckBox9);
            this.GroupBox1.Controls.Add(this.CheckBox8);
            this.GroupBox1.Controls.Add(this.CheckBox7);
            this.GroupBox1.Controls.Add(this.CheckBox6);
            this.GroupBox1.Location = new System.Drawing.Point(6, 419);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(296, 132);
            this.GroupBox1.TabIndex = 30;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Design Patterns";
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.Button5);
            this.Panel1.Controls.Add(this.Button4);
            this.Panel1.Controls.Add(this.CheckBox5);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.TextBox6);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.CheckBox4);
            this.Panel1.Controls.Add(this.CheckBox3);
            this.Panel1.Controls.Add(this.CheckBox2);
            this.Panel1.Controls.Add(this.CheckBox1);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.TextBox5);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.TextBox4);
            this.Panel1.Controls.Add(this.TextBox3);
            this.Panel1.Controls.Add(this.Button2);
            this.Panel1.Controls.Add(this.Button3);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.TextBox2);
            this.Panel1.Controls.Add(this.TextBox1);
            this.Panel1.Location = new System.Drawing.Point(0, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(827, 605);
            this.Panel1.TabIndex = 31;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox2.Controls.Add(this.ComboBox1);
            this.GroupBox2.Location = new System.Drawing.Point(6, 553);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(297, 46);
            this.GroupBox2.TabIndex = 31;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Language";
            // 
            // ComboBox1
            // 
            this.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "VBNet",
            "CSharp",
            "Python",
            "Php"});
            this.ComboBox1.Location = new System.Drawing.Point(94, 19);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(111, 21);
            this.ComboBox1.TabIndex = 0;
            this.ComboBox1.Text = "VBNet";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ConfigToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpsToolStripMenuItem,
            this.ToolStripMenuItem1});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(827, 24);
            this.MenuStrip1.TabIndex = 32;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // ConfigToolStripMenuItem
            // 
            this.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem";
            this.ConfigToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ConfigToolStripMenuItem.Text = "&Config";
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ToolsToolStripMenuItem.Text = "&Tools";
            // 
            // HelpsToolStripMenuItem
            // 
            this.HelpsToolStripMenuItem.Name = "HelpsToolStripMenuItem";
            this.HelpsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.HelpsToolStripMenuItem.Text = "&Helps";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.ToolStripMenuItem1.Text = "?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(827, 630);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(843, 668);
            this.Name = "Form1";
            this.Text = "VB.Net Class Maker";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    internal System.Windows.Forms.TextBox TextBox1;
    internal System.Windows.Forms.TextBox TextBox2;
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.TextBox TextBox3;
    internal System.Windows.Forms.TextBox TextBox4;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Label Label2;
    internal System.Windows.Forms.Label Label3;
    internal System.Windows.Forms.Label Label4;
    internal System.Windows.Forms.TextBox TextBox5;
    internal System.Windows.Forms.Label Label5;
    internal System.Windows.Forms.Label Label6;
    internal System.Windows.Forms.CheckBox CheckBox1;
    internal System.Windows.Forms.CheckBox CheckBox2;
    internal System.Windows.Forms.CheckBox CheckBox3;
    internal System.Windows.Forms.CheckBox CheckBox4;
    internal System.Windows.Forms.Label Label7;
    internal System.Windows.Forms.TextBox TextBox6;
    internal System.Windows.Forms.Label Label8;
    internal System.Windows.Forms.CheckBox CheckBox5;
    internal System.Windows.Forms.Button Button2;
    internal System.Windows.Forms.Button Button3;
    internal System.Windows.Forms.Button Button4;
    internal System.Windows.Forms.Button Button5;
    internal System.Windows.Forms.CheckBox CheckBox6;
    internal System.Windows.Forms.CheckBox CheckBox7;
    internal System.Windows.Forms.CheckBox CheckBox8;
    internal System.Windows.Forms.CheckBox CheckBox9;
    internal System.Windows.Forms.CheckBox CheckBox10;
    internal System.Windows.Forms.CheckBox CheckBox11;
    internal System.Windows.Forms.CheckBox CheckBox12;
    internal System.Windows.Forms.CheckBox CheckBox13;
    internal System.Windows.Forms.CheckBox CheckBox14;
    internal System.Windows.Forms.CheckBox CheckBox15;
    internal System.Windows.Forms.GroupBox GroupBox1;
    internal System.Windows.Forms.Panel Panel1;
    internal System.Windows.Forms.MenuStrip MenuStrip1;
    internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem ConfigToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem HelpsToolStripMenuItem;
    internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
    internal System.Windows.Forms.GroupBox GroupBox2;

    internal System.Windows.Forms.ComboBox ComboBox1;
}
}