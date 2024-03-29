using Avalonia.Controls;
using System.Linq;
using System;
using System.IO;
using System.Windows;
using Avalonia.Media.Imaging;
using Avalonia.Skia.Helpers;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using Image = System.Drawing.Image;


namespace TovarV2
{
    public partial class AddTovar : Window
    {
       // public string path;
      //  public Avalonia.Media.Imaging.Bitmap bitmap { get; set; };
      public string path;
      public Bitmap bitmapToBind;
    //  public string file =
    public string fileContent;
        public AddTovar()
        {
            InitializeComponent();
           // ListPr.ListProd.Add(new Product());
        }

        private void AddTovarImg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
           // string path;
          //  var filePath = string.Empty;
          // fileContent = Content.ToString();
           OpenFileDialog _openFileDialog = new OpenFileDialog();
            _openFileDialog.ShowAsync(this);
            var result =  _openFileDialog.ShowAsync(this);
           if (_openFileDialog.ShowAsync(this).Result != null)
           {
             
               ListPr.ListProd.Add(new Product()
               {
                   Id=ListPr.b,
                   nameProd = nameTov.Text,
                   priceProd = Convert.ToInt32(priceTov.Text),
                   quantityProd = Convert.ToInt32(quantityTov.Text),
                   bitmap = new Bitmap(_openFileDialog.ShowAsync(this).Result.ToString()).ToString()
                   
               }); 
               bitmapToBind = new Bitmap(_openFileDialog.ShowAsync(this).Result.ToString());
           }
           

           //  var fileStream = _openFileDialog.ToString();
           // using (StreamReader reader = new StreamReader(fileStream))
           // {
           //     fileContent = reader.ReadToEnd();
           // }

           //  int ind = (int)((sender as Button)!).Tag!;
           // = 
           // 
           // imgTov.Source = new Bitmap(fileContent);

           //bitmap = openFileDialog.Directory;
           //   Bitmap? ImageFromBinding  = ImageS(new Uri("avares://LoadingImages/Assets/abstract.jpg"));

           //OpenFileDialog openFileDialog = new OpenFileDialog();
           //  openFileDialog.Filters.Add("Image files (*.jpg)|*.jpg","PNG files (*.png)|*.png");
        }


        private void AddTovarOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           
            errorMsg.Text = string.Empty;
            bool checkListProdContainsThisName = false;
            foreach (Product prod in ListPr.ListProd)
            {
                if (nameTov.Text == prod.nameProd)
                {
                    checkListProdContainsThisName = true;
                }
            }
            if (checkListProdContainsThisName)
            {
                errorMsg.Text = "Товар с таким именем уже имеется в каталоге";
            }
            else
            {
                ListPr.ListProd.Add(new Product()
                {
                    Id = ListPr.b,
                    nameProd = nameTov.Text,
                    priceProd = Convert.ToInt32(priceTov.Text),
                    quantityProd = Convert.ToInt32(quantityTov.Text)
                    //bitmap = new Bitmap(fileContent)
                });

                
               
                ListPr.b++;
                ProductEdit productEdit = new ProductEdit();
                productEdit.Show();
                this.Close();
            }
        }

    }
}

