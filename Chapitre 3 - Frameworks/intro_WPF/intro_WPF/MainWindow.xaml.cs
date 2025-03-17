using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace intro_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            textBox.Text = string.Empty;
        }
    }

    private void BoutonPlus_Click(object sender, RoutedEventArgs e)
    {
        NombreIncremente.Text = (int.Parse(NombreIncremente.Text) + 1).ToString();
    }

    private void BoutonMoins_Click(object sender, RoutedEventArgs e)
    {
        NombreIncremente.Text = (int.Parse(NombreIncremente.Text) - 1).ToString();
    }

    private void Addition_Click(object sender, RoutedEventArgs e)
    {
        OperationResult.Text = (int.Parse(FirstNumber.Text) + int.Parse(SecondNumber.Text)).ToString();
    }

    private void Substraction_Click(object sender, RoutedEventArgs e)
    {
        OperationResult.Text = (int.Parse(FirstNumber.Text) - int.Parse(SecondNumber.Text)).ToString();

    }

    private void Multiplication_Click(object sender, RoutedEventArgs e)
    {
        OperationResult.Text = (int.Parse(FirstNumber.Text) * int.Parse(SecondNumber.Text)).ToString();

    }

    private void Division_Click(object sender, RoutedEventArgs e)
    {
        OperationResult.Text = (int.Parse(FirstNumber.Text) / int.Parse(SecondNumber.Text)).ToString();

    }

    private void RandomizerButton_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        int firstRandomNumber = int.Parse(FirstRandomNumber.Text);
        int secondRandomNumber = int.Parse(SecondRandomNumber.Text);
        RandomResult.Text = random.Next(firstRandomNumber, secondRandomNumber).ToString();
    }
}