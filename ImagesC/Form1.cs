using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImagesC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string fname1, fname2;
        Bitmap img1, img2;
        bool flag = true;
        int count1 = 0, count2 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
           // pictureBox1.Visible = false;

            string img1_ref, img2_ref;
            img1 = new Bitmap(fname1);
            img2 = new Bitmap(fname2);

            progressBar1.Maximum = img1.Width;
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            flag = false;
                            break;
                        }
                        count1++;
                    }
                    progressBar1.Value++;
                }

                if (flag == false)
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("Lo siento, las imágenes no coiciden por: " + count2 + " pixeles diferentes");
                }
                    
                else
                {
                    MessageBox.Show("Las imágenes son las mismas , " + count1 + " es igual que: " + count2 + " pixel a pixel");
                    Image newImage = Image.FromFile(fname1);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = newImage;
                    pictureBox1.Visible = true;
                    //pictureBox1.Image = ;
                }

            }
            else
            {
                MessageBox.Show("Las imágenes no coinciden en tamaño");
                progressBar1.Visible = false;
            }
                

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.Title = "Images";
            openFileDialog2.Filter = "All Images|*.jpg; *.bmp; *.png";

            openFileDialog2.ShowDialog();
            if (openFileDialog2.FileName.ToString() != "")
            {
                fname2 = openFileDialog2.FileName.ToString();
                label2.Visible = true;
                label2.Text = fname2;
            }
            
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                fname1 = openFileDialog1.FileName.ToString();
                label1.Visible = true;
                label1.Text = fname1;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            pictureBox1.Visible = false;
        }


    }
}
