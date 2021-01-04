using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{
    public partial class Form1 : Form
    {
        int xplayer = 0, oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        private void Xpontos_Click(object sender, EventArgs e)
        {

        }

        private void Opontos_Click(object sender, EventArgs e)
        {

        }

        private void btnclean_Click(object sender, EventArgs e)
        {

            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            rodadas = 0;
            jogo_final = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    checagem(2);
                }
            }
        }


        void Vencedor (int PlayerQueGanhou)
        {
            jogo_final = true;
            if (PlayerQueGanhou == 1)
            {
                xplayer++;
                Xpontos.Text = Convert.ToString(xplayer);
                MessageBox.Show("jogador x ganhou!");
                turno = true;
            }
            else
            {
                oplayer++;
                Opontos.Text = Convert.ToString(oplayer);
                MessageBox.Show("jogador 0 ganhou!");
                turno = false;
            }
        }

        void checagem(int checagemPlayer)
        {
            string suporte = "";

            if(checagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                 if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal +2])
                    {
                        Vencedor(checagemPlayer);
                        return;
                    }
                }
            }

            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(checagemPlayer);
                        return;
                    }
                }
            }

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(checagemPlayer);
                    return;
                }

                
            }


            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(checagemPlayer);
                    return;
                }


            }


         if (rodadas == 9 && jogo_final == false )
            {
                empatesPontos++;
                Empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }

            
        }
    }
}
