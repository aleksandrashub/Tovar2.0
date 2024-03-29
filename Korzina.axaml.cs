using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Interactivity;

namespace TovarV2;

public partial class Korzina : Window
{
    public int b = 0;
    public int quantityCount = 0;
    public string codeUs;
    public ListBox quantitylistBox = new ListBox();
    public List<Product> products = new List<Product>();

    public Korzina()
    {
        InitializeComponent();
        A();
    }
    public void A()
    {
        ProdListInKorz.ItemsSource = ListPr.productSelects.Select(x => new
        {
            x.Id,
            x.nameProdKorz,
            x.priceProdKorz,
            x.quantityProdKorz,
            x.quantitySelect, //теперь тут стакпанел с кнопками +- по коливчеству и текстблоком с выводом количества
        }).ToList();
    }
    public void DelBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        ListPr.productSelects.RemoveAt(ind);
        if (ListPr.productSelects.Count > 0)
        {
            b = 0;
            foreach (ProductSelect prSel in ListPr.productSelects)
            {
                prSel.Id = b;
                b++;
            }
        }
        
        ProdListInKorz.ItemsSource = ListPr.productSelects.ToList();
    }

    public void ReturnProdEdit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ProductEdit productEdit = new ProductEdit();
        productEdit.Show();
        this.Close();
    }

    public void PodschetOrderBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool checkDataCorrect = true;
        int allprice = 0;
        int quantity;

        foreach (ProductSelect productSelect in ListPr.productSelects)
        {
          //  quantity = Convert.ToInt32(productSelect.quantitySelect);
            allprice += productSelect.priceProdKorz * productSelect.quantitySelect;
            
        }

       
        podschetstoimosti.Text = "Общая стоимость составляет: " + allprice.ToString() + " руб.";
        
    }


    public void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ListPr.SelectedListProd.Clear();
        ListPr.productSelects.Clear();
        MainWindow mainwindow = new MainWindow();
        mainwindow.Show();
        this.Close();
    }

    private void UvelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
       // quantityCount++;
       // int ind = (int)((sender as Button)!).Tag!;
       int ind = (int)((sender as Button)!).Tag!;
      // ProdListInKorz.Items.
      ListPr.productSelects[ind].quantitySelect++;
      ListPr.productSelects[ind].quantitySelect = CheckQuantity(ListPr.productSelects[ind].quantitySelect,
          ListPr.productSelects[ind].quantityProdKorz);
      
      //  ProdListInKorz.ItemsSource = ListPr.productSelects.ToList();
      // ListPr.productSelects[ind].quantitySelect.Children.T
      /*int i = 0;
      foreach (ProductSelect prSel in ListPr.productSelects)
      {
          prSel.Id = i;
          i++;
      }*/
      ProdListInKorz.ItemsSource = ListPr.productSelects.ToList();
    }
    private void UmenBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        ListPr.productSelects[ind].quantitySelect--;
        ListPr.productSelects[ind].quantitySelect = CheckQuantity(ListPr.productSelects[ind].quantitySelect,
            ListPr.productSelects[ind].quantityProdKorz);
        /*int i = 0;
        foreach (ProductSelect prSel in ListPr.productSelects)
        {
            prSel.Id = i;
            i++;
        }*/
        ProdListInKorz.ItemsSource = ListPr.productSelects.ToList();
    }
    private int CheckQuantity(int quantitySel, int quantityMagaz)
    {
        bool check = true;
        if (quantitySel < 1)
        {
            quantitySel = 1;
        }
        else if (quantitySel > quantityMagaz)
        {
            quantitySel = quantityMagaz;
            podschetstoimosti.Text = "Ошибка. Введенное количество товара больше имеющегося в магазине";
        }
        else
        {
            podschetstoimosti.Text = "";
        }
        return quantitySel;
    }

}