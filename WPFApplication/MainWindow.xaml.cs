
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperation;
        public MainWindow()
        {
            
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += Button_Click_1;
            percentageButton.Click += PercentageButton_Click;
            //equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperation)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void OperationButton_Click(Object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out this.lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == multiplicationButton)
                selectedOperation = SelectedOperator.Multiplication;
            if (sender == negativeButton)
                selectedOperation = SelectedOperator.Sustraction;
            if(sender == divisionButton)
                selectedOperation = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperation = SelectedOperator.Addition;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out this.lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }
    }
    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        public static double Sustraction(double value1, double value2)
        {
            return value1 - value2;
        }
        public static double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }
        public static double Divide(double value1, double value2)
        {
            if(value2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported.","Wrong operation",MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return value1 / value2;

        }
    }
}
