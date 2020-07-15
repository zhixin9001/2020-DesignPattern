using System;
using System.Drawing;

namespace _4_Decorator.Undo
{
    class Program
    {
        static void Main(string[] args)
        {
            IText text = new TextObject();
            //IDecorator text1 = new BoldDecorator(text);
            //text = new ColorDecorator(text);
            //Console.WriteLine(text.Content);

            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            text = new ColorDecorator(text);
            Console.WriteLine(text.Content);

            ColorState colorState = new ColorState();
            colorState.Color = Color.Red;
            BoldState boldState = new BoldState();
            boldState.IsBold = true;
            IDecorator root = (IDecorator)text;
            root.Refresh<ColorDecorator>(colorState);
            root.Refresh<BoldDecorator>(boldState);

            Console.WriteLine(text.Content);
            colorState = null;
            root.Refresh<ColorDecorator>(colorState);
            Console.WriteLine(text.Content);
        }
    }
}
