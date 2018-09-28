using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL
{
   public  class Traza
    {
       public void Trazas(string text)
       {

           if (!System.IO.File.Exists(@"C:\ControlErrores\ControlErrores.txt"))
           {
               const string fic = @"C:\ControlErrores\ControlErrores.txt";
           

               System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
               sw.WriteLine(text);
               sw.Close();
              
           }else
           {
               const string fileName = @"C:\ControlErrores\ControlErrores.txt";


              // string fileName = "temp.txt";
               // esto inserta texto en un archivo existente, si el archivo no existe lo crea
               StreamWriter writer = File.AppendText(fileName);
               writer.WriteLine(text);
               writer.Close();
           }         
          
       }

    }
}
