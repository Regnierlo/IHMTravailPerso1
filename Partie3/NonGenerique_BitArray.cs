using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Partie3
{
    class NonGenerique_BitArray
    {
        // Attribut
        private BitArray _bitArray;

        public NonGenerique_BitArray()
        {
            this._bitArray = new BitArray(0);
        }

        public NonGenerique_BitArray(int nb)
        {
            this._bitArray = new BitArray(nb);
        }

        public BitArray BitArray
        {
            get { return _bitArray; }
            set { _bitArray = value; }
        }

        // -----------------------------------------------------------------

        public void afficher()
        {
            
        }


    }
}
