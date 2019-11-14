using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace POS_system
{
    class receiptGenerator
    {
        /// <summary>
        /// Generates the Receipt
        /// </summary>
        public void receiptGeneratorfunction(DateTime time, List<product> products, POSSysteminterface form)
        {
            List<product> vat12 = new List<product>();
            List<product> vat25 = new List<product>();


            foreach (product p in products)
            {
                if (p.Vat == 25)
                {
                    vat25.Add(p);
                }
                else
                {
                    vat12.Add(p);
                }
            }
            
            /// <summary>
            /// Variables
            /// </summary>
            int prisTot = products.Sum(total => total.Price);
            int receiptVat12 = vat12.Sum(total => total.Price);
            int receiptVat25 = vat25.Sum(total => total.Price);
            string timestamp = time.ToString(" yyyy MM_dd HHmm ss");

            /// <summary>
            /// Implementing custom font to the receipt
            /// </summary>
            FontFactory.Register("Consola.ttf", "Consolas");
            FontFactory.Register("CONSOLAB.ttf", "CONSOLAB");
            var standardfont = FontFactory.GetFont("Consolas", 11.0f, BaseColor.BLACK);
            var boldfont = FontFactory.GetFont("CONSOLAB", 16.0f, BaseColor.BLACK);

            /// <summary>
            /// Data about standard pagesize
            /// </summary>
            int pagewidth = 260;
            int pageheight = 400;

            /// <summary>   
            /// Loop for changing the pagesize dynamically 
            /// </summary>
            foreach (object o in form.ShoppingCart.Items)
            {
                pageheight = pageheight + 16;
            }

            /// <summary>
            /// Generating pdf
            /// </summary>
            FileStream fs = new FileStream("../../../receipt/receipt" + timestamp + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Rectangle rec = new Rectangle(pagewidth, pageheight);
            Document doc = new Document(rec);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            /// <summary>
            /// Adds the restaurant name bigger and bold font
            /// </summary>
            var companyName = new Paragraph("Restaurangnamn AB", boldfont);
            companyName.Alignment = 1;
            doc.Add(companyName);

            /// <summary>
            /// Array with each line of text in the upper part of the receipt
            /// </summary>
            string[] stringArrayTop = new string[] 
            {
                "Gatagatan 12",
                "755 25, Uppsala",
                "Tel: 040-000 00 00",
                "     ",
                "Datum: " + time.ToString(),
                "Säljare: Peter",
                "Kvittonr: 1-439043-17-10-2018",
                "-------------------------------"
            };

            /// <summary>
            /// Array for the allignment of the upper text
            /// </summary>
            int[] intArrayTop = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 };

            /// <summary>
            /// Loop for adding the upper information to the receipt
            /// </summary>
            for (int i = 0; i < stringArrayTop.Length; i++)
            {    
                var paragraph = new Paragraph(stringArrayTop[i],standardfont);
                paragraph.Alignment = intArrayTop[i];
                doc.Add(paragraph);
            }

            /// <summary>
            /// Loop for adding the products to the receipt
            /// </summary>
            foreach (product o in products)
            {
                Chunk glue = new Chunk(new iTextSharp.text.pdf.draw.VerticalPositionMark());
                Phrase phProduct = new Phrase();
                var test = new Paragraph();
                phProduct.Add(new Chunk(o.Item.ToString(), standardfont));
                phProduct.Add(new Chunk(glue));
                phProduct.Add(new Chunk(o.Price.ToString() + " kr", standardfont));
                test.Add(phProduct);
                doc.Add(test);
            }

            /// <summary>
            /// Adds a seperating line
            /// </summary>
            var divider = new Paragraph("-------------------------------", standardfont);
            divider.Alignment = 1;
            doc.Add(divider);

            /// <summary>
            /// Adds the total price to the receipt, with dynamic spacing
            /// </summary>
            Chunk spacing = new Chunk(new iTextSharp.text.pdf.draw.VerticalPositionMark());
            Phrase phtotalprice = new Phrase();
            var totalPrice = new Paragraph();
            phtotalprice.Add(new Chunk("Total", boldfont));
            phtotalprice.Add(new Chunk(spacing));
            phtotalprice.Add(new Chunk(prisTot.ToString() + " kr", boldfont));
            totalPrice.Add(phtotalprice);
            doc.Add(totalPrice);

            var paragraphSpace = new Paragraph("      ");
            paragraphSpace.Alignment = 1;
            doc.Add(paragraphSpace);

            /// <summary>
            /// Adding details about the total prices
            /// </summary>
            Phrase phPayment = new Phrase();
            var payment = new Paragraph();
            phPayment.Add(new Chunk("Moms%", standardfont));
            phPayment.Add(new Chunk(spacing));
            phPayment.Add(new Chunk("Moms", standardfont));
            phPayment.Add(new Chunk(spacing));
            phPayment.Add(new Chunk("Netto", standardfont));
            phPayment.Add(new Chunk(spacing));
            phPayment.Add(new Chunk("Värde", standardfont));
            payment.Add(phPayment);
            doc.Add(payment);

            Phrase phPrice12 = new Phrase();
            var price12 = new Paragraph();
            phPrice12.Add(new Chunk("12.00", standardfont));
            phPrice12.Add(new Chunk(spacing));
            phPrice12.Add(new Chunk(Math.Round((receiptVat12 * (1-1/1.12))).ToString(), standardfont));
            phPrice12.Add(new Chunk(spacing));
            phPrice12.Add(new Chunk(Math.Round((receiptVat12 * 1/1.12)).ToString(), standardfont));
            phPrice12.Add(new Chunk(spacing));
            phPrice12.Add(new Chunk(receiptVat12.ToString(), standardfont));
            price12.Add(phPrice12);
            doc.Add(price12);

            Phrase phPrice25 = new Phrase();
            var price25 = new Paragraph();
            phPrice25.Add(new Chunk("25.00", standardfont));
            phPrice25.Add(new Chunk(spacing));
            phPrice25.Add(new Chunk((receiptVat25 * 0.2).ToString(), standardfont));
            phPrice25.Add(new Chunk(spacing));
            phPrice25.Add(new Chunk((receiptVat25 * 0.8).ToString(), standardfont));
            phPrice25.Add(new Chunk(spacing));
            phPrice25.Add(new Chunk(receiptVat25.ToString(), standardfont));
            price25.Add(phPrice25);
            doc.Add(price25);

            /// <summary>
            /// Array with each line of text in the lower part of the receipt
            /// </summary>
            string[] stringArrayBot = new string[]
            {
                "       ",
                "Moms-reg nr:856548-5687",
                "Öppet: kl 11-21",
                "Välkommen åter!",
            };

            /// <summary>
            /// Array for the allignment of the lower text
            /// </summary>
            int[] intArrayBot = new int[] { 1, 1, 1, 1,};

            /// <summary>
            /// Loop for adding the lower information to the receipt
            /// </summary>
            for (int i = 0; i < stringArrayBot.Length; i++)
            {
                var paragraph = new Paragraph(stringArrayBot[i], standardfont);
                paragraph.Alignment = intArrayBot[i];
                doc.Add(paragraph);
            }

            /// <summary>
            /// Closes the document and the writer
            /// </summary>
            doc.Close();
            writer.Close();
        }
    }
}
