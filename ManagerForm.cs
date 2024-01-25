﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelSystem
{
    public partial class ManagerForm : Form
    {
        string type;
        string name;

        
        public ManagerForm(string type, string name)
        {
            InitializeComponent();
            this.type = type;
            this.name = name;
        }




        string text;
        int len = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox5.Visible = false;

            try
            {
                // Code that may raise an exception
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox4.Visible = false;
                label12.Text = name.ToString();
                text = "Welcome, " + name.ToString() + "!";
                label14.Text = " ";
                timer1.Start();

                userdetail();
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            LoginForm form1 = new LoginForm();
            form1.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            groupBox2.Visible = false;
            if (!groupBox1.Visible)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            if (!groupBox2.Visible)
            {
                groupBox2.Visible = true;
            }
            else
            {
                
                groupBox2.Visible = false;
                
            }
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            GuestForm form6 = new GuestForm();

            form6.GetType(type);
            form6.username(name);

            form6.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MEEditForm form3 = new MEEditForm();
            form3.GetType(type);
            form3.uname(name);
            form3.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MAproveFrom form5 = new MAproveFrom();
            form5.GetType(type);
            form5.uname(name);
            form5.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            RoomEditForm roomEditForm = new RoomEditForm(type, name);
            roomEditForm.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FilterRoomsForm frm = new FilterRoomsForm(type);
            frm.uname(name);
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //groupBox4.Visible = true;
            groupBox3.Visible = false;
            if (!groupBox4.Visible)
            {
                groupBox4.Visible = true;
            }
            else
            {
                groupBox3.Visible = true;
                groupBox4.Visible = false;
            }

        }

        private void pictureBox11_DoubleClick(object sender, EventArgs e)
        {
            //groupBox4.Visible = true;
            //groupBox3.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (len < text.Length)
            {
                label14.Text = label14.Text + text.ElementAt(len);
                len++;
            }   
            else
            {
                timer1.Stop();
            }
        }

        void userdetail()
        {
            SqlConnection connection = null;
            try
            {
                string connectiondb = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=work;Integrated Security=True";
                connection = new SqlConnection(connectiondb);
                connection.Open();


                string sql = "SELECT * FROM Table1 WHERE username=@username";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@username", name);

                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    this.label16.Text = dr.GetValue(0).ToString();
                    this.label17.Text = dr.GetValue(4).ToString();
                    this.label18.Text = dr.GetValue(5).ToString();
                    this.label19.Text = dr.GetValue(6).ToString();

                }
                else
                {
                    Console.WriteLine("No rows found for the specified status.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {

                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            userR userR1 = new userR();
            userR1.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            guestReportForm guestReportForm = new guestReportForm();
            guestReportForm.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            roomsReportForm guestReportForm = new roomsReportForm();
            guestReportForm.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (!groupBox5.Visible)
            {
                groupBox5.Visible = true;
            }
            else
            {

                groupBox5.Visible = false;

            }
        }
    }
}
