using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    public CalculatorScreen()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Button b = sender as Button;
        string s = b.Content.ToString();
        string ResultContent = this.Result.Content.ToString();
        if (ResultContent.Length==0 || ResultContent=="Please enter an operation" || ResultContent=="Only one operation please")
        {
            this.Result.Content = s;
        }
        else if(ResultContent[0]!='P' && ResultContent[0]!='O')
        {
            this.Result.Content += s;
        }
        
    }

    private void ButtonEqual_OnClick(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        this.Result.Content = c.Operator(this.OperationLabel.Content.ToString());
    }

    private void CButton_OnClick(object? sender, RoutedEventArgs e)
    {
        this.OperationLabel.Content = "";
        this.Result.Content = "";
    }

    private void ButtonSign_OnClick(object? sender, RoutedEventArgs e)
    {
        string ResultContent = this.Result.Content.ToString();
        if (ResultContent.Length==0)
        {
            this.Result.Content="Please enter an operation";
        }
        else if(ResultContent[0]!='P' && ResultContent[0]!='O')
        {
            Button b = sender as Button;
            string s = b.Content.ToString();
            this.OperationLabel.Content += ResultContent + s;
            this.Result.Content = "";
        }
    }

    private void EqualButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        this.Result.Content = c.Operator(this.OperationLabel.Content.ToString()+this.Result.Content.ToString());
        this.OperationLabel.Content = "";
    }

    private void DelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        string ResultContent = this.Result.Content.ToString();
        if (ResultContent.Length != 0)
        {
            this.Result.Content = ResultContent
                .Substring(0, ResultContent.Length - 1);
            
        }
    }

    private void CeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = "";
    }

    private void Sign_OnClick(object? sender, RoutedEventArgs e)
    {
        string OperationContent = this.OperationLabel.Content.ToString();
        if (OperationContent.Length == 0 || OperationContent[0]=='P' || OperationContent[0]=='O')
        {
            this.Result.Content="Please enter an operation";
        }
        else if (OperationContent[0] == '-')
        {
            this.OperationLabel.Content = OperationContent.Substring(1);
        }
        else if(OperationContent.Length>0)
        {
            this.OperationLabel.Content = "-" + OperationContent;
        }
    }

    private void Square_OnClick(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        this.Result.Content = c.Square(this.Result.Content.ToString());
    }

    private void Sqrt_OnClick(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        this.Result.Content = c.Sqrt(this.Result.Content.ToString());
    }

    private void Invert_OnClick(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        this.Result.Content = c.Invert(this.Result.Content.ToString());
    }
}