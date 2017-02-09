using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinimumVertexCover;

namespace MinimumVertexCoverGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var loader = new TextListGraphLoader();
            loader.LoadTextList(textBox1.Text);
            var graph = new Graph(loader);
            var minVertexCover = graph.GetMinVertexCover();
            var maxIndependentSets = graph.GetMaxIndependentSets(minVertexCover);
            if (minVertexCover.Count > 0)
            {
                string txt = "Bazy minimalne:\r\n";
                txt += SetFormatter.ListToString(minVertexCover, "B");
                txt += "\r\nZbiory niezależne:\r\n";
                txt += SetFormatter.ListToString(maxIndependentSets, "S");
                textBox2.Text = txt;
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Nie znaleziono poprawnych krawędzi grafu", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void wczytajZListyTekstowejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream file;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((file = openFileDialog1.OpenFile()) != null)
                {
                    var reader = new StreamReader(file);
                    var txt = reader.ReadToEnd();
                    textBox1.Text = txt;
                    reader.Close();
                }
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Wyniki puste", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                Stream file;
                saveFileDialog1.Filter = "Pliki txt (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((file = saveFileDialog1.OpenFile()) != null)
                    {
                        var writer = new StreamWriter(file);
                        writer.Write(textBox2.Text);
                        writer.Close();
                    }
                }
            }
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var txt =
                "Program oblicza bazy minimalne i maksymalne zbiory niezależne grafu na podstawie tekstowej listy krawędzi.\r\n";
            txt += "Format: [nazwa krawędzi] [wierzchołek 1]-[wierzchołek 2] [waga]\r\n";
            txt += "Linijki nie spełniające powyższego formatu są ignorowane. Liczba wierzchołków wykrywana na podstawie największego numeru wierzchołka.\r\n\r\n";
            txt += "Autor: Paweł Pietrasz, 1EF-DI, 12.05.2016";

            MessageBox.Show(txt, "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
