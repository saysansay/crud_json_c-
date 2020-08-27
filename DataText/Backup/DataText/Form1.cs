using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSample
{
    public partial class Form1 : Form
    {
        private DataText conDB;
        public Form1()
        {
            InitializeComponent();
            conDB = new DataText();
            conDB.Path = "C:/config.dat"; // dont use '\'!!
            fillCombo();
        }
        private void fillCombo()
        {
            this.combo.Items.Clear();
            int temp = conDB.Entries();
            if (temp > 0)
            {
                temp--;
                for (int i = 0; i <= temp; i++)
                {
                    string name = "";
                    conDB.ReadEntrie(i, ref name);
                    if (name == "")
                    {
                        name = "<empty>";
                    }
                    this.combo.Items.Add("ID: " + i + " - " + name);
                }
                combo.SelectedIndex = 0;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int temp = conDB.Entries();
            MessageBox.Show(temp.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {

            conDB.InsertEntrie(txtName.Text,txtLastName.Text,txtPhone.Text,txtMail.Text,txtWeb.Text);
            txtID.Text = Convert.ToString(conDB.Entries()-1);
            fillCombo();
        }

        private void read(int id)
        {
            txtID.Text = id.ToString();
            string str_name = "", str_lastname = "", str_phone = "", str_mail = "", str_web = "";

            bool result = conDB.ReadEntrie(id, ref str_name, ref str_lastname, ref str_phone, ref str_mail, ref str_web);
            txtName.Text = str_name;
            txtLastName.Text = str_lastname;
            txtPhone.Text = str_phone;
            txtMail.Text = str_mail;
            txtWeb.Text = str_web;
            if (!result) { MessageBox.Show("Invalid record"); }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") { txtID.Text = "0"; }
            read(Convert.ToInt32(txtID.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
           string str_name = "", str_lastname = "", str_phone = "", str_mail = "", str_web = "";
           str_name =txtName.Text ;
           str_lastname =txtLastName.Text;
           str_phone =txtPhone.Text;
           str_mail =txtMail.Text;
           str_web =txtWeb.Text;
            int id = Convert.ToInt32(txtID.Text);
            conDB.UpdateEntrie(id, str_name, str_lastname, str_phone, str_mail, str_web);
            fillCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            conDB.DeleteEntrie(id);
            read(0);
            fillCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResult.Text = conDB.Select(txtKey.Text, Convert.ToInt32(txtColid.Text));
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = combo.SelectedIndex.ToString();
            read(Convert.ToInt32(txtID.Text));
        }
    }
}