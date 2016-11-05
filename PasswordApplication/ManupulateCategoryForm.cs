using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordApplication
{
    public partial class ManupulateCategoryForm : Form
    {
        public ManupulateCategoryForm()
        {
            InitializeComponent();
        }

        private void cancelAddCatrgoryButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void SaveNewCategoryButton_Click(object sender, EventArgs e)
        {
            //Do some validation
            string pattern = "^([1-zA-Z0-1@.\\s]{1,255})$";
            bool isValidate;
            string categoryName = CategoryNameTextBox.Text.Trim();
            Validation validator = new Validation();
            isValidate = validator.RegValidation(categoryName, pattern);
            //If validation pass run ManupulateCatagory and pass the category name to the parameter
            if (isValidate)
            {
                if (!checkIsCategoryExisted(categoryName))
                {
                    if (DatabaseHelper.addNewCategory(categoryName))
                    {
                        MessageBox.Show(String.Format("{0} has been inserted.",categoryName));
                        this.Close();
                        this.Dispose();
                        MainForm MF = new MainForm();
                        MF.PopulateCategories();
                        MF.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input a validated category name.");

            }
        }

        private bool checkIsCategoryExisted(string categoryName)
        {
            //Get the category table category name
            DataSet ResultSet = new DataSet();
            //Assume UserAccountID is 1
            DatabaseHelper.manupulateCategory(1).Fill(ResultSet, "Categories");

            if (ResultSet.Tables.Count > 0)
            {
                //Check if the category name already in the category table
                foreach (DataRow row in ResultSet.Tables[0].Rows)
                {
                    if (categoryName == row["CategoryName"].ToString())
                    {
                        MessageBox.Show("Category name alreay existed.");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return  false;
            }
        }
     
    }
}
