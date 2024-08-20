using System;
using Avalonia.Controls;

namespace TekoEditor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Console.Write(this.Find<ComboBox>("TypeSelect")!.SelectedIndex);
    }
}