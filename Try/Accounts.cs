﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Accounts : Form
    {

        private PrintDocument printDocument1 = new PrintDocument(); // PrintDocument instance
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); // PrintPreviewDialog instance

        //changed
        private int UserID; // New field to store UserID


        public Accounts()
        {
            InitializeComponent();

            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtStudentNameIsB.Text) || String.IsNullOrEmpty(this.txtPhoneNumberIsB.Text) ||
                String.IsNullOrEmpty(this.txtEmailIsB.Text) || String.IsNullOrEmpty(this.txtAddressIsB.Text) ||
                 String.IsNullOrEmpty(this.cmbBookNameIsB.Text) || String.IsNullOrEmpty(this.txtPrice.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void Accounts_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd = new SqlCommand("select BookID, Name from Book", con);
            SqlDataReader sdr = cmd.ExecuteReader();


            //changed
            List<string> addedBooks = new List<string>(); // List to track added book names

            while (sdr.Read())
            {
                //changed
                string bookName = sdr.GetString(1); // Get the book name
                                                    // Check if the book name is already in the list
                if (!addedBooks.Contains(bookName)) // Only add if it hasn't been added before
                {
                    cmbBookNameIsB.Items.Add(new { BookID = sdr.GetInt32(0), Name = bookName });
                    addedBooks.Add(bookName); // Add the book name to the list
                }
            }
            sdr.Close();
            con.Close();
        }




        private void btnSearchIsB_Click(object sender, EventArgs e)
        {
            if (this.txtEnrollNumberIsB.Text != "")
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Users where UserType=3  AND  Enroll = '" + this.txtEnrollNumberIsB.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                if (ds.Tables[0].Rows.Count != 0)
                {
                    // Changed: Store UserID
                    UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]); // Store UserID


                    txtStudentNameIsB.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtStudentNameIsB.ReadOnly = true;


                    txtPhoneNumberIsB.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtPhoneNumberIsB.ReadOnly = true;


                    txtEmailIsB.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmailIsB.ReadOnly = true;


                    txtAddressIsB.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtAddressIsB.ReadOnly = true;
                }
                else
                {
                    this.ClearAll();
                    MessageBox.Show("Invalid Enrollment Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearAll()
        {
            this.txtStudentNameIsB.Clear();
            this.txtPhoneNumberIsB.Clear();
            this.txtEmailIsB.Clear();
            this.txtAddressIsB.Clear();
            this.txtPrice.Clear();
        }




        private void btnRefreshIsB_Click(object sender, EventArgs e)
        {
            txtEnrollNumberIsB.Clear();
            this.ClearAll();

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExitAc_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void cmbBookNameIsB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //changed
                var selectedBook = (dynamic)cmbBookNameIsB.SelectedItem;
                int BID = selectedBook.BookID; // Get BookID from the selected item

                double price = 0;



                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                con.Open();

                //changed
                SqlCommand cmdBook = new SqlCommand("SELECT Name, Price FROM Book WHERE BookID = @BID", con);
                cmdBook.Parameters.AddWithValue("@BID", BID);
                SqlDataReader sdrBook = cmdBook.ExecuteReader();


                if (sdrBook.Read())
                {
                    txtPrice.Text = sdrBook["Price"].ToString();
                    txtPrice.ReadOnly = true;
                    price = Convert.ToDouble(sdrBook["Price"]);
                }
                sdrBook.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define font and brush for printing
            Font printFont = new Font("Arial", 12);
            Brush printBrush = Brushes.Black;

            // Print data from all text boxes
            e.Graphics.DrawString("Student Name: " + txtStudentNameIsB.Text, printFont, printBrush, 100, 100);
            e.Graphics.DrawString("Phone Number: " + txtPhoneNumberIsB.Text, printFont, printBrush, 100, 130);
            e.Graphics.DrawString("Email: " + txtEmailIsB.Text, printFont, printBrush, 100, 160);
            e.Graphics.DrawString("Address: " + txtAddressIsB.Text, printFont, printBrush, 100, 190);
            e.Graphics.DrawString("Book Name: " + cmbBookNameIsB.Text, printFont, printBrush, 100, 220);
            e.Graphics.DrawString("Price: " + txtPrice.Text, printFont, printBrush, 100, 250);



        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Times New Roman", 20); // Change to Times New Roman
            float yPos = 100; // Starting position for printing
            int leftMargin = 50;

            // Print the header
            g.DrawString("Library Management System - Printout", new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Print data from all text boxes
            g.DrawString("Student Name: " + txtStudentNameIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Phone Number: " + txtPhoneNumberIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Email: " + txtEmailIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Address: " + txtAddressIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Book Name: " + cmbBookNameIsB.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            g.DrawString("Price: " + txtPrice.Text, font, Brushes.Black, leftMargin, yPos);
            yPos += 25;



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!IsValidToSave())
            {
                MessageBox.Show("Please fill all the information");
                return;
            }
            printPreviewDialog1.Document = printDocument1; // Set the document to the PrintPreviewDialog
            printPreviewDialog1.ShowDialog(); // Show the print preview

            // If user confirms from preview, proceed to print
            if (printPreviewDialog1.DialogResult == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;

                // Show print dialog
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void btnBuyAC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-94N3HCQ\SQLEXPRESS;Initial Catalog=new;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();

                // Changed: Insert UserID from Users table
                cmd.CommandText = @"
                INSERT INTO Accounts (UserID, Customer_Name, PhoneNo, Email, Address, Book, Price) 
                VALUES (@UserID, @Name, @Phone, @Email, @Address, @Book, @Price);";

                cmd.Parameters.AddWithValue("@UserID", UserID);  // Use the stored UserID

                cmd.Parameters.AddWithValue("@Name", this.txtStudentNameIsB.Text);
                cmd.Parameters.AddWithValue("@Phone", this.txtPhoneNumberIsB.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmailIsB.Text);
                cmd.Parameters.AddWithValue("@Address", this.txtAddressIsB.Text);
                cmd.Parameters.AddWithValue("@book", this.cmbBookNameIsB.Text);
                cmd.Parameters.AddWithValue("@Price", this.txtPrice.Text);


                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message);
            }
        }
    }
}
