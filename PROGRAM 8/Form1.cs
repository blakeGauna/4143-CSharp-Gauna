using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_8
{
    public partial class Form1 : Form
    {
        Form2 hardwareStore = new Form2(); //Hardware Store form
        Form3 toyStore = new Form3(); //Toy store form
        public Form1()
        {
            InitializeComponent();
        }
        private void hardwareStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the Parent Form of the Child window.
            hardwareStore.MdiParent = this;
            // Display the new form.
            hardwareStore.Show();
        }

        private void toyStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the Parent Form of the Child window.
            toyStore.MdiParent = this;
            // Display the new form.
            toyStore.Show();
        }

        private void insertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (hardwareStore == ActiveMdiChild) //Hardware Store form
                hardwareStore.InsertData();
            else if (toyStore == ActiveMdiChild) //Toy store form
                toyStore.InsertData();
            else
                MessageBox.Show("Select en eligible form!");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hardwareStore == ActiveMdiChild) //Hardware Store form
                hardwareStore.DeleteData();
            else if (toyStore == ActiveMdiChild) //Toy store form
                toyStore.DeleteData();
            else
                MessageBox.Show("Select en eligible form!");
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hardwareStore == ActiveMdiChild) //Hardware Store form
                hardwareStore.UpdateData();
            else if (toyStore == ActiveMdiChild) //Toy store form
                toyStore.UpdateData();
            else
                MessageBox.Show("Select en eligible form!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hardwareStore == ActiveMdiChild) //Hardware Store form
                hardwareStore.SaveData();
            else if (toyStore == ActiveMdiChild) //Toy store form
                toyStore.SaveData();
            else
                MessageBox.Show("Select en eligible form!");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program contains two store inventories that" +
                "you have to maintain. Open a store inventory by File->Open->" +
                " and selecting one of the two stores. Once opened, you can insert, " +
                "delete, or update the items. Once done doing that, you have the option" +
                " under File to save the text file. Doing do will save the text file.", "About");
        }
    }
}
