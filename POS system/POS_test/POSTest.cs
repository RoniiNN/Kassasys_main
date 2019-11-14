using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using POS_system;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using TestStack;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowStripControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace POS_test
{
    [TestClass]
    public class PosTest
    {
        [TestMethod]
        public void Tests()
        {
            /// <summary>
            /// Setup
            /// </summary>
            Application test = Application.Launch("POS system.exe");
            Window window = test.GetWindow("Point of Sale System");

            /// <summary>
            /// Click dessert category button
            /// </summary>
            Button dessert = window.Get<Button>("Efterrätter");
            dessert.Click();

            /// <summary>
            /// Click rapberrypavlova button
            /// </summary>
            Button raspberrypavlova = window.Get<Button>("Hallonpavlova");
            raspberrypavlova.Click();

            /// <summary>
            /// Click the homepage button
            /// </summary>
            Button homepage = window.Get<Button>("home");
            homepage.Click();

            /// <summary>
            /// Click coffee/te category button
            /// </summary>
            Button coffeeCat = window.Get<Button>("Kaffe/Te");
            coffeeCat.Click();

            /// <summary>
            /// Click coffe product button
            /// </summary>
            Button coffeePro = window.Get<Button>("Kaffe");
            coffeePro.Click();

            homepage.Click();

            /// <summary>
            /// Click pizza category
            /// </summary>
            Button pizza = window.Get<Button>("Pizza");
            pizza.Click();

            /// <summary>
            /// Click vesuvio button
            /// </summary>
            Button vesuvio = window.Get<Button>("Vesuvio");
            vesuvio.Click();
            homepage.Click();

            /// <summary>
            /// Click wine category
            /// </summary>
            Button wine = window.Get<Button>("Viner");
            wine.Click();

            /// <summary>
            /// Click I Castei Ripasso button
            /// </summary>
            Button wineProduct = window.Get<Button>("I Castei Ripasso");
            wineProduct.Click();
            homepage.Click();

            /// <summary>
            /// Check total price
            /// </summary>
            Label totalPrice = window.Get<Label>("price");
            if (!totalPrice.Name.Contains("752kr"))
            {
                throw new Exception("Innehåller inte 752kr?");
            }

            /// <summary>
            /// Deletes the folder and then creates it again
            /// </summary>
            Directory.Delete("../../../receipt", true);
            System.Threading.Thread.Sleep(2000);
            Directory.CreateDirectory("../../../receipt");

            /// <summary>
            /// These two variables have diffrent uses 
            /// </summary>
            string time = DateTime.Now.ToString(" yyyy MM_dd HHmm ss");
            string time2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Button paymentCash = window.Get<Button>("PaymentCard");
            paymentCash.Click();

            /// <summary>
            /// Test receipt pdf
            /// </summary>
            string path = "../../../receipt/receipt" + time + ".pdf";
            PdfReader reader = new PdfReader(path);

            /// <summary>
            /// puts pdf file in contentText
            /// </summary>
            string contentText = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                contentText += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();

            /// <summary>
            /// Array for keeping the dynamic information 
            /// </summary>
            string[] testArray = {
                "Hallonpavlova 110 kr",
                "Kaffe 32 kr",
                "Vesuvio 90 kr",
                "I Castei Ripasso 520 kr",
                time2.ToString()
            };

            /// <summary>
            /// Checks if receipt contains the important dynamic information 
            /// </summary>
            for (int i = 0 ; i < testArray.Length; i++)
            {
                if (!contentText.Contains(testArray[i]))
                {                
                    throw new Exception("Kvitto stämmer ej");
                }
            }

            /// <summary>
            /// Exit test
            /// </summary>
            test.Kill();
            
            
            
        }
    }
}
