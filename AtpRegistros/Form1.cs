using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtpRegistros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogDataGrid.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string filename = openFileDialogDataGrid.FileName;
                    System.IO.StreamReader sr = new System.IO.StreamReader(filename);
                    string linea;
                    linea = sr.ReadLine();
                    //Guarda la primera linea de encabezado
                    string[] encabezado = linea.Split(',');
                    //Agrega el numero de columnas 
                    dgvDatos.ColumnCount = encabezado.Length;
                    //Agregar el encabezado a dgvDatos.
                    dgvDatos.Rows.Add(encabezado);
                    
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');
                        dgvDatos.Rows.Add(campos);
                    }
                }catch(System.IO.IOException si)
                {
                    MessageBox.Show("El programa esta abierto en otra parte. Cierralo e intentalo de nuevo");
                }
            }    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butGuardar_Click(object sender, EventArgs e)
        {

            DialogResult result = saveFileDialogDataGrid.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = saveFileDialogDataGrid.FileName;
                int total = dgvDatos.Rows.Count - 1;
                string[] lineas = new string[total];
                for (int i = 0; i < total; i++)
                {
                    string linea = "";
                    for (int j = 0; j < dgvDatos.Columns.Count; j++)
                    {
                        if (j == dgvDatos.Columns.Count - 1)
                            linea += dgvDatos.Rows[i].Cells[j].Value.ToString() + "";
                        else
                            linea += dgvDatos.Rows[i].Cells[j].Value.ToString() + ",";
                    }
                    lineas[i] = linea;
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
