using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using button;
using static System.Net.Mime.MediaTypeNames;

namespace Program_8
{
    public partial class Form2 : Form
    {
        CustForm form = new CustForm();
        //alignment string for string.format()
        string alignment = "{0,-35} {1,-35} {2,-35} {3,-35}";
        public Form2()
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
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //Set properties in ItemForm to strings so we can insert it to the list.
                        string id = form.ID.ToString();
                        string name = form.Names.ToString();
                        string price = form.Price.ToString();
                        string quan = form.Quantity.ToString();
                        //Adding item
                        HardwareList.Items.Add(String.Format(alignment, id, name, price, quan));
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
                //If there is a selected index, remove it when delete is hit
                //Except for the first line since it holds ID, Name, etc.
                if (HardwareList.SelectedIndex != 0)
                    HardwareList.Items.RemoveAt(HardwareList.SelectedIndex);
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
                //Grabs item and deletes the long spaces inbetween the words.
                string selectedItem = HardwareList.Items[HardwareList.SelectedIndex].ToString();
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
                if(form.ShowDialog() == DialogResult.OK)
                {
                    //Can't update the ID!
                    if (formID != form.ID.ToString())
                        MessageBox.Show("ID cannot be updated!");
                    else
                    {
                        stringArray[1] = form.Names.ToString();
                        stringArray[2] = form.Price.ToString();
                        stringArray[3] = form.Quantity.ToString();
                        //Removing old unupdated item and replacing it with new item
                        //at the bottom
                        HardwareList.Items.RemoveAt(HardwareList.SelectedIndex);
                        HardwareList.Items.Add(String.Format(alignment, stringArray[0],
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
            //Grabs items and stores them into one long string.
            for (int i = 1; i < HardwareList.Items.Count; i++)
            {
                line = HardwareList.Items[i].ToString();
                arrElement = string.Join(" ", line.Split(new char[0],
                    StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
                string[] stringArray = arrElement.Split(' ');
                finalLine += stringArray[0] + ' ' + stringArray[1] + ' ' + stringArray[2] + ' ' + stringArray[3];
                finalLine += '\n';
            }
            //Puts the string in the file.
            using (FileStream fs = new FileStream(@"Inventory.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
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

        //When Form2 is loaded, the items are read in from the input file and
        //distributed into the listbox.
        private void Form2_Load(object sender, EventArgs e)
        {
            string text;
            FileStream infile = new FileStream("Inventory.txt",
            FileMode.Open, FileAccess.Read);
            //Set file from where data is read
            StreamReader fileReader = new StreamReader(infile);
            //read a line
            text = fileReader.ReadLine();
            HardwareList.Items.Add(String.Format(alignment,"ID", "Item", "Price", "Quantity"));
            while (text != null)
            {
                string[] words = text.Split(' ');
                HardwareList.Items.Add(String.Format(alignment, words[0], words[1], words[2], words[3]));
                text = fileReader.ReadLine();
            }
            fileReader.Close();
            infile.Close();
        }
    }
}

//Inheriting Form from the button namespace so I can use it.
namespace button
{
    public class CustForm: Form1
    {
        public CustForm()
        {
           
        }

    }
}

