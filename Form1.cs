using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    public partial class Form1 : Form
    {
        Image pacman = Image.FromFile(@"PacmanIcono.jpg");
        Image comida = Image.FromFile(@"dot.png");
        Image cherry = Image.FromFile(@"cherry.jpg");
        //   Image che = Image.FromFile(PACMAN.Properties.Resources.)
        string temp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

        int nodoFinal = -1;
        int nodoActual = -1;
        bool final = false;
        List<int> valorNodos = new List<int>();
        List<Nodos> nodos = new List<Nodos>();
        List<Button> array = new List<Button>();
        List<int> nodosVisitados = new List<int>();
        List<NodoProfundid> nodosProfundidad = new List<NodoProfundid>();

       

        public Form1()
        {
            InitializeComponent();
        }

        public void Profundidad(NodoProfundid nodoInicial, NodoProfundid nodoFinal)
        {

        }

        public void llenanodos()
        {

            Button a0 = button1; Button b0 = button8; Button c0 = button15;
            Button a1 = button2; Button b1 = button9; Button c1 = button16;
            Button a2 = button3; Button b2 = button10; Button c2 = button17;
            Button a3 = button4; Button b3 = button11; Button c3 = button18;
            Button a4 = button5; Button b4 = button12; Button c4 = button19;
            Button a5 = button6; Button b5 = button13; Button c5 = button20;
            Button a6 = button7; Button b6 = button14; Button c6 = button21;

            Button d0 = button22;
            Button d1 = button23;
            Button d2 = button24;
            Button d3 = button25;
            Button d4 = button26;
            Button d5 = button27;
            Button d6 = button28;

            Button e0 = button29;
            Button e1 = button30;
            Button e2 = button31;
            Button e3 = button32;
            Button e4 = button33;
            Button e5 = button34;
            Button e6 = button35;

            Button f0 = button36;
            Button f1 = button37;
            Button f2 = button38;
            Button f3 = button39;
            Button f4 = button40;
            Button f5 = button41;
            Button f6 = button42;

            Button g0 = button43;
            Button g1 = button44;
            Button g2 = button45;
            Button g3 = button46;
            Button g4 = button47;
            Button g5 = button48;
            Button g6 = button49;
            array.Add(a0);
            array.Add(a1);
            array.Add(a2);
            array.Add(a3);
            array.Add(a4);
            array.Add(a5);
            array.Add(a6);
            array.Add(b0);
            array.Add(b1);
            array.Add(b2);
            array.Add(b3);
            array.Add(b4);
            array.Add(b5);
            array.Add(b6);
            array.Add(c0);
            array.Add(c1);
            array.Add(c2);
            array.Add(c3);
            array.Add(c4);
            array.Add(c5);
            array.Add(c6);
            array.Add(d0);
            array.Add(d1);
            array.Add(d2);
            array.Add(d3);
            array.Add(d4);
            array.Add(d5);
            array.Add(d6);
            array.Add(e0);
            array.Add(e1);
            array.Add(e2);
            array.Add(e3);
            array.Add(e4);
            array.Add(e5);
            array.Add(e6);
            array.Add(f0);
            array.Add(f1);
            array.Add(f2);
            array.Add(f3);
            array.Add(f4);
            array.Add(f5);
            array.Add(f6);
            array.Add(g0);
            array.Add(g1);
            array.Add(g2);
            array.Add(g3);
            array.Add(g4);
            array.Add(g5);
            array.Add(g6);

            int nodoAtras = -1;
            int nodoEnfrente = -1;
            int nodoArriba = -1;
            int nodoAbajo = -1;


            for (int i = 0; i < array.Count; i++)
            {
                nodoAtras = i - 7;
                nodoEnfrente = i + 7;
                nodoArriba = i - 1;
                nodoAbajo = i + 1;
                if (nodoAtras < 0)
                {
                    nodoAtras = -1;
                }
                if (nodoEnfrente > 48)
                {
                    nodoEnfrente = -1;
                }
                if (i <= 0 || i == 7 || i == 14 || i == 21 || i == 28 || i == 35 || i == 42)
                {
                    nodoArriba = -1;
                }
                if (i == 6 || i == 13 || i == 20 || i == 27 || i == 34 || i == 41 || i >= 48)
                {
                    nodoAbajo = -1;
                }
                NodoProfundid n = new NodoProfundid(array[i], i, nodoArriba, nodoAbajo, nodoEnfrente, nodoAtras);
                nodosProfundidad.Add(n);
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            int contador = 0;


            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.BackgroundImage = comida;
                    c.BackgroundImageLayout = ImageLayout.Stretch;
                    
                }
            }
            llenanodos();

        }

        public void Amplitud()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = null;
          
            if (sender is Button)
            {
                b = (Button)sender;
            }

            CambiarFondo(b);
          
        }

        public void CambiarFondo(Button b)
        {
            b.BackgroundImageLayout = ImageLayout.Stretch;

            int contador = 0;

            if (b.BackgroundImage == pacman)
                b.BackgroundImage =comida;
            else
                b.BackgroundImage = pacman;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int contadorPacman = 0;
            int contadorCherry = 0;

            int nodoInicial = -1;
            int nodoActual = -1;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (c.BackgroundImage == pacman)
                        contadorPacman++;

                    if (c.BackgroundImage == cherry)
                        contadorCherry++;
                }
            }

            if (contadorPacman == 0)
                MessageBox.Show("Seleccione una casilla para el PACMAN");
            else
            if (contadorCherry == 0)
                MessageBox.Show("Seleccione una casilla para la fruta");

            if (contadorPacman > 1)
                    MessageBox.Show("Seleccione sólo una casilla para el PACMAN");

            if (contadorPacman == 1 && contadorCherry > 0)
            {
                for (int i = 0; i < nodosProfundidad.Count; i++)
                {
                    if (nodosProfundidad[i].pButton.BackgroundImage == pacman)
                    {
                        nodoInicial = i;
                        nodoActual = i;
                        nodosProfundidad[i].pEstado = true;
                        MessageBox.Show("Posición del NODO ACTUAL = " + i.ToString());
                    }

                    if (nodosProfundidad[i].pButton.BackgroundImage == cherry)
                    {
                        nodoFinal = i;
                        MessageBox.Show("Posición del NODO FINALL = " + i.ToString());

                    }
                }


                if (nodoInicial == -1 || nodoFinal == -1)
                {
                    MessageBox.Show("Escoger un inicio y un fin.");
                    return;
                }

                else
                {
                    Recorrido(nodoActual);
                }

            }



        }


        public void otro(List<int> nodo)
        {
            List<int> f = new List<int>();
            List<int> posNodo = nodo;
            int nodoArriba = -1;
            int nodoAbajo = -1;
            int nodoEnfrente = -1;
            int nodoAtras = -1;
            for (int i = 0; i < posNodo.Count; i++)
            {
                nodoAtras = nodosProfundidad[posNodo[i]].pDerecha;
                nodoEnfrente = nodosProfundidad[posNodo[i]].pIzquierda;
                nodoArriba = nodosProfundidad[posNodo[i]].pArriba;
                nodoAbajo = nodosProfundidad[posNodo[i]].pAbajo;

                if (nodoFinal == nodoAbajo)
                {
                    final = true;
                }
                if (nodoFinal == nodoArriba)
                {
                    final = true;
                }
                if (nodoFinal == nodoAtras)
                {
                    final = true;
                }
                if (nodoFinal == nodoEnfrente)
                {
                    final = true;
                }
                if (final)
                {
                    return;
                }
                if (nodoAbajo != -1)
                {
                    if (!nodosProfundidad[nodoAbajo].pEstado)
                    {
                        f.Add(nodoAbajo);
                    }
                }
                if (nodoArriba != -1)
                {
                    if (!nodosProfundidad[nodoArriba].pEstado)
                    {
                        f.Add(nodoArriba);
                    }
                }
                if (nodoAtras != -1)
                {
                    if (!nodosProfundidad[nodoAtras].pEstado)
                    {
                        f.Add(nodoAtras);
                    }
                }
                if (nodoEnfrente != -1)
                {
                    if (!nodosProfundidad[nodoEnfrente].pEstado)
                    {
                        f.Add(nodoEnfrente);
                    }
                }
            }

            foreach (int i in f)
            {
                
                nodosProfundidad[i].pButton.BackgroundImage = comida;
                nodosProfundidad[i].pButton.BackgroundImageLayout = ImageLayout.Stretch;
                nodosProfundidad[i].pButton.BackgroundImage = pacman;
                nodosProfundidad[i].pEstado = true;
            }
            if (final)
            {
                return;
            }
            otro(f);
            final = true;
            f.Clear();
            return;
        }
    

    public void Recorrido(int actual)
        {

            MessageBox.Show("RECORRIDO");
            List<int> Frontera = new List<int>();
            List<int> posNodo = new List<int>();
            int nodoActual = actual;
            int nodoArriba = -1;
            int nodoAbajo = -1;
            int nodoEnfrente = -1;
            int nodoAtras = -1;
            if (nodoActual != nodoFinal)
            {
                for (int i = 0; i < nodosProfundidad.Count; i++)
                {
                    if (i == nodoActual)
                    {
                        nodoAtras = nodosProfundidad[i].pDerecha;
                        nodoEnfrente = nodosProfundidad[i].pIzquierda;
                        nodoArriba = nodosProfundidad[i].pArriba;
                        nodoAbajo = nodosProfundidad[i].pAbajo;
                    }
                }
                if (nodoFinal == nodoAbajo)
                {
                    final = true;
                }
                if (nodoFinal == nodoArriba)
                {
                    final = true;
                }
                if (nodoFinal == nodoAtras)
                {
                    final = true;
                }
                if (nodoFinal == nodoEnfrente)
                {
                    final = true;
                }
                if (final)
                {
                    return;
                }
                if (nodoAbajo != -1)
                {
                    if (!nodosProfundidad[nodoAbajo].pEstado)
                    {
                        Frontera.Add(nodoAbajo);
                    }
                }
                if (nodoArriba != -1)
                {
                    if (!nodosProfundidad[nodoArriba].pEstado)
                    {
                        Frontera.Add(nodoArriba);
                    }
                }
                if (nodoAtras != -1)
                {
                    if (!nodosProfundidad[nodoAtras].pEstado)
                    {
                        Frontera.Add(nodoAtras);
                    }
                }
                if (nodoEnfrente != -1)
                {
                    if (!nodosProfundidad[nodoEnfrente].pEstado)
                    {
                        Frontera.Add(nodoEnfrente);
                    }
                }
                foreach (int i in Frontera)
                {
                    nodosProfundidad[i].pButton.Image = null;
                    nodosProfundidad[i].pButton.BackgroundImageLayout = ImageLayout.Stretch;
                    nodosProfundidad[i].pButton.Image = pacman;
                    nodosProfundidad[i].pEstado = true;
                }
                if (final)
                {
                    return;
                }
                otro(Frontera);
                final = true;
                Frontera.Clear();
                return;
            }
            else
            {
                final = true;
                return;
            }

        }



        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button b = null;

            if (sender is Button)
            {
                b = (Button)sender;
            }

            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.BackgroundImage = cherry;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Button b = null;
            b = (Button)sender;
            b.Focus();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int numRan = 0;
            int cont = 0;

            valorNodos.Clear();

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.BackgroundImageLayout = ImageLayout.Stretch;
                    c.BackgroundImage = comida;

                  
                }
            }

            nodoFinal = -1;
            nodosVisitados.Clear();
            final = false;

        }





        /*
        public void recorridoMasCorto()
        {
            int nodoInicial = -1;
            int nodoActual = -1;

            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].pButton.BackgroundImage == pacman)
                {
                    nodoInicial = nodos[i].pPeso;
                    nodoActual = i;
                    nodos[i].pEstado = true;
                }
                if (nodos[i].pButton.BackgroundImage == cherry)
                {
                    nodoFinal = i;
                }
            }
            if (nodoInicial == -1 || nodoFinal == -1)
            {
                MessageBox.Show("Escoger un inicio y un fin.");
                return;
            }
            MenorPrimero(nodoInicial);
        }

        public void MenorPrimero(int actual)
        {
            List<int> Frontera = new List<int>();
            List<int> posNodo = new List<int>();
            int nodoActual = actual;
            int nodoArriba = -1;
            int nodoAbajo = -1;
            int nodoEnfrente = -1;
            int nodoAtras = -1;
            if (nodoActual != nodoFinal)
            {
                for (int i = 0; i < valorNodos.Count; i++)
                {
                    if (valorNodos[i] == nodoActual)
                    {
                        nodoAtras = i - 7;
                        nodoEnfrente = i + 7;
                        nodoArriba = i - 1;
                        nodoAbajo = i + 1;
                        if (nodoAtras < 1)
                        {
                            nodoAtras = -1;
                        }
                        else
                        {
                            posNodo.Add(nodoAtras);
                        }
                        if (nodoEnfrente > 48)
                        {
                            nodoEnfrente = -1;
                        }
                        else
                        {
                            posNodo.Add(nodoEnfrente);
                        }
                        if (i <= 0 || i == 7 || i == 14 || i == 21 || i == 28 || i == 35 || i == 42)
                        {
                            nodoArriba = -1;
                        }
                        else
                        {
                            posNodo.Add(nodoArriba);
                        }
                        if (i == 6 || i == 13 || i == 20 || i == 27 || i == 34 || i == 41 || i >= 48)
                        {
                            nodoAbajo = -1;
                        }
                        else
                        {
                            posNodo.Add(nodoAbajo);
                        }
                        break;
                    }
                }

                foreach (int i in posNodo)
                {
                    if (!nodos[i].pEstado)
                    {
                        if (i == nodoFinal)
                        {
                            nodoActual = nodos[i].pPeso;
                            MessageBox.Show("");
                            final = true;
                            return;
                        }
                        else
                        {
                            Frontera.Add(nodos[i].pPeso);
                        }
                    }
                }
                if (final)
                {
                    return;
                }
                if (Frontera.Count == 0)
                {
                    foreach (Nodos i in nodos)
                    {
                        if (i.pPeso == nodoActual)
                        {
                            i.pEstado = true;
                            i.pButton.BackColor = Color.White;
                        }
                    }
                    if (final)
                    {
                        return;
                    }
                    nodoActual = nodosVisitados.Last();
                    nodosVisitados.Remove(nodoActual);
                    Frontera.Clear();
                    MenorPrimero(nodoActual);
                }
                else
                {
                    nodoActual = Frontera.Min();
                }
                if (final)
                {
                    return;
                }

                foreach (Nodos i in nodos)
                {
                    if (i.pPeso == nodoActual)
                    {
                        i.pEstado = true;
                        i.pButton.BackgroundImage = pacman;
                        i.pButton.Text = i.pPeso.ToString();
                    }
                }
                MessageBox.Show("");
                nodosVisitados.Add(nodoActual);
                MenorPrimero(nodoActual);
                final = true;
                Frontera.Clear();

                return;
            }
            else
            {
                final = true;
                return;
            }

        }
        */


    }
}
