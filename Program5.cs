/*
 * Blake Gauna
 * CMPS-4143
 * Dr. Stringfellow
 * Program 5 - Inheritance & Polymorphism
 * This program is a shape selector that allows you to select a shape you
 * want to make, enter coordinates for that shape, and display a picture of
 * the shape. This program will also calculate the permiter and area
 * of the shape, and when you finish the program, you can see the total
 * amount of shapes you made.
 */

using System;
using System.Collections;
using System.Windows.Forms;
using Quadrilaterals; //Custom shape .dll file

namespace Program_5
{
    public partial class Program5 : Form
    {
        //ArrayList of shapes to keep total count
        ArrayList shapeList = new ArrayList();
        public Program5()
        {
            InitializeComponent();
        }

        //Switch statement to put shapes in array
        public void PutInArray(int num, Quadrilateral shape)
        {
            switch (num)
            {
                case 1:
                    shapeList.Add(shape);
                    break;
                case 2:
                    shapeList.Add(shape);
                    break;
                case 3:
                    shapeList.Add(shape);
                    break;
                case 4:
                    shapeList.Add(shape);
                    break ;
            }
        }

        //Disabling labels when picking initial shape
        public void PicAndCoordFalse()
        {
            squarePic.Visible = false;
            rectanglePic.Visible = false;
            parallelagramPic.Visible = false;
            trapezoidPic.Visible = false;
            p1ActualLabel.Visible = false;
            p2ActualLabel.Visible = false;
            p3ActualLabel.Visible = false;
            p4ActualLabel.Visible = false;
            exitButton.Visible = false;
            finishButton.Visible = false;
            areaLabel.Visible = false;
            perimeterLabel.Visible = false;
        }

        //Enabling labels for square or rectangle
        public void EnableLabel1()
        {
            shapeOutcomeLabel.Text = "";
            PicAndCoordFalse();
            enterTwoLabel.Visible = true;
            enter4CoordsLabel.Visible = false;
            point1Label.Visible = true;
            point2Label.Visible = true;
            point3Label.Visible = false;
            point4Label.Visible = false;
            point1XText.Visible = true;
            point1YText.Visible = true;
            point2XText.Visible = true;
            point2YText.Visible = true;
            point2XText.Visible = true;
            point2YText.Visible = true;
            point3XText.Visible = false;
            point3YText.Visible = false;
            point4XText.Visible = false;
            point4YText.Visible = false;
            point1Label.Text = "P1";
            point2Label.Text = "P3";
            xLabel.Visible = true;
            yLabel.Visible = true;
        }

        //Enabling labels for trapezoid or parallelagram
        public void EnableLabel2()
        {
            shapeOutcomeLabel.Text = "";
            PicAndCoordFalse();
            enter4CoordsLabel.Visible = true;
            enterTwoLabel.Visible = false;
            point1Label.Visible = true;
            point2Label.Visible = true;
            point3Label.Visible = true;
            point4Label.Visible = true;
            point1XText.Visible = true;
            point1YText.Visible = true;
            point2XText.Visible = true;
            point2YText.Visible = true;
            point3XText.Visible = true;
            point3YText.Visible = true;
            point4XText.Visible = true;
            point4YText.Visible = true;
            point2Label.Text = "P2";
            xLabel.Visible = true;
            yLabel.Visible = true;
        }

        //Enabling Rectangles labels 
        public void EnableRectangleLabels()
        {
            EnableLabel1();
            enterButtonRect.Visible = true;
            enterButtonParr.Visible = false;
            enterButtonSqr.Visible = false;
            enterButtonTrap.Visible = false;
        }

        //Enabling Square Labels 
        public void EnableSquareLabels()
        {
            EnableLabel1();
            enterButtonSqr.Visible = true;
            enterButtonRect.Visible = false;
            enterButtonParr.Visible = false;
            enterButtonTrap.Visible = false;
        }
        //Enabling Parallelagram Labels 
        public void EnableParralellagramLabels()
        {
            EnableLabel2();
            enterButtonParr.Visible = true;
            enterButtonRect.Visible = false;
            enterButtonSqr.Visible = false;
            enterButtonTrap.Visible = false;
        }
        //Enabling Trapezoid Labels 
        public void EnableTrapezoidLabels()
        {
            EnableLabel2();
            enterButtonTrap.Visible = true;
            enterButtonRect.Visible = false;
            enterButtonParr.Visible = false;
            enterButtonSqr.Visible = false;
        }

