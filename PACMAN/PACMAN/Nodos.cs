using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    class Nodos
    {
        Button button;
        int peso;
        bool estado;

        public Nodos(Button btn, int pes)
        {
            button = btn;
            peso = pes;
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
        public int pPeso
        {
            set
            {
                peso = value;
            }
            get
            {
                return peso;
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
