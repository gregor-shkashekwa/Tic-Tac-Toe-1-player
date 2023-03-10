using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp101
{
    public partial class Form1 : Form
    {
        // Создание объектов игры
        private int x = 12, y = 12;
        private Button[,] buttons = new Button[3, 3];
        private int player;
        public int bot;
        public Form1()
        {
            InitializeComponent();
            // Создание поля
            this.Height = 700;
            this.Width = 900;
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                }
            }
            setButtons();
        }

        // Параметры поля
        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 206 * j, 12 + 206 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 138);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        // Параметры хода
        private void button1_Click(object sender, EventArgs e)
        {
            switch (player)
            {
                // Ход игрока
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "x");
                    player = 0;
                    label1.Text = "Текущий ход: Игрок 1";

                    Random rand = new Random();

                    int x, y;

                    do
                    {
                        x = rand.Next(3);
                        y = rand.Next(3);
                    }
                    while (buttons[x, y].Enabled == false);

                    buttons[x, y].PerformClick();

                    break;
                    // Ход бота
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "o");
                    label1.Text = "Текущий ход: Игрок 2";



                    player = 1;
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            checkWin();
        }

        // Обработчик окончания игры
        private void checkWin()
        {

            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text && buttons[0,0].Text == buttons[0, 2].Text)// Три полных ряда
            {

                if (buttons[0, 0].Text == "x" && buttons[0, 1].Text == "x" && buttons[0, 2].Text == "x") // Игрок побеждает
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[0, 0].Text == "o" && buttons[0, 1].Text == "o" && buttons[0, 2].Text == "o") // Бот побеждает
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text && buttons[1, 0].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text == "x" && buttons[1, 1].Text == "x" && buttons[1, 2].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[1, 0].Text == "o" && buttons[1, 1].Text == "o" && buttons[1, 2].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text && buttons[2, 0].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text == "x" && buttons[2, 1].Text == "x" && buttons[2, 2].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[2, 0].Text == "o" && buttons[2, 1].Text == "o" && buttons[2, 2].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text && buttons[0, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text == "x" && buttons[1, 0].Text == "x" && buttons[2, 0].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[0, 0].Text == "o" && buttons[1, 0].Text == "o" && buttons[2, 0].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text && buttons[0, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text == "x" && buttons[1, 1].Text == "x" && buttons[2, 1].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[0, 1].Text == "o" && buttons[1, 1].Text == "o" && buttons[2, 1].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text && buttons[0, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text == "x" && buttons[1, 2].Text == "x" && buttons[2, 2].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[0, 2].Text == "o" && buttons[1, 2].Text == "o" && buttons[2, 2].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text == "x" && buttons[1, 1].Text == "x" && buttons[2, 2].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[0, 0].Text == "o" && buttons[1, 1].Text == "o" && buttons[2, 2].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text && buttons[2, 0].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text == "x" && buttons[1, 1].Text == "x" && buttons[0, 2].Text == "x")
                {
                    MessageBox.Show("Вы победили!");
                    return;
                }
                else if (buttons[2, 0].Text == "o" && buttons[1, 1].Text == "o" && buttons[0, 2].Text == "o")
                {
                    MessageBox.Show("Вы проиграли!");
                    return;
                }
            }
        }

        // Кликабельность кнопок
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }
    }
}