        //Updating Rectangle Labels when the enter button
        //is hit
        public void UpdateRectangleLabel(string a, string b, string c,
            string d, double area, int perm)
        {
            p1ActualLabel.Visible = true;
            p2ActualLabel.Visible = true;
            p3ActualLabel.Visible = true;
            p4ActualLabel.Visible = true;
            p1ActualLabel.Text = a;
            p2ActualLabel.Text = b;
            p3ActualLabel.Text = c;
            p4ActualLabel.Text = d;
            shapeCountLabel.Text = shapeList.Count.ToString();
            rectanglePic.Visible = true;
            trapezoidPic.Visible = false;
            squarePic.Visible = false;
            parallelagramPic.Visible = false;
            enterButtonRect.Visible = false;
            shapeOutcomeLabel.Text = "Rectangle";
            finishButton.Visible = true;
            exitButton.Visible = true;
            areaLabel.Visible = true;
            perimeterLabel.Visible = true;
            areaLabel.Text = "Area: " + area.ToString() + " sq in";
            perimeterLabel.Text = "Perimeter: " + perm.ToString() + " in";
        }

        //Updating Square Labels when the enter button
        //is hit
        public void UpdateSquareLabel(string a, string b, string c, string d,
            double area, int perm)
        {
            p1ActualLabel.Visible = true;
            p2ActualLabel.Visible = true;
            p3ActualLabel.Visible = true;
            p4ActualLabel.Visible = true;
            p1ActualLabel.Text = a;
            p2ActualLabel.Text = b;
            p3ActualLabel.Text = c;
            p4ActualLabel.Text = d;
            shapeCountLabel.Text = shapeList.Count.ToString();
            rectanglePic.Visible = false;
            trapezoidPic.Visible = false;
            squarePic.Visible = true;
            parallelagramPic.Visible = false;
            enterButtonSqr.Visible = false;
            shapeOutcomeLabel.Text = "Square";
            finishButton.Visible = true;
            exitButton.Visible = true;
            areaLabel.Visible = true;
            perimeterLabel.Visible = true;
            areaLabel.Text = "Area: " + area.ToString() + " sq in";
            perimeterLabel.Text = "Perimeter: " + perm.ToString() + " in";
        }

        //Updating Parallelagram Labels when the enter button
        //is hit
        public void UpdateParallelagramLabel(string a, string b, string c,
            string d, double area, int perm)
        {
            p1ActualLabel.Visible = true;
            p2ActualLabel.Visible = true;
            p3ActualLabel.Visible = true;
            p4ActualLabel.Visible = true;
            p1ActualLabel.Text = a;
            p2ActualLabel.Text = b;
            p3ActualLabel.Text = c;
            p4ActualLabel.Text = d;
            shapeCountLabel.Text = shapeList.Count.ToString();
            rectanglePic.Visible = false;
            trapezoidPic.Visible = false;
            squarePic.Visible = false;
            parallelagramPic.Visible = true;
            enterButtonParr.Visible = false;
            shapeOutcomeLabel.Text = "Parallelagram";
            finishButton.Visible = true;
            exitButton.Visible = true;
            areaLabel.Visible = true;
            perimeterLabel.Visible = true;
            areaLabel.Text = "Area: " + area.ToString() + " sq in";
            perimeterLabel.Text = "Perimeter: " + perm.ToString() + " in";
        }

        //Updating Trapezoid Labels when the enter button
        //is hit
        public void UpdateTrapezoidLabel(string a, string b, string c,
            string d, double area, int perm)
        {
            p1ActualLabel.Visible = true;
            p2ActualLabel.Visible = true;
            p3ActualLabel.Visible = true;
            p4ActualLabel.Visible = true;
            p1ActualLabel.Text = a;
            p2ActualLabel.Text = b;
            p3ActualLabel.Text = c;
            p4ActualLabel.Text = d;
            shapeCountLabel.Text = shapeList.Count.ToString();
            rectanglePic.Visible = false;
            trapezoidPic.Visible = true;
            squarePic.Visible = false;
            parallelagramPic.Visible = false;
            enterButtonTrap.Visible = false;
            shapeOutcomeLabel.Text = "Trapezoid";
            finishButton.Visible = true;
            exitButton.Visible = true;
            areaLabel.Visible = true;
            perimeterLabel.Visible = true;
            areaLabel.Text = "Area: " + area.ToString() + " sq in";
            perimeterLabel.Text = "Perimeter: " + perm.ToString() + " in";
        }

