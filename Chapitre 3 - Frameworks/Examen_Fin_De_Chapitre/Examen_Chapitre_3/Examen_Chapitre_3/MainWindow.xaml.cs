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

namespace Examen_Chapitre_3_A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int InputNumber { get; set; }
        string resultPrefix = "Résultat décrypté : "; // Initialise le préfixe ici
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessNumber(int number)
        {
            InputNumber = number; // Met à jour la propriété
            

            if (InputNumber < 10)
            {
                ResultDisplayText.Text = "Le nombre est inférieur à 10.";
            }
            while (InputNumber >= 10)
                if (InputNumber % 2 == 0) // Cas Pair
                {
                    InputNumber /= 2;
                }
                else // Cas Impair
                {
                    InputNumber = checked(InputNumber * 3 + 1);
                }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputNumberTextBox.Text; // Assurez-vous que la TextBox s'appelle bien InputNumberTextBox

            // Utiliser TryParse pour la sécurité
            if (int.TryParse(userInput, out int parsedNumber))
            {
                // Si la conversion réussit, traiter le nombre
                ProcessNumber(parsedNumber);
                ResultDisplayText.Text = resultPrefix + InputNumber.ToString();
            }
            else
            {
                // Si la conversion échoue, afficher un message d'erreur
                ResultDisplayText.Text = "Erreur : Veuillez entrer un nombre entier valide.";
            }
        }
    }
}
