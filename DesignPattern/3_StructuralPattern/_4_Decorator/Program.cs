using System;
using System.Drawing;

namespace _4_Decorator.Undo
{
    class Program
    {
        static void Main(string[] args)
        {
            IText text = new TextObject();
            //默认不加粗、黑色字体
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Console.WriteLine(text.Content);  //< Black > hello </ Black >

            //修改为加粗、红色字体
            ColorState colorState = new ColorState();
            colorState.Color = Color.Red;
            BoldState boldState = new BoldState();
            boldState.IsBold = true;
            IDecorator root = (IDecorator)text;
            root.Refresh<ColorDecorator>(colorState);
            root.Refresh<BoldDecorator>(boldState);
            Console.WriteLine(text.Content); //< Red >< b > hello </ b ></ Red >

            //取消颜色设置
            colorState = null;
            root.Refresh<ColorDecorator>(colorState);
            Console.WriteLine(text.Content); //< b > hello </ b >
        }
    }
}
