﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CTruyCapDuLieu.khoiTao().docfile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTruyCapDuLieu.khoiTao().ghifile();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void benhNhanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormBenhNhan frm = new FormBenhNhan();
            frm.Show();
        }
    }
}