using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace FirebaseApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "XJzWUoGiVVxmpLCBZROfKWzgfmw4EmcA28qDeKWB",
            BasePath = "https://csharpfirebase-dd3ea-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                MessageBox.Show("Check internet conncetion");
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            Serviceman std = new Serviceman()
            {
                FullName = nameTbox.Text,
                Rank = rankTbox.Text,
                ServiceNumber = numberTbox.Text,
                Unit = unitTbox.Text
            };
            var setter = client.Set("ServicemenList/" + numberTbox.Text,std);
            MessageBox.Show("Person added successfully");
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            var result = client.Get("ServicemenList/" + numberTbox.Text);
            Serviceman std = result.ResultAs<Serviceman>();
            nameTbox.Text = std.FullName;
            rankTbox.Text = std.Rank;
            numberTbox.Text = std.ServiceNumber;
            unitTbox.Text = std.Unit;
            MessageBox.Show("Data imported successfully");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Serviceman std = new Serviceman()
            {
                FullName = nameTbox.Text,
                Rank = rankTbox.Text,
                ServiceNumber = numberTbox.Text,
                Unit = unitTbox.Text
            };
            var setter = client.Update("ServicemenList/" + numberTbox.Text, std);
            MessageBox.Show("Data updated successfully");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = client.Delete("ServicemenList/" + numberTbox.Text);
            MessageBox.Show("Deleted successfully");
        }
    }
    }
}
