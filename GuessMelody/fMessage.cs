﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GuessMelody
{
    public partial class fMessage : Form
    {
        int timeAnswer = 10;
        public fMessage()
        {
            InitializeComponent();
        }

        private void FMessage_Load(object sender, EventArgs e)
        {
            timeAnswer = 10;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeAnswer--;
            lbTimer.Text = timeAnswer.ToString();
            if (timeAnswer == 0)
            {
                timer1.Stop();
                SoundPlayer sp = new SoundPlayer("Resources\\FilmLeaderBlip.wav");
                sp.Play();
            }
        }

        private void FMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void LblShowAnswer_Click(object sender, EventArgs e)
        {
            var mp3file = TagLib.File.Create(Victorina.answer);
            lblShowAnswer.Text = mp3file.Tag.FirstAlbumArtist + " " + mp3file.Tag.Title;
        }
    }
}
