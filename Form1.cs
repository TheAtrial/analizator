using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        System.IO.FileInfo fi;
        OpenFileDialog Fd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();

            Fd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            List<string> text1 = Mas();

            string []text = text1.ToArray();

            if (text.Length == 0)
            {
                MessageBox.Show("Файл пуст");
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    listBox1.Items.Add(text[i]);
                }
                MessageBox.Show("Файл открыт");
            }


        }

        public List<string> Mas()
        {
            List<string> text = new List<string>();
            if (Fd.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }
            string filename = Fd.FileName;
            string[] fileText = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1251));
            for (int i = 0; i <fileText.Length; i++)
            {
                text.Add(fileText[i]); 
            }
            return text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] text;
            listBox2.Items.Clear();
            text = new string[listBox1.Items.Count];
            
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                text[i] = listBox1.Items[i].ToString();
            }

            while (true)
            {
                List<int> mas = new List<int> { };
                string[] stroka;
                int count=0;
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                for (int i = 0; i < text.Length; i++)
                {
                    
                    stroka = text[i].Split(delimiterChars);
                    for (int j = 0; j < stroka.Length; j++)
                    {
                        int a = String.Compare(stroka[j], "goto");
                        if (a == 0)
                        {
                            mas.Add(i + 1);
                            count++;
                        }
                    }
                }
                
                if (count == 0)
                {
                    MessageBox.Show("В файле отсутствует безусловный переход!");
                    break;
                }
                else
                {
                    for (int i = 0; i < mas.Count; i++)
                    {
                        listBox2.Items.Add(mas[i]);
                    }
                    MessageBox.Show("Количество безусловных переходов "+ count + " Смотри листбокс ");
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oprog newForm = new oprog();
            newForm.Show();
        }
    }
}
