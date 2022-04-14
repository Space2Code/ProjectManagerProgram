using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ProjectManagement
{
    public partial class Form1 : Form
    {
        MyTodos myTodo = new MyTodos();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var UserInput = textBox1.Text;
            var index = listBox1.Items.Add(UserInput);
            myTodo.TodoList.Add(index.ToString(), UserInput);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
            myTodo.TodoList.Remove(listBox1.SelectedIndex.ToString());
            myTodo.DoneList.Remove(listBox2.SelectedIndex.ToString());
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            myTodo.DoneList.Add(listBox2.Items.Count.ToString(), curItem);
            myTodo.TodoList.Remove(listBox1.SelectedIndex.ToString());
            listBox1.Items.Remove(curItem);
            listBox2.Items.Add(curItem);
        }

        private void SaveTool_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Json File | *.json";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var path = saveFileDialog1.FileName; // OpenFile().ToString();
                    var res = JsonConvert.SerializeObject(myTodo);
                    System.IO.File.WriteAllText(path, res);
                }
                catch (Exception)
                {
                    throw;
                }            
            }
        }

        private void OpenTool_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var fileContent = string.Empty;

            openFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();

                    var res = System.IO.File.ReadAllText(filePath);
                    MyTodos myListBox = JsonConvert.DeserializeObject<MyTodos>(res);

                    foreach (var item in myListBox.TodoList)
                    {
                        listBox1.Items.Add(item.Value);
                    }

                    foreach (var item in myListBox.DoneList)
                    {
                        listBox2.Items.Add(item.Value);
                    }

                }
            }
        }
    }
}
