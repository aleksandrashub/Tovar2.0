using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Layout;

namespace TovarV2
{
    public class ProductSelect
    {
        
        public int Id { get; set; } 
        public string nameProdKorz { get; set; }
        public int priceProdKorz { get; set; }
        public int quantityProdKorz { get; set; }

        public int quantitySelect { get; set; }

      /*  public ProductSelect()
        {
            Button plusBtn = new Button();
            plusBtn.Width = 30;
            Button minusBtn = new Button();
            minusBtn.Width = 30;
            TextBlock quantity = new TextBlock();
            quantity.Width = 30;
            quantitySelect.Orientation = Orientation.Horizontal;
            quantitySelect.Children.Add(minusBtn);
            quantitySelect.Children.Add(quantity);
            quantitySelect.Children.Add(plusBtn);
            
        }*/
    }
}
