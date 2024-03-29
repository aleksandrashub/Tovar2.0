using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace TovarV2;

public partial class EditTovar : Window
{
    public EditTovar()
    {
         InitializeComponent();
        nameTovar.Text = ListPr.ListProd[ListPr.productForEdit].nameProd;
        priceTovar.Text = ListPr.ListProd[ListPr.productForEdit].priceProd.ToString();
        quantityTovar.Text = ListPr.ListProd[ListPr.productForEdit].quantityProd.ToString();
    }
    private void EditOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ListPr.ListProd[ListPr.productForEdit].nameProd = nameTovar.Text;
        ListPr.ListProd[ListPr.productForEdit].quantityProd = Convert.ToInt32(quantityTovar.Text);
        ListPr.ListProd[ListPr.productForEdit].priceProd = Convert.ToInt32(priceTovar.Text);
        ProductEdit productEdit = new ProductEdit();
        productEdit.Show();
        this.Close();
    }
}