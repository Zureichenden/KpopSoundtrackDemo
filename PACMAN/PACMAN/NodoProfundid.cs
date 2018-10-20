using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class NodoProfundid
    {
        Button button;
        int Pos;
        int arriba;
        int abajo;
        int derecha;
        int izquierda;
        bool estado;
       public NodoProfundid(Button Button, int pos ,int Arriba, int Abajo, int Derecha, int Izquierda)
        {
            button = Button;
            arriba = Arriba;
            abajo = Abajo;
            derecha = Derecha;
            izquierda = Izquierda;
            Pos = pos;
        }
        public Button pButton
        {
            get
            {
                return button;
            }
            set
            {
                button = value;
            }
        }
        public int pPos
        {
            set
            {
                Pos = value;
            }
            get
            {
                return Pos;
            }
        }
        public int pArriba
        {
            set
            {
                arriba = value;
            }
            get
            {
                return arriba;
            }
        }
        public int pAbajo
        {
            set
            {
                abajo = value;
            }
            get
            {
                return abajo;
            }
        }
        public int pDerecha
        {
            set
            {
                derecha = value;
            }
            get
            {
                return derecha;
            }
        }
        public int pIzquierda
        {
            set
            {
                izquierda = value;
            }
            get
            {
                return izquierda;
            }
        }
        public bool pEstado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
    }
}
