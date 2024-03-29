using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using System;
using Avalonia.Layout;

namespace TovarV2;

public partial class ProductEdit : Window
{
    public string codeUs;
    public TextBlock textblock = new TextBlock();
    public TextBox textbox = new TextBox();
    public TextBox textbox2 = new TextBox();
    public TextBox textbox3 = new TextBox();
    public Button btnInsertOk = new Button();
    public ListBox list = new ListBox();
    public int a = 0;

    public ProductEdit()
    {
        InitializeComponent();
        ProdList.SelectionMode = SelectionMode.Single;
        ProdList.ItemsSource = ListPr.ListProd.ToList();
        switch (ListPr.codeUser)
        {
            case 1:
                EditTovarBtn.IsVisible = false;
                AddElementBtn.IsVisible = false;
                Grid.SetColumn(GoToKorzinaBtn, 0);
                Grid.SetRow(GoToKorzinaBtn, 2);
                GoToKorzinaBtn.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
                break;
            case 0:
                EditTovarBtn.IsVisible=true;
                AddElementBtn.IsVisible = true;
                Grid.SetColumn(GoToKorzinaBtn, 1);
                Grid.SetRow(GoToKorzinaBtn, 2);
                GoToKorzinaBtn.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
                break;

        }
    }
   
    public void BtnInsert_OnClick(object? sender, RoutedEventArgs e)
    {
       /* textblock.IsVisible = true;
        textbox.IsVisible = true;
        textbox2.IsVisible = true;
        textbox3.IsVisible = true;
        btnInsertOk.IsVisible = true;*/
       AddTovar addTovar = new AddTovar();
        addTovar.Show();
        this.Close();
    }
    public void BtnEditTovar_OnClick(object? sender, RoutedEventArgs e)
    {
        ListPr.productForEdit = ListPr.ListProd.IndexOf(ProdList.SelectedItem as Product);
        bool checkKorzContainsItem = false;
        foreach (ProductSelect productSelect in ListPr.productSelects)
        {
            if (productSelect.nameProdKorz == ListPr.ListProd[ListPr.productForEdit].nameProd)
            {
                checkKorzContainsItem = true;
                break;
            }
        }
        if (checkKorzContainsItem == true)
        {
            TextBlock errorMsg = new TextBlock();
            errorMsg.Text = "Уберите сначала товар из корзины";
            editing.Children.Add(errorMsg);
        }
        else
        {
            EditTovar editTovar = new EditTovar();
            editTovar.Show();
            this.Close();
        }
    }

    public void AddToKorzBtn_OnClick(object? sender, RoutedEventArgs e)
    {
      //  a = 0;
        bool checkRepeat = true;

        int ind = (int)((sender as Button)!).Tag!;

        for (int i = 0; i < ListPr.productSelects.Count; i++)
        {
            if (ListPr.ListProd[ind].nameProd == ListPr.productSelects[i].nameProdKorz)
            {
                checkRepeat = false;
                break;
            }
        }

        
        if (checkRepeat)
        {
            if (ListPr.productSelects.Count > 0)
            {
                ListPr.productSelects.Add(
                    new ProductSelect()
                    {
                        Id = a,
                        nameProdKorz = ListPr.ListProd[ind].nameProd,
                        priceProdKorz = ListPr.ListProd[ind].priceProd,
                        quantityProdKorz = ListPr.ListProd[ind].quantityProd,
                        quantitySelect = 1,
                    });
                a = 0;
                foreach (ProductSelect prSel in ListPr.productSelects)
                {
                    prSel.Id = a;
                    a++;
                }
                
            }
            else
            {
                ListPr.productSelects.Add(
                    new ProductSelect()
                    {
                        Id = a,
                        nameProdKorz = ListPr.ListProd[ind].nameProd,
                        priceProdKorz = ListPr.ListProd[ind].priceProd,
                        quantityProdKorz = ListPr.ListProd[ind].quantityProd,
                        quantitySelect = 1,
                    });
            }
               
               
                /*foreach (ProductSelect pr in ListPr.productSelects)
                {
                    Button plusBtn = new Button();
                    plusBtn.Width = 30;
                    Button minusBtn = new Button();
                    minusBtn.Width = 30;
                    TextBlock quantity = new TextBlock();
                    quantity.Width = 30;
                    pr.quantitySelect.Orientation = Orientation.Horizontal;
                    pr.quantitySelect.Children.Add(minusBtn);
                    pr.quantitySelect.Children.Add(quantity);
                    pr.quantitySelect.Children.Add(plusBtn);
                }*/
                a++;
        }
    }


   
        public void BtnKorzina_OnClick(object? sender, RoutedEventArgs e)
    {
        List<Product> prods = new List<Product>();
        prods = ProdList.SelectedItems.Cast<Product>().ToList();
        List<int> repeats = new List<int>();

       /*
        int a = 0;

        foreach (Product prod in prods)
        {
            ListPr.productSelects.Add(
                new ProductSelect()
                {
                    Id = a,
                    nameProdKorz = prod.nameProd,
                    priceProdKorz = prod.priceProd,
                    quantityProdKorz = prod.quantityProd,
                    selectQuantityProdKorz = new TextBox(),
                }
            );
            a++;
        }
        ListPr.SelectedListProd.AddRange(ProdList.SelectedItems.Cast<Product>().ToList());
      */
       /* for (int j = 0; j < ListPr.productSelects.Count; j++)
        {
            for (int i = j+1 ; i < ListPr.productSelects.Count; i++)
            {
                if (ListPr.productSelects[i].nameProdKorz == ListPr.productSelects[j].nameProdKorz)
                {
                    repeats.Add(i);
                }
            }
        }
        for (int j = 0; j<repeats.Count; j++)
        {
            for (int i = j+1; i < repeats.Count; i++)
            {
                if (repeats[i] == repeats[j])
                { 
                    repeats.RemoveAt(i);
                }
            }
        }


        foreach (int rep in repeats)
        {
            ListPr.productSelects.RemoveAt(rep);
        }

        repeats.Clear();

*/
        Korzina korzinanew = new Korzina();
        korzinanew.Show();
        Close();

    }
    public void BtnVyhod_OnClick(object? sender, RoutedEventArgs e)
    {
        ListPr.SelectedListProd.Clear();
        ListPr.productSelects.Clear();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

}