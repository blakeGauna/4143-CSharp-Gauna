/*
 * Blake Gauna
 * 11/16/2022
 * Program 7 - Art Program
 * This program will generate an image drawn fully from
 * ellipses, rectangles, and polygons. It also demostrates
 * how to override the OnPaint method for a custom control.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_7
{
    public partial class Program7 : Form
    {
        public Program7()
        {
            InitializeComponent();
        }
    }

    //Creating custom panel to override OnPaint
    public class CustomPanel : Panel
    {
        //Overriden OnPaint method for panel
        protected override void OnPaint(PaintEventArgs e)
        {
          //Raising the paint event for e
          base.OnPaint(e);
          Graphics g = e.Graphics;
          //Creating all the different colored brushes
          SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
          SolidBrush textBrush = new SolidBrush(Color.Black);
          SolidBrush whiteB = new SolidBrush(Color.White);
          SolidBrush yellowB = new SolidBrush(Color.Yellow);
          SolidBrush redB = new SolidBrush(Color.Red);
          SolidBrush orangeB = new SolidBrush(Color.Orange);
          Font drawFont = new Font("MV Boli", 50);
          //Point array for polygon nose
          Point[] points = new Point[5];
          points[0] = new Point(300, 250);
          points[1] = new Point(300, 270);
          points[2] = new Point(350, 305);
          points[3] = new Point(400, 270);
          points[4] = new Point(400, 250);
          g.FillRectangle(yellowB, 15, 2, 750, 92); //Rectangle
          g.DrawString("Happy Thanksgiving!", drawFont, textBrush, 20, 1);
          g.RotateTransform(-35);
          g.FillEllipse(textBrush, 150, 470, 250, 90); //Feathers
          g.FillEllipse(orangeB, 150, 475, 240, 80);   //Feathers
          g.RotateTransform(10);                       //Rotating Shape
          g.FillEllipse(textBrush, 190, 490, 250, 90); //Feathers
          g.FillEllipse(redB, 190, 495, 240, 80);      //Feathers
          g.RotateTransform(15);                       
          g.FillEllipse(textBrush, 300, 450, 250, 90); //Feathers
          g.FillEllipse(orangeB, 300, 455, 240, 80);   //Feathers
          g.RotateTransform(45);                      
          g.FillEllipse(textBrush, 200, 75, 250, 90);  //Feathers
          g.FillEllipse(redB, 205, 80, 240, 80);       //Feathers
          g.RotateTransform(-10);                     
          g.FillEllipse(textBrush, 180, 195, 250, 90); //Feathers
          g.FillEllipse(orangeB, 185, 200, 240, 80);   //Feathers
          g.RotateTransform(-15);                      
          g.FillEllipse(textBrush, 130, 325, 250, 90); //Feathers
          g.FillEllipse(redB, 135, 330, 240, 80);      //Feathers
          g.RotateTransform(-10);                      

          g.FillEllipse(textBrush, 190, 90, 320, 320);   //black border Head
          g.FillEllipse(textBrush, 240, 290, 220, 220);  //black border Body
          g.FillEllipse(brownBrush, 200, 100, 300, 300); //Head
          g.FillEllipse(brownBrush, 250, 300, 200, 200); //Body
          g.RotateTransform(30);
          g.FillEllipse(textBrush, 395, 40, 40, 100);  //black caruncle
          g.FillEllipse(redB, 400, 40, 30, 90);        //red caruncle
          g.RotateTransform(-30);
          g.FillPolygon(textBrush, points);            //black for beak
          AddYellow(points);                           //method to edit array
          g.FillPolygon(yellowB, points);              //yellow for beak
          g.FillEllipse(textBrush, 230, 145, 135, 135); //black border LEye
          g.FillEllipse(textBrush, 335, 145, 135, 135); //black border REye
          g.FillEllipse(whiteB, 235, 150, 125, 125); //LEye
          g.FillEllipse(whiteB, 340, 150, 125, 125); //REye
          g.FillEllipse(textBrush, 260, 180, 85, 85); // black in LEye
          g.FillEllipse(textBrush, 355, 180, 85, 85); // black in LEye
          g.FillEllipse(whiteB, 280, 200, 20, 20); // white in LEye
          g.FillEllipse(whiteB, 400, 200, 20, 20); // white in LEye
        }
        //Method for creating polygon nose
        public void AddYellow(Point[] p)
        {
            for(int i = 0; i < p.Length; i++)
            {
                p[i].Y -= 6;
            }
        }
    }
}
