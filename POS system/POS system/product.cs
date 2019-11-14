using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_system
{
    [Serializable]

    public class product
    {
        /// <summary>
        /// Global variable for item and price
        /// </summary>
        string localItem;
        int localPrice;
        int localVat;
        int localColorRed;
        int localColorGreen;
        int localColorBlue;
        string category;

        /// <summary>
        /// Constructor
        /// </summary>
        public product(string item, int price, int vat, int colorRed, int colorGreen, int colorBlue, string category)
        {
            this.localItem = item;
            this.localPrice = price;
            this.localVat = vat;
            this.localColorRed = colorRed;
            this.localColorGreen = colorGreen;
            this.localColorBlue = colorBlue;
            this.category = category;

        }

        /// <summary>
        /// Gets and sets the Item
        /// </summary>
        public string Item
        {
            get
            {
                return localItem;
            }
            set
            {
                localItem = value;
            }
        }

        /// <summary>
        /// Gets and sets the Price
        /// </summary>
        public int Price
        {
            get
            {
                return localPrice;
            }
            set
            {
                localPrice = value;
            }
        }

        /// <summary>
        /// Gets and sets LocalVat
        /// </summary>
        public int Vat
        {
            get
            {
                return localVat;
            }
            set
            {
                localVat = value;
            }
        }

        /// <summary>
        /// Gets and sets localColorRed
        /// </summary>
        public int ColorRed
        {
            get
            {
                return localColorRed;
            }
            set
            {
                localColorRed = value;
            }
        }

        /// <summary>
        /// Gets and sets localColorGreen
        /// </summary>
        public int ColorGreen
        {
            get
            {
                return localColorGreen;
            }
            set
            {
                localColorGreen = value;
            }
        }
        /// <summary>
        /// Gets and sets localColorBlue
        /// </summary>
        public int ColorBlue
        {
            get
            {
                return localColorBlue;
            }
            set
            {
                localColorBlue = value;
            }
        }

        /// <summary>
        /// Gets and sets Category
        /// </summary>
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        /// <summary>
        /// Merge and calcutes space between
        /// </summary>
        public string ToReceipt()
        {
            int totalLength = 27;
            if (Price >= 10)
            {
                totalLength = totalLength - Item.Length;
                totalLength = totalLength - 4;
                string spacing = new string(' ', totalLength);
                return Item + spacing + Price;
            }

            else
            {
                totalLength = totalLength - Item.Length;
                totalLength = totalLength - 3;
                string spacing = new string(' ', totalLength);
                return Item + spacing + Price;
            }

        }
    }
}