        //Event handler for rectangle enter button
        private void enterButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Checking to see if coordinates equal eachother
                if ((Int32.Parse(point1XText.Text) ==
                    Int32.Parse(point2XText.Text)) ||
                       (Int32.Parse(point1YText.Text) ==
                       Int32.Parse(point2YText.Text)))
                {
                    MessageBox.Show("Invalid Shape Size");
                }
                //Checking to see if coordinates equal a square
                else if (Int32.Parse(point1XText.Text) -
                    Int32.Parse(point2XText.Text) ==
                    Int32.Parse(point1YText.Text) -
                    Int32.Parse(point2YText.Text))
                {
                    MessageBox.Show("That is a square! Enter the coordinates"
                       + " for a rectangle.");
                }
                //Checking to see if the coordinates are negative
                else if ((Int32.Parse(point1XText.Text) < 0) ||
                    (Int32.Parse(point2XText.Text) < 0) ||
                    (Int32.Parse(point1YText.Text) < 0) ||
                    (Int32.Parse(point2YText.Text) < 0))
                {
                    MessageBox.Show("Please enter valid coordinates");
                }
                else
                {
                    //Checking to see if x2 > x1 && y2 > y1
                    if ((Int32.Parse(point1XText.Text) >
                        Int32.Parse(point2XText.Text)) &&
                        (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text)))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point2XText.Text;
                        point2XText.Text = tempText;
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }
                    //Checking to see if x2 > x1
                    else if (Int32.Parse(point1XText.Text) >
                        Int32.Parse(point2XText.Text))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point2XText.Text;
                        point2XText.Text = tempText;
                    }
                    //Checking to see if y2 > y1
                    else if (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text))
                    {
                        string tempText = "";
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }

                    int x1 = Int32.Parse(point1XText.Text);
                    int x2 = Int32.Parse(point2XText.Text);
                    int y1 = Int32.Parse(point1YText.Text);
                    int y2 = Int32.Parse(point2YText.Text);

                    PClass point1 = new PClass(x1, y1);
                    PClass point2 = new PClass(x2, y2);
                    Rectangle rectangle = new Rectangle(point1, point2);
                    PutInArray(1, rectangle);
                    UpdateRectangleLabel(rectangle.BottomLeft(),
                        rectangle.BottomRight(), rectangle.TopLeft(),
                        rectangle.TopRight(), rectangle.Area(),
                        rectangle.Perimeter());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Event handler for Square button click
        private void enterButtonSqr_Click(object sender, EventArgs e)
        {
            try
            {
                //Checking to see if coordinates equal eachother
                if ((Int32.Parse(point1XText.Text) ==
                    Int32.Parse(point2XText.Text)) ||
                       (Int32.Parse(point1YText.Text) ==
                       Int32.Parse(point2YText.Text)))
                {
                    MessageBox.Show("Invalid Shape Size");
                }
                //Checking to see if coordinates entered will form a square.
                else if (Int32.Parse(point1XText.Text) -
                    Int32.Parse(point2XText.Text) !=
                    Int32.Parse(point1YText.Text) -
                    Int32.Parse(point2YText.Text))
                {
                    MessageBox.Show("Enter a valid square size");
                }
                //Checking to see if the coordinates are negative
                else if ((Int32.Parse(point1XText.Text) < 0) ||
                    (Int32.Parse(point2XText.Text) < 0) ||
                    (Int32.Parse(point1YText.Text) < 0) ||
                    (Int32.Parse(point2YText.Text) < 0))
                {
                    MessageBox.Show("Please enter valid coordinates");
                }
                else
                {
                    //Checking to see if x2 > x1 && y2 > y1
                    if ((Int32.Parse(point1XText.Text) >
                        Int32.Parse(point2XText.Text)) &&
                        (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text)))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point2XText.Text;
                        point2XText.Text = tempText;
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }
                    //Checking to see if x2 > x1
                    else if (Int32.Parse(point1XText.Text) >
                        Int32.Parse(point2XText.Text))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point2XText.Text;
                        point2XText.Text = tempText;
                    }
                    //Checking to see if y2 > y1
                    else if (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text))
                    {
                        string tempText = "";
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }

                    int x1 = Int32.Parse(point1XText.Text);
                    int x2 = Int32.Parse(point2XText.Text);
                    int y1 = Int32.Parse(point1YText.Text);
                    int y2 = Int32.Parse(point2YText.Text);

                    PClass point1 = new PClass(x1, y1);
                    PClass point2 = new PClass(x2, y2);
                    Square square = new Square(point1, point2);
                    PutInArray(2, square);
                    UpdateSquareLabel(square.BottomLeft(),
                        square.BottomRight(), square.TopLeft(),
                        square.TopRight(), square.Area(),
                        square.Perimeter());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Event handler for Parallelagram button click
        private void enterButtonParr_Click(object sender, EventArgs e)
        {
            try
            {
                //logic for parrallelagram enter button
                if ((Int32.Parse(point1XText.Text) ==
                    Int32.Parse(point4XText.Text)) ||
                       (Int32.Parse(point2XText.Text) ==
                       Int32.Parse(point3XText.Text)))
                {
                    MessageBox.Show("Invalid Shape Size");
                }
                //Checking to see if the coordinates are negative
                else if ((Int32.Parse(point1XText.Text) < 0) ||
                    (Int32.Parse(point2XText.Text) < 0) ||
                    (Int32.Parse(point1YText.Text) < 0) ||
                    (Int32.Parse(point2YText.Text) < 0))
                {
                    MessageBox.Show("Please enter valid coordinates");
                }
                //Checking to see if the y values are equal to eachother
                else if ((Int32.Parse(point1YText.Text) !=
                    Int32.Parse(point4YText.Text)) ||
                    (Int32.Parse(point2YText.Text) !=
                    Int32.Parse(point3YText.Text)))
                {
                    MessageBox.Show("Shape is not a parallelagram!" +
                        " Enter valid coordinates.");
                }
                //Checking to see if the two bases are equal length
                else if (Int32.Parse(point4XText.Text) -
                    Int32.Parse(point1XText.Text) !=
                    Int32.Parse(point3XText.Text) -
                    Int32.Parse(point2XText.Text))
                {
                    MessageBox.Show("Shape is not a parallelagram!" +
                        " Enter valid coordinates.");
                }
                //Checking to see if the top left point is less than
                //the bottom left point
                else if ((Int32.Parse(point4XText.Text) <
                    Int32.Parse(point1XText.Text)) ||
                    (Int32.Parse(point3XText.Text) <
                    Int32.Parse(point2XText.Text)))
                {
                    MessageBox.Show("Shape is not a parallelagram!" +
                        " Enter valid coordinates.");
                }
                else
                {
                    //Checking to see if x4 > x1 && y2 > y1
                    if ((Int32.Parse(point1XText.Text) >
                        Int32.Parse(point4XText.Text)) &&
                        (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text)))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point4XText.Text;
                        point4XText.Text = tempText;
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }
                    //Checking to see if x4 > x1
                    else if (Int32.Parse(point1XText.Text) >
                        Int32.Parse(point4XText.Text))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point4XText.Text;
                        point4XText.Text = tempText;
                    }
                    //Checking to see if y2 > y1
                    else if (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text))
                    {
                        string tempText = "";
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }

                    int x1 = Int32.Parse(point1XText.Text);
                    int x2 = Int32.Parse(point2XText.Text);
                    int y1 = Int32.Parse(point1YText.Text);
                    int y2 = Int32.Parse(point2YText.Text);
                    int x3 = Int32.Parse(point3XText.Text);
                    int x4 = Int32.Parse(point4XText.Text);
                    int y3 = Int32.Parse(point3YText.Text);
                    int y4 = Int32.Parse(point4YText.Text);

                    PClass point1 = new PClass(x1, y1);
                    PClass point2 = new PClass(x4, y4);
                    PClass point3 = new PClass(x2, y2);
                    PClass point4 = new PClass(x3, y3);
                    Parallelagram parallelagram = new Parallelagram(point1,
                        point2, point3, point4);
                    PutInArray(3, parallelagram);
                    UpdateParallelagramLabel(parallelagram.BottomLeft(),
                        parallelagram.BottomRight(), parallelagram.TopLeft(),
                        parallelagram.TopRight(), parallelagram.Area(),
                        parallelagram.Perimeter());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Event handler for Trapezoid button click
        private void enterButtonTrap_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Int32.Parse(point1XText.Text) ==
                    Int32.Parse(point4XText.Text)) ||
                       (Int32.Parse(point2XText.Text) ==
                       Int32.Parse(point3XText.Text)))
                {
                    MessageBox.Show("Invalid Shape Size");
                }
                //Checking to see if the coordinates are negative
                else if ((Int32.Parse(point1XText.Text) < 0) ||
                    (Int32.Parse(point2XText.Text) < 0) ||
                    (Int32.Parse(point1YText.Text) < 0) ||
                    (Int32.Parse(point2YText.Text) < 0))
                {
                    MessageBox.Show("Please enter valid coordinates");
                }
                //Checking to see if the y values are the same.
                else if ((Int32.Parse(point1YText.Text) !=
                    Int32.Parse(point4YText.Text)) ||
                    (Int32.Parse(point2YText.Text) !=
                    Int32.Parse(point3YText.Text)))
                {
                    MessageBox.Show("Shape is not a trapezoid! Enter " +
                        "valid coordinates.");
                }
                //Checking to see if the two x values in x2 & x3 are in
                //between x1 & x4
                else if ((Int32.Parse(point4XText.Text) <
                    Int32.Parse(point3XText.Text)) ||
                    (Int32.Parse(point1XText.Text) >
                    Int32.Parse(point2XText.Text)))
                {
                    MessageBox.Show("Shape is not a trapezoid! Enter valid" +
                        " coordinates.");
                }
                else
                {
                    //Checking to see if x4 > x1 && y2 > y1
                    if ((Int32.Parse(point1XText.Text) >
                        Int32.Parse(point4XText.Text)) &&
                        (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text)))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point4XText.Text;
                        point4XText.Text = tempText;
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }
                    //Checking to see if x4 > x1
                    else if (Int32.Parse(point1XText.Text) >
                        Int32.Parse(point4XText.Text))
                    {
                        string tempText = "";
                        tempText = point1XText.Text;
                        point1XText.Text = point4XText.Text;
                        point4XText.Text = tempText;
                    }
                    //Checking to see if y2 > y1
                    else if (Int32.Parse(point1YText.Text) >
                        Int32.Parse(point2YText.Text))
                    {
                        string tempText = "";
                        tempText = point1YText.Text;
                        point1YText.Text = point2YText.Text;
                        point2YText.Text = tempText;
                    }

                    int x1 = Int32.Parse(point1XText.Text);
                    int x2 = Int32.Parse(point2XText.Text);
                    int y1 = Int32.Parse(point1YText.Text);
                    int y2 = Int32.Parse(point2YText.Text);
                    int x3 = Int32.Parse(point3XText.Text);
                    int x4 = Int32.Parse(point4XText.Text);
                    int y3 = Int32.Parse(point3YText.Text);
                    int y4 = Int32.Parse(point4YText.Text);

                    PClass point1 = new PClass(x1, y1);
                    PClass point2 = new PClass(x4, y4);
                    PClass point3 = new PClass(x2, y2);
                    PClass point4 = new PClass(x3, y3);
                    Trapezoid trap = new Trapezoid(point1, point2,
                        point3, point4);
                    PutInArray(4, trap);
                    UpdateTrapezoidLabel(trap.BottomLeft(),
                        trap.BottomRight(), trap.TopLeft(), trap.TopRight(),
                        trap.Area(), trap.Perimeter());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            EnableSquareLabels();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            EnableRectangleLabels();
        }

        private void parallgButton_Click(object sender, EventArgs e)
        {
            EnableParralellagramLabels();
        }

        private void trapezoidButton_Click(object sender, EventArgs e)
        {
            EnableTrapezoidLabels();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You made " + shapeList.Count.ToString() +
                " shapes!");
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a shape that you want to enter" +
                " coordinates for\n\n" + "Coordinates will be entered as" +
                " p1 being the bottom left point, p2 being the top left" +
                " point, p3 being the top right point, and p4 being the" +
                " bottom right point.\n\n" +
                 "P2             P3\n\n\n\n\n" +
                 "P1             P4\n\n\n\n" +
                 "Squares and rectangles will only need points p1 and p3," +
                 " while trapezoids and parrallelagrams will need all 4" +
                 " points\n\n Ex. Square with (1,1) for P1 and (5,5) for" +
                 " P3 is valid\n Square with (1,1) for P1 and (5,6) for P3" +
                 " is NOT valid\n\nAfter the construction of a shape," +
                 " you can choose to build another shape, finish to see" +
                 " the amount of shapes you made total, or completely" +
                 " exit the program by hitting the exit button. ");
        }
    }
}


