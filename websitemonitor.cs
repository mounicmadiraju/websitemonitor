// Author mounicraju@gmail.com

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Net;
using System.Collections.Generic;

namespace ContentExtractor
{
   
private void Startbtn_Click(object sender, EventArgs e)
   {

HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");                            
HttpWebResponse response = (HttpWebResponse)request.GetResponse();
StreamReader source = new StreamReader(response.GetResponseStream());
richTextBox1.Text = source.ReadToEnd();
timer1.Start();
timer1.Interval = 60000;

     }

private void timer1_Tick(object sender, EventArgs e)
    {

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader source2 = new StreamReader(response.GetResponseStream());
        RichTextBox checker = new RichTextBox();
        checker.Text = source2.ReadToEnd();
        if (richTextBox1.Text == "")
        {
            richTextBox1.Text = checker.Text;

        }
        else
        {


            if (richTextBox1.Text != checker.Text)
            {
                MessageBox.Show("somthing changed");
                richTextBox1.Text = checker.Text;
            }
            else
            {
                MessageBox.Show("No changes yet!");

            }
        }
    }
