using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerApp
{
    public partial class Form1 : Form
    {
        SoccerContext db;
        public Form1()
        {
            InitializeComponent();

            db = new SoccerContext();
            db.Players.Load();

            dataGridView1.DataSource = db.Players.Local.ToBindingList();
        }
        // добавление
        private void button1_Click(object sender, EventArgs e)
        {
            PlayerForm plForm = new PlayerForm();
            DialogResult result = plForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Player player = new Player();
            player.Age = (int)plForm.numericUpDown1.Value;
            player.Name = plForm.textBox1.Text;
            player.Position = plForm.comboBox1.SelectedItem.ToString();

            db.Players.Add(player);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");
        }
        // редактирование
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Player player = db.Players.Find(id);

                PlayerForm plForm = new PlayerForm();

                plForm.numericUpDown1.Value = player.Age;
                plForm.comboBox1.SelectedItem = player.Position;
                plForm.textBox1.Text = player.Name;

                DialogResult result = plForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                player.Age = (int)plForm.numericUpDown1.Value;
                player.Name = plForm.textBox1.Text;
                player.Position = plForm.comboBox1.SelectedItem.ToString();

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");

            }
        }
        // удаление
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Player player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Новая кнопка");
            int qq = 5;
            MessageBox.Show("Привет!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Новая кнопка");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int ii = 1;

            MessageBox.Show("Новый checkBox");
        }
    }
}
