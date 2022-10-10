using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Kernel.Geom;




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


            Console.WriteLine("Write name of the output PDF: ");
            var Filename = Console.ReadLine();


            Image image = new Image(ImageDataFactory.Create(AllFoundImages[0].ToString()));
            PdfWriter writer = new PdfWriter(@"./"+Filename+".pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, new PageSize(image.GetImageHeight(),image.GetImageHeight()));
            

            int pageNumber = 0;
            foreach(var Files in AllFoundImages)
            {
                image = new Image(ImageDataFactory.Create(Files.ToString()));
                pdf.AddNewPage(new PageSize(image.GetImageWidth(), image.GetImageHeight()));
                image.SetFixedPosition(++pageNumber, 0, 0);
                document.Add(image);
            }
            document.Close();
            Console.WriteLine("PDF " + Filename + " is done");
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
