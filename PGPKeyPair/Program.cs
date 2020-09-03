using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Configuration;
using PgpCore;
using System.IO;
using System.Diagnostics;

namespace PGPKeyPair
{
    /* Utility for creating PGP key pair
    */
    public partial class Program :Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblPublicKeyName;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtEmailAddress;
        private TextBox txtPrivateKeyName;
        private Label lblConfirmPassword;
        private Label lblPassword;
        private Label lblPrivateKeyName;
        private Label lblEmailAddress;
        private TextBox txtPublicKeyName;
        private Label lblDisplayResult;
        private Button btnCreateKey;
        private SplitContainer splitContainer1;
        private LinkLabel lnkLblDisplayOutputPath;
        static string subFolder = DateTime.Now.ToString("MMddyyyyHHmmss")+ "\\";
        static string fullPath = "";
        public Program()
        {
            InitializeComponent();
        }
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }
        private void InitializeComponent()
        {
            this.btnCreateKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtPrivateKeyName = new System.Windows.Forms.TextBox();
            this.lblPublicKeyName = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPrivateKeyName = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtPublicKeyName = new System.Windows.Forms.TextBox();
            this.lblDisplayResult = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lnkLblDisplayOutputPath = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateKey.Location = new System.Drawing.Point(310, 314);
            this.btnCreateKey.Name = "btnCreateKey";
            this.btnCreateKey.Size = new System.Drawing.Size(198, 57);
            this.btnCreateKey.TabIndex = 0;
            this.btnCreateKey.Text = "Create Key Pair";
            this.btnCreateKey.UseVisualStyleBackColor = true;
            this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.42241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.57759F));
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmPassword, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEmailAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPrivateKeyName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPublicKeyName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPrivateKeyName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEmailAddress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPublicKeyName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateKey, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AcceptsTab = true;
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPassword.Location = new System.Drawing.Point(281, 265);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(256, 22);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.AcceptsTab = true;
            this.txtEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmailAddress.Location = new System.Drawing.Point(281, 153);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(256, 22);
            this.txtEmailAddress.TabIndex = 2;
            // 
            // txtPrivateKeyName
            // 
            this.txtPrivateKeyName.AcceptsTab = true;
            this.txtPrivateKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrivateKeyName.Location = new System.Drawing.Point(281, 97);
            this.txtPrivateKeyName.Name = "txtPrivateKeyName";
            this.txtPrivateKeyName.Size = new System.Drawing.Size(256, 22);
            this.txtPrivateKeyName.TabIndex = 1;
            // 
            // lblPublicKeyName
            // 
            this.lblPublicKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPublicKeyName.AutoSize = true;
            this.lblPublicKeyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPublicKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicKeyName.Location = new System.Drawing.Point(20, 27);
            this.lblPublicKeyName.Name = "lblPublicKeyName";
            this.lblPublicKeyName.Size = new System.Drawing.Size(177, 25);
            this.lblPublicKeyName.TabIndex = 0;
            this.lblPublicKeyName.Text = "Public Key Name";
            this.lblPublicKeyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 264);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(187, 25);
            this.lblConfirmPassword.TabIndex = 0;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(27, 208);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(163, 25);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Enter Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrivateKeyName
            // 
            this.lblPrivateKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrivateKeyName.AutoSize = true;
            this.lblPrivateKeyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPrivateKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateKeyName.Location = new System.Drawing.Point(16, 95);
            this.lblPrivateKeyName.Name = "lblPrivateKeyName";
            this.lblPrivateKeyName.Size = new System.Drawing.Size(185, 25);
            this.lblPrivateKeyName.TabIndex = 0;
            this.lblPrivateKeyName.Text = "Private Key Name";
            this.lblPrivateKeyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddress.Location = new System.Drawing.Point(33, 152);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(151, 25);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "Email Address";
            this.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPublicKeyName
            // 
            this.txtPublicKeyName.AcceptsTab = true;
            this.txtPublicKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPublicKeyName.Location = new System.Drawing.Point(281, 28);
            this.txtPublicKeyName.Name = "txtPublicKeyName";
            this.txtPublicKeyName.Size = new System.Drawing.Size(256, 22);
            this.txtPublicKeyName.TabIndex = 0;
            // 
            // lblDisplayResult
            // 
            this.lblDisplayResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDisplayResult.AutoSize = true;
            this.lblDisplayResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayResult.Location = new System.Drawing.Point(58, 29);
            this.lblDisplayResult.Name = "lblDisplayResult";
            this.lblDisplayResult.Size = new System.Drawing.Size(0, 20);
            this.lblDisplayResult.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsTab = true;
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(281, 210);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(256, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 306);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblDisplayResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lnkLblDisplayOutputPath);
            this.splitContainer1.Size = new System.Drawing.Size(212, 73);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.TabIndex = 6;
            // 
            // lnkLblDisplayOutputPath
            // 
            this.lnkLblDisplayOutputPath.AutoSize = true;
            this.lnkLblDisplayOutputPath.Location = new System.Drawing.Point(9, 29);
            this.lnkLblDisplayOutputPath.Name = "lnkLblDisplayOutputPath";
            this.lnkLblDisplayOutputPath.Size = new System.Drawing.Size(0, 17);
            this.lnkLblDisplayOutputPath.TabIndex = 0;
            this.lnkLblDisplayOutputPath.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkLblDisplayOutputPath_LinkClicked);
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(687, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGP Key Management";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void lnkLblDisplayOutputPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", $"/open, {fullPath}");
        }

        
        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            string encryptionKeyLocation = ConfigurationManager.AppSettings["KEYS_FILE_LOCATION"].ToString();
            string publicKeyName = txtPublicKeyName.Text;
            string privateKeyName = txtPrivateKeyName.Text;
            string email = txtEmailAddress.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            
            publicKeyName = $"{Regex.Replace(publicKeyName, "[^0-9a-zA-Z]+", "_")}_Public.asc";
            privateKeyName = $"{Regex.Replace(privateKeyName, "[^0-9a-zA-Z]+", "_")}_Private.asc";
            if (publicKeyName.Trim().Length<1 || privateKeyName.Trim().Length < 1 || email.Trim().Length < 1 ||
                password.Trim().Length < 1 || confirmPassword.Trim().Length < 1)
            {
                MessageBox.Show("Please fill all fields!", "Blank Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Regex expr = new Regex(@"^[a-zA-Z][\w\.-][a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!isEmail)
            {
                txtEmailAddress.Focus();
                txtEmailAddress.SelectAll();
                MessageBox.Show("Please enter a valid Email");
                return;
            }
            if (password != confirmPassword)
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
                MessageBox.Show("The password entered and the one confirmed do not match!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!PasswordPolicy.IsValid(password))
                {
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    MessageBox.Show("Password must have minimum of 6 characters, be alphanumeric, and include a special character!", "Password Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string rootDirectory = $"{encryptionKeyLocation}{subFolder}";
            try
            {
                if (!Directory.Exists(rootDirectory))
                {
                    Directory.CreateDirectory(rootDirectory);
                }
                using (PGP pgp = new PGP())
                {
                   
                    pgp.GenerateKey($"{rootDirectory}{publicKeyName}", $"{rootDirectory}{privateKeyName}", email, password);
                    lblDisplayResult.Text = $"Key pair created to {rootDirectory}";
                    lnkLblDisplayOutputPath.Text = $"Key pair created to {rootDirectory}";
                    fullPath = rootDirectory;

                    btnCreateKey.Enabled = false;
                    MessageBox.Show("Key created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: An error occured creating pgp key pair {rootDirectory}{publicKeyName}---->>{rootDirectory}{privateKeyName}, Message: {ex.Message}");
                MessageBox.Show("Key not created. check console for errors", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
