using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using button;

namespace Program_8
{
    public partial class Form3 : Form
    {
        CustForm form = new CustForm();
        //alignment string for string.format()
        string alignment = "{0,-35} {1,-35} {2,-35} {3,-35}";
        public Form3()
        {
            InitializeComponent();
        }

        //Insert method
        public void InsertData()
        {
            try
            {
                //Shows form
                form.ShowDialog();
                //If Ok button is pressed
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string id = form.ID.ToString();
                    string name = form.Names.ToString();
                    string price = form.Price.ToString();
                    string quan = form.Quantity.ToString();
                    //Add item to toy list
                    ToyList.Items.Add(String.Format(alignment, id, name, price, quan));
                }
            }
            catch
            {
                MessageBox.Show("You have no items selected!");
            }
        }

        //Delete method
        public void DeleteData()
        {
            try
            {
                //Index cant be 0 since that is my ID, Name, etc.
                //Any other selected index deletes
                if (ToyList.SelectedIndex != 0)
                    ToyList.Items.RemoveAt(ToyList.SelectedIndex);
                else
                    MessageBox.Show("Haha nice try! Pick an actual item...");
            }
            catch
            {
                MessageBox.Show("You have no items selected!");
            }
        }

        //Update method
        public void UpdateData()
        {
            try
            {
                //store selected item
                string selectedItem = ToyList.Items[ToyList.SelectedIndex].ToString();
                string arrElement = " ";
                arrElement = string.Join(" ", selectedItem.Split(new char[0],
                    StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
                string[] stringArray = arrElement.Split(' ');
                form.ID = stringArray[0];
                form.Names = stringArray[1];
                form.Price = stringArray[2];
                form.Quantity = stringArray[3];
                string formID = form.ID;
                form.ShowDialog();
                //If ok button is hit
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Can't change original ID
                    if (formID != form.ID.ToString())
                        MessageBox.Show("ID cannot be updated!");
                    else
                    {
                        stringArray[1] = form.Names.ToString();
                        stringArray[2] = form.Price.ToString();
                        stringArray[3] = form.Quantity.ToString();
                        ToyList.Items.RemoveAt(ToyList.SelectedIndex);
                        //Remove item where its at and replace with updated info at bottom
                        ToyList.Items.Add(String.Format(alignment, stringArray[0],
                            stringArray[1], stringArray[2], stringArray[3]));
                    }
                }
            }
            catch
            {
                MessageBox.Show("You have no items selected");
            }
        }

        //Save method
        public void SaveData()
        {
            string line = "";
            string finalLine = "";
            string arrElement = "";
            //Add all items onto a string
            for (int i = 1; i < ToyList.Items.Count; i++)
            {
                line = ToyList.Items[i].ToString();
                arrElement = string.Join(" ", line.Split(new char[0],
                    StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
                string[] stringArray = arrElement.Split(' ');
                finalLine += stringArray[0] + ' ' + stringArray[1] + ' ' + stringArray[2] + ' ' + stringArray[3];
                finalLine += '\n';
            }
            //clears file, then writes updated string to file 
            using (FileStream fs = new FileStream(@"ToyInventory.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                StreamReader sr = new StreamReader(fs);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // discard the contents of the file by setting the length to 0
                    fs.SetLength(0);

                    // write the new content
                    sw.Write(finalLine);
                }
            }
        }

        //When form3 loads, the inventory file is loaded 
        private void Form3_Load(object sender, EventArgs e)
        {
            string text;
            FileStream infile = new FileStream("ToyInventory.txt",
            FileMode.Open, FileAccess.Read);
            //Set file from where data is read
            StreamReader fileReader = new StreamReader(infile);
            //read a line
            text = fileReader.ReadLine();
            ToyList.Items.Add(String.Format(alignment, "ID", "Item", "Price", "Quantity"));
            //while not eof
            while (text != null)
            {
                string[] words = text.Split(' ');
                ToyList.Items.Add(String.Format(alignment, words[0], words[1], words[2], words[3]));
                text = fileReader.ReadLine();
            }
            infile.Close();
            fileReader.Close();
        }
    }
}
