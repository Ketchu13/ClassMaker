using System;
using System.Linq;
using System.Windows.Forms;

namespace ClassMakerCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		public enum Language
		{
			VBNet = 0,
			CSharp = 1,
			Python = 2,
			Php = 3
		}

		public string WriteImports(Language lang)
		{
			string import = null;
			switch (lang) {
				case Language.VBNet:
                    import = "Imports System.Collections.Generic\r\nImports System.Drawing\r\nImports System.IO\r\n\r\n";

					break;
				case Language.CSharp:
                    import = "using System.Collections.Generic;\r\nusing System.Drawing;\r\nusing System.IO;\r\n\r\n";

					break;
				case Language.Python:
                    import = "import struct\r\nimport getopt\r\nimport sys\r\nimport os\r\n\r\n";

					break;
				case Language.Php:
					import = null;

					break;
			}
			return import;
		}

		public string WriteHeader(Language thislang, bool isNamespace)
		{
			string header = null;

			switch (thislang) {
				case Language.VBNet:
					if (isNamespace) {
						header = "Namespace " + TextBox6.Text + "\r\n";
					}
					header += "	" + "Public Class " + TextBox5.Text + "\r\n";
					if (CheckBox1.Checked == true) {
						header += "	" + "	" + "	" + "Inherits " + TextBox4.Text + "\r\n" + "\r\n";
					}

					break;
				case Language.CSharp:
					if (isNamespace) {
						header = "Namespace " + TextBox6.Text + "{" + "\r\n";
					}
					header += "	" + "public Class " + TextBox5.Text;
					if (CheckBox1.Checked == true) {
						header += " : " + TextBox4.Text;
					}
					header += " {\n\n";

					break;

				case Language.Python:
					header = "class " + TextBox5.Text;
					if (CheckBox1.Checked == true) {
						header += "(" + TextBox4.Text + ")" + "\r\n";
					} else {
						header += "(object):" + "\r\n";
					}

					break;

				case Language.Php:
					header = null;

					break;
			}
			return header;
		}

		public string WriteFields(Language thisLang, string[] thisFields)
		{
			string fields = null;


			for (int i = 0; i <= thisFields.Length-1 ; i++) {
				string thisType = "String";
				string[] strField = thisFields[i].Split('#');
				string varName = thisFields[i];

				if ((strField != null)) {
					thisType = strField[1];
					varName = strField[0];
				}
				switch (thisLang) {
					case Language.VBNet:
						fields += "	" + "	" + "Private me" + varName + " as " + thisType + "\r\n";

						break;
					case Language.CSharp:
						fields += "	" + "	" + "Private " + thisType + " me" + varName + ";" + "\r\n";

						break;
					case Language.Python:
						break;
					//todo   fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

					case Language.Php:
						fields = null;

						break;
				}
			}

			return fields + "\r\n";
		}

		public string WriteProperties(Language thisLang, string[] thisFields)
		{
			string properties = null;


			for (int i = 0; i <= thisFields.Length-1; i++) {
				string thisType = "String";
				string[] strField = thisFields[i].Split( '#');
				string varName = thisFields[i];

				if ((strField != null)) {
					thisType = strField[1];
					varName = strField[0];
				}
				switch (thisLang) {
					case Language.VBNet:
						properties += "\t" + "\t" + "Public Property " + varName + "() as " + thisType + "\r\n" + "	" + "	" + "	" + "Get" + "\r\n" + "	" + "	" + "	" + "	" + "Return me" + varName + "\r\n" + "	" + "	" + "	" + "End Get" + "\r\n" + "	" + "	" + "	" + "Set(value as " + thisType + ")" + "\r\n" + "	" + "	" + "	" + "	" + "me" + varName + " = value" + "\r\n" + "	" + "	" + "	" + "End Set" + "\r\n" + "	" + "	" + "End Property\r\n\r\n";

						break;
					case Language.CSharp:
                        thisType = thisType.Replace( "Boolean", "bool");
                        thisType = thisType.Replace( "Single", "float");
                        thisType = thisType.Replace( "Object", "var");
						properties += "\t" + "\t" + "public " + thisType + " " + varName + " {" + "\r\n" + "	" + "	" + "	" + "get { return this.me" + varName + "; }" + "\r\n" + "	" + "	" + "	" + "set { this.me" + varName + " = value; }" + "\r\n" + "	" + "	" + "}\r\n\r\n";

						break;
					case Language.Python:
						break;
					//todo   fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

					case Language.Php:
						properties = null;

						break;
				}
			}

			return properties;
		}

		public string WriteFooter(Language thisLang, bool isNamespace)
		{
			string footer = null;

			switch (thisLang) {
				case Language.VBNet:
					if (isNamespace) {
						footer += "\t" + "\t" + "End Class" + "\r\n";
						footer += "\t" + "End Namespace" + "\r\n";
					} else {
						footer += "\t" + "End Class" + "\r\n";
					}

					break;
				case Language.CSharp:
					if (isNamespace) {
						footer += "\t" + "\t" + "}" + "\r\n";
					}
					footer += "\t" + "}" + "\r\n";

					break;
				case Language.Python:
					break;
				//todo   footer &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

				case Language.Php:
					footer = null;

					break;
			}


			return footer;
		}

		public string WriteCreators(Language thisLang, bool isNamespace, string[] thisFields)
		{
			string creators = null;

			string header = null;
			string content = null;
			string footer = null;

            for (int i = 0; i <= thisFields.Length-1; i++)
            {
				switch (thisLang) {
					case Language.VBNet:
						if (isNamespace) {
						}
                        header += "\t\tPublic Sub New(";

						break;
					case Language.CSharp:
						if (isNamespace) {
						}
                        header += "\t\tpublic " + TextBox5.Text + "(";

						break;
					case Language.Python:
                        header = "\tdef __init__(self,";

						break;
					case Language.Php:

						break;

				}
				string[] strType = thisFields[i].Split(';');
				//todo
				for (int j = 0; j <= strType.Length-1; j++) {
					string[] strType2 = strType[j].Split('#');
					string varName = strType2[0];
					string varType = strType2[1];
                    if (j > 0 & j <= strType.Length-1)
                    {
						header += ", ";
					}
					switch (thisLang) {
						case Language.VBNet:
							if (isNamespace) {
							}
							header += "Byval this" + varName + " as " + varType;
                            content += "\t\t\tme" + varName + " = this" + varName + "\r\n";
                            if (j >= strType.Length-1)
                            {
								header += ")" + "\r\n";

							}

							break;
						case Language.CSharp:
							if (isNamespace) {
							}

							header += varType + " this" + varName;
                            content += "\t\t\tthis.me" + varName + " = this" + varName + ";" + "\r\n";
							if (j >= strType.Length) {
								header += ")";
								if (CheckBox2.Checked == true) {
									header += ":" + TextBox4.Text + " {" + "\r\n";
								} else {
									header += " {" + "\r\n";
								}
							}

							break;
						case Language.Python:
							header += "this" + varName;
							//, ThisDug, thisEntrance):"
                            content += "\t\tself._me" + varName + " = this" + varName + "\r\n";
							if (j >= strType.Length-1) {
								header += "):" + "\r\n";
							}

							break;
						case Language.Php:

							break;

					}

				}

				switch (thisLang) {
					case Language.VBNet:
						if (isNamespace) {
						}
                        footer = "\t" + "\t" + "End Sub\r\n\r\n";

						break;
					case Language.CSharp:
						if (isNamespace) {
						}
                        footer = "\t" + "\t" + "}\r\n\r\n";

						break;
					case Language.Python:
						break;
					//todo   footer &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

					case Language.Php:
						footer = null;

						break;
				}
				creators += header + content + footer;
			}
			return creators;
		}

		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
            string str = TextBox1.Text.Replace('\t', '#');
			string[] str1 = str.Split('\n');
            string strb = TextBox3.Text.Replace('\t', '#');
			string[] str2 = strb.Split('\n');
            Language lang = (Language) ComboBox1.SelectedIndex;
			TextBox2.Text = WriteImports(lang) + WriteHeader(lang, CheckBox5.Checked) + WriteFields(lang, str1) + WriteCreators(lang, CheckBox5.Checked, str2) + WriteProperties(lang, str1) + WriteFooter(lang, CheckBox5.Checked);

		}



		private void Form1_Load(System.Object sender, System.EventArgs e)
		{
			ComboBox1.SelectedIndex = 0;

		}

        private void Label6_Click(object sender, System.EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

      

       


	}
}
