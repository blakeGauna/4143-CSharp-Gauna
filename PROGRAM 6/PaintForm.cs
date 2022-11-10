/*  Blake Gauna
 *  CMPS-4143
 *  Program 6 : Drawing Tool
 *  This program uses graphics and allows you to draw on a panel,
 *  select different colors, brush sizes, and more!
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_6
{
    public partial class PaintForm : Form
    {
        //Creating ShouldPaint, setting to false.
      bool ShouldPaint { get; set; }  = false;
      int size = 4;                //size
      Color color = new Color();   //new color object
      protected int xCoord, yCoord;
      private List<Point> points = new List<Point>();
      public PaintForm()
        {
            InitializeComponent();
        }
        //Holding mouse down makes ShouldPaint true
      private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ShouldPaint = true;
        }
        //Letting go of mouse makes ShouldPaint false
      private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ShouldPaint = false;
        }
        //When ShouldPaint is true (when the mouse is being held down),
        //and the mouse is moving, it will create circles with whatever
        //size has been selected, as well as the color.
      private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
                if (ShouldPaint)
                {
                    using (Graphics graphics = drawingPanel.CreateGraphics())
                    {
                        graphics.FillEllipse(new SolidBrush(color), e.X, 
                            e.Y, size, size);
                        points.Add(new Point(e.X, e.Y));
                    }
                }
                
        }
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
           for(int i = 0; i < points.Count; i++)
            {
                graphics.FillEllipse(new SolidBrush(color), points[i].X, points[i].Y, size, size);
            }     
            
        }


        //Checked changed event handler to check if the color radio
        //buttons have been updated
        private void colors_CheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                color = Color.FromName(rb.Text);
            }
        }
        //Checked changed event handler to check if the size radio
        //buttons have been updated
      private void size_CheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                groupBoxSize.Visible = true;
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (rb.Text == "Small")
                {
                    labelSize.Visible = false;
                    pixelDiameter.Visible = false;
                    size = 4;
                }
                else if (rb.Text == "Medium")
                {
                    labelSize.Visible = false;
                    pixelDiameter.Visible = false;
                    size = 12;
                }
                else if (rb.Text == "Large")
                {
                    labelSize.Visible = false;
                    pixelDiameter.Visible = false;
                    size = 24;
                }
                else
                {
                    labelSize.Visible = true;
                    pixelDiameter.Visible = true;
                }
            }
        }
        //Checked changed event handler to check if the numerical up
        //and down counter has been updated
      private void number_CheckedChanged(Object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;
            size = (int)upDown.Value;
        }
        //Clear button fills screen with white rectangle
      private void buttonClear_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = drawingPanel.CreateGraphics())
            {
                   graphics.Clear(Color.White);
                points.Clear();
            }
        }
        //Closes Program
      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Rainbow Color Pallete, setting labels to color, then using
        //Color.FromName(label.Text)
      private void rOYGBIVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redButton.Text = "Red";
            orangeButton.Text = "Orange";
            yellowButton.Text = "Yellow";
            greenButton.Text = "Green";
            blueButton.Text = "Blue";
            indigoButton.Text = "Indigo";
            violetButton.Text = "Violet";
            blackButton.Text = "Black";
        }
        //Tropical Color Pallete, setting labels to color, then using
        //Color.FromName(label.Text)
        private void tropicalToolStripMenuItem_Click(object sender,
          EventArgs e)
        {
            redButton.Text = "Aquamarine";
            orangeButton.Text = "Turquoise";
            yellowButton.Text = "Teal";
            greenButton.Text = "Green";
            blueButton.Text = "Navy";
            indigoButton.Text = "Wheat";
            violetButton.Text = "Tan";
            blackButton.Text = "Black";

        }
        //Grayscale Color Pallete, setting labels to color, then using
        //Color.FromName(label.Text)
        private void grayscaleToolStripMenuItem_Click(object sender,
          EventArgs e)
        {
            redButton.Text = "White";
            orangeButton.Text = "WhiteSmoke";
            yellowButton.Text = "Gainsboro";
            greenButton.Text = "LightGray";
            blueButton.Text = "Silver";
            indigoButton.Text = "DarkGray";
            violetButton.Text = "DimGray";
            blackButton.Text = "Black";
        }
        //Setting whatever the user has entered into the textbox
        //as the color of the brush
      private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Color.FromName(toolStripTxtEdit.Text).IsKnownColor)
                blackButton.Text = toolStripTxtEdit.Text;
            else
                MessageBox.Show("Invalid Color! Enter a valid color name.");
            
        }
        //Setting whatever the user has entered into the textbox
        //as the background color of the panel
        private void changePanelColorToolStripMenuItem_Click(object sender,
          EventArgs e)
        {
            if (Color.FromName(toolStripTxtPanel.Text).IsKnownColor)
                drawingPanel.BackColor = Color.FromName(toolStripTxtPanel.Text);
            else
                MessageBox.Show("Invalid Color! Enter a valid color name.");
        }
        //Setting whatever the user has entered into the textbox
        //as the background color of the group boxes
        private void changeComboBoxColorToolStripMenuItem_Click(object sender,
          EventArgs e)
        {
         if (Color.FromName(toolStripTextCombo.Text).IsKnownColor)
         {
           groupBoxColor.BackColor = Color.FromName(toolStripTextCombo.Text);
           groupBoxSize.BackColor = Color.FromName(toolStripTextCombo.Text);
         }
            else
                MessageBox.Show("Invalid Color! Enter a valid color name.");
        }
        //Help button
      private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a color and the pixel diameter of the" +
                " pen. Choose other color palletes or select your own" +
                " color, but the color must be name specific to one in" +
                " Visual Studio. Clear the screen by hitting the Clear" +
                " button. Exit the program from the file tab.", "Help");
        }

        
    }
}
