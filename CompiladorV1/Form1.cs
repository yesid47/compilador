﻿
using CompiladorV1.AnalisisLexico;
using CompiladorV1.Cache;
using CompiladorV1.ManejadorErrores;
using CompiladorV1.TablaSimbolos;
using CompiladorV1.Transversal;
using System;
using System.Windows.Forms;

namespace Compilador
{
    public partial class FormCompilador : Form
    {
        public FormCompilador()
        {
            InitializeComponent();
        }

        private void BtnCargarArchivo_Click(object sender, EventArgs e)
        {

            if (Cache.obtenerLineas().Count != 0)
            {
                if (MessageBox.Show("Se cargara un nuevo archivo y el anterior se eliminara\n¿Deseas cargar el nuevo archivo?",
                    "Cargar Archivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                { 
                    Cache.limpiarLineas();
                    Cache.CargarArchivo();
                    textBoxEditor.Clear();
                    LlenarTextBoxEditor();
                }
            }
            else
            {
                Cache.CargarArchivo();
                textBoxEditor.Clear();
            }
            LlenarTextBoxEditor();
        }

        private void BtnCompilar_Click(object sender, EventArgs e)
        {
            TablaSimbolos.Limpiar();
            TablaDummy.Limpiar();
            GestorErrores.Limpiar();
            

            textBoxReader.Clear();
            LlenarTextBoxReader();

            AnalizadorLexico analizador = new AnalizadorLexico();
            ComponenteLexico componente = new ComponenteLexico();

            while (analizador.Analizar().Lexema != "@EOF@") {
            }

                tablaSimbolos.DataSource = TablaSimbolos.ObtenerTodosSimbolos();
                tablaDummys.DataSource = TablaDummy.ObtenerTodosSimbolos();
                tablaErrores.DataSource = GestorErrores.ObtenerTodosErrores();
            

        }

        private void BtnResetear_Click(object sender, EventArgs e)
        {

        }   
        private void LlenarTextBoxReader()
        {
            Cache.BuildArchivo(textBoxEditor.Lines);
            textBoxReader.Clear();

            if (Cache.obtenerLineas().Count != 0)
            {
                foreach (Linea linea in Cache.obtenerLineas())
                {
                    textBoxReader.AppendText(linea.Numero + "- > "+ linea.Contenido + Environment.NewLine);
                }
            }
        }
        private void LlenarTextBoxEditor()
        {
            textBoxEditor.Clear();
            if (Cache.obtenerLineas().Count != 0)
            {
                foreach (Linea linea in Cache.obtenerLineas())
                {
                    textBoxEditor.AppendText(linea.Contenido + Environment.NewLine);
                }
            }
        }

        private void FormCompilador_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxEditor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxReader_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablaSimbolos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaDummys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
