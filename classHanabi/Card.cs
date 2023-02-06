using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classHanabi
{
    public class Card
    {
        private int iIndex;
        private string strColor;
        private int iNumber;

        public int Index { get => iIndex; set => iIndex = value; }
        public string Color { get => strColor; set => strColor = value; }
        public int Number { get => iNumber; set => iNumber = value; }


        public Card(int index, string color, int number)
        {
            Index = index;
            Color = color;
            Number = number;
        }

        public override string ToString()
        {
            return Color[0] + "" + Number;
        }
    }
}
