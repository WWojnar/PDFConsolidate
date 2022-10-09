using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;




namespace PDFConsolidate
{
    class Program
    {
        static int Main(string[] args)
        {
            InitialPrint();
            string[] AllFoundImages = null;

            Console.WriteLine("Write EXTENSION of the files that will be parsed into PDF");
            Console.WriteLine("Write nothing to exit program");
            String Extension = Console.ReadLine();
            if(Extension.Equals(""))
            {
                Console.WriteLine("Exiting");
                return 0;
            }
            if(Directory.Exists(@".\IMAGES"))
            {
                AllFoundImages = Directory.GetFiles(@".\IMAGES", "*." + Extension);
                if(AllFoundImages.Equals(null))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Couldn't find any files in folder IMAGES with EXTENSION - " + Extension);
                    Console.WriteLine("Press any key to close");
                    var Key = Console.ReadKey();
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Couldn't find IMAGES catalog");
                Console.WriteLine("Press any key to close");
                var Key = Console.ReadKey();
                return 0;
            }

            
            foreach(var Files in AllFoundImages)
            {
                Console.WriteLine(Files.ToString());
            }
            var key = Console.ReadKey();
            return 0;
            
        }

        static void InitialPrint()
        {
            Console.WriteLine("Non-commercional use only.");
            Console.WriteLine("---===GreyCat Rules===---");
            Console.WriteLine("This program will collect all images in IMAGES catalog and connect them into one PDF");
            
            Console.WriteLine("");
        }
    }
}
