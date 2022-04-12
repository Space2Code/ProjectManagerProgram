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

namespace ProjectManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var UserInput = textBox1.Text;
            listBox1.Items.Add(UserInput);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(curItem);
            listBox2.Items.Add(curItem);
        }

        private void SaveTool_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Json File | *.json";

            JsonSerializerOptions options = new JsonSerializerOptions { Converters = new[] { new  () }};
            string fileName = saveFileDialog1.FileName;
            var jsonList = JsonSerializer.Serialize(listBox1, options);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());                                    

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    writer.Write(jsonList);
                }
                //writer.Dispose();
                //writer.Close();
            }
        }

        private void OpenTool_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var fileContent = string.Empty;

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    listBox1.Items.Clear();
                    while (reader.Peek() >= 0)
                    {
                        listBox1.Items.Add(reader.ReadLine());                       
                    }
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
