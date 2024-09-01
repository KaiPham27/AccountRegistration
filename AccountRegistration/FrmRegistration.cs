using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountRegistration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            txtStudentNum.KeyPress += txtStudentNo_KeyPress;
            txtFirstName.KeyPress += txtName_KeyPress;
            txtLastName.KeyPress += txtName_KeyPress;
            txtMiddleName.KeyPress += txtName_KeyPress;
            txtAge.KeyPress += txtAge_KeyPress;
            txtAge.TextChanged += txtAge_TextChanged;
            txtContactNum.KeyPress += txtContactNo_KeyPress;
            txtContactNum.TextChanged += txtContactNo_TextChanged;
        }

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !IsRomanNumeral(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAge.Text.Length > 3)
            {
                txtAge.Text = txtAge.Text.Substring(0, 3);
                txtAge.SelectionStart = txtAge.Text.Length;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            if (txtContactNum.Text.Length > 10)
            {
                txtContactNum.Text = txtContactNum.Text.Substring(0,11);
                txtContactNum.SelectionStart = txtContactNum.Text.Length;
            }
        }

        private bool IsRomanNumeral(char c)
        {
            return "IVXLCDM".IndexOf(char.ToUpper(c)) >= 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                StudentInfoClass.FirstName = txtFirstName.Text.ToString();
                StudentInfoClass.LastName = txtLastName.Text.ToString();
                StudentInfoClass.MiddleName = txtMiddleName.Text.ToString();
                StudentInfoClass.Address = txtAddress.Text.ToString();
                StudentInfoClass.Program = cbProgram.Text.ToString();
                StudentInfoClass.Age = long.Parse(txtAge.Text.ToString());
                StudentInfoClass.ContactNo = long.Parse(txtContactNum.Text.ToString());
                StudentInfoClass.StudentNo = long.Parse(txtStudentNum.Text.ToString());

                FrmConfirm confirmForm = new FrmConfirm();
                var result = confirmForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtMiddleName.Clear();
                    txtAddress.Clear();
                    cbProgram.SelectedIndex = -1;
                    txtAge.Clear();
                    txtContactNum.Clear();
                    txtStudentNum.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please fill out all fields correctly before proceeding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
            {
                MessageBox.Show("Middle Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Select a program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text) || txtAge.Text.Length > 3)
            {
                MessageBox.Show("Enter a valid age (1-3 digits).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNum.Text) || txtContactNum.Text.Length != 11)
            {
                MessageBox.Show("Contact Number must be correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentNum.Text))
            {
                MessageBox.Show("Student Number is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

