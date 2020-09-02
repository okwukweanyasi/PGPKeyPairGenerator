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

        static string subFolder = DateTime.Now.ToString("MMddyyyyHHmmss")+ "\\";
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtPrivateKeyName = new System.Windows.Forms.TextBox();
            this.lblPublicKeyName = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPrivateKeyName = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtPublicKeyName = new System.Windows.Forms.TextBox();
            this.lblDisplayResult = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateKey.Location = new System.Drawing.Point(310, 329);
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
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEmailAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPrivateKeyName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPublicKeyName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPrivateKeyName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEmailAddress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPublicKeyName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDisplayResult, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateKey, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AcceptsTab = true;
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPassword.Location = new System.Drawing.Point(281, 276);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(256, 20);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsTab = true;
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(281, 221);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(256, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.AcceptsTab = true;
            this.txtEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmailAddress.Location = new System.Drawing.Point(281, 164);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(256, 20);
            this.txtEmailAddress.TabIndex = 2;
            // 
            // txtPrivateKeyName
            // 
            this.txtPrivateKeyName.AcceptsTab = true;
            this.txtPrivateKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrivateKeyName.Location = new System.Drawing.Point(281, 108);
            this.txtPrivateKeyName.Name = "txtPrivateKeyName";
            this.txtPrivateKeyName.Size = new System.Drawing.Size(256, 20);
            this.txtPrivateKeyName.TabIndex = 1;
            // 
            // lblPublicKeyName
            // 
            this.lblPublicKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPublicKeyName.AutoSize = true;
            this.lblPublicKeyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPublicKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicKeyName.Location = new System.Drawing.Point(38, 34);
            this.lblPublicKeyName.Name = "lblPublicKeyName";
            this.lblPublicKeyName.Size = new System.Drawing.Size(142, 20);
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
            this.lblConfirmPassword.Location = new System.Drawing.Point(32, 276);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(153, 20);
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
            this.lblPassword.Location = new System.Drawing.Point(41, 221);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(135, 20);
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
            this.lblPrivateKeyName.Location = new System.Drawing.Point(34, 108);
            this.lblPrivateKeyName.Name = "lblPrivateKeyName";
            this.lblPrivateKeyName.Size = new System.Drawing.Size(149, 20);
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
            this.lblEmailAddress.Location = new System.Drawing.Point(47, 164);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(124, 20);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "Email Address";
            this.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPublicKeyName
            // 
            this.txtPublicKeyName.AcceptsTab = true;
            this.txtPublicKeyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPublicKeyName.Location = new System.Drawing.Point(281, 34);
            this.txtPublicKeyName.Name = "txtPublicKeyName";
            this.txtPublicKeyName.Size = new System.Drawing.Size(256, 20);
            this.txtPublicKeyName.TabIndex = 0;
            // 
            // lblDisplayResult
            // 
            this.lblDisplayResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDisplayResult.AutoSize = true;
            this.lblDisplayResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayResult.Location = new System.Drawing.Point(109, 349);
            this.lblDisplayResult.Name = "lblDisplayResult";
            this.lblDisplayResult.Size = new System.Drawing.Size(0, 17);
            this.lblDisplayResult.TabIndex = 5;
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
            this.ResumeLayout(false);

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
                MessageBox.Show("Please enter a valid Email");
                return;
            }
            if (password != confirmPassword)
            {
                txtPassword.Focus();
                MessageBox.Show("The password entered and the one confirmed do not match!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!PasswordPolicy.IsValid(password))
                {
                    txtPassword.Focus();
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
