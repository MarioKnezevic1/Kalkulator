using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class KalkulatorForma : Form
    {
        private TextBox UnosIzrazaTextBox;
        private Button IzracunajButton;
        private TextBox RezultatTextBox;

        public KalkulatorForma()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            UnosIzrazaTextBox = new TextBox();
            IzracunajButton = new Button();
            RezultatTextBox = new TextBox();

            SuspendLayout();

            UnosIzrazaTextBox.Location = new System.Drawing.Point(12, 12);
            UnosIzrazaTextBox.Name = "UnosIzrazaTextBox";
            UnosIzrazaTextBox.Size = new System.Drawing.Size(200, 20);
            Controls.Add(UnosIzrazaTextBox);

            IzracunajButton.Location = new System.Drawing.Point(12, 38);
            IzracunajButton.Name = "IzracunajButton";
            IzracunajButton.Size = new System.Drawing.Size(75, 23);
            IzracunajButton.Text = "Izračunaj";
            IzracunajButton.Click += new System.EventHandler(this.IzracunajButton_Click);
            Controls.Add(IzracunajButton);

            RezultatTextBox.Location = new System.Drawing.Point(12, 67);
            RezultatTextBox.Name = "RezultatTextBox";
            RezultatTextBox.ReadOnly = true;
            RezultatTextBox.Size = new System.Drawing.Size(200, 20);
            Controls.Add(RezultatTextBox);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(224, 106);
            Name = "KalkulatorForma";
            Text = "Kalkulator";

            ResumeLayout(false);
            PerformLayout();
        }

        private void IzracunajButton_Click(object sender, EventArgs e)
        {
            try
            {
                string izraz = UnosIzrazaTextBox.Text.Replace(',', '.');

                CultureInfo cultureInfo = CultureInfo.CurrentCulture;
                DataTable table = new DataTable();
                DataColumn column = new DataColumn("Izraz", typeof(double), izraz);
                table.Columns.Add(column);
                DataRow row = table.NewRow();
                table.Rows.Add(row);

                double rezultat = (double)row["Izraz"];

                RezultatTextBox.Text = rezultat.ToString(cultureInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do pogreške pri izračunavanju: {ex.Message}", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KalkulatorForma());
        }
    }
}