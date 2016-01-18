using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp.Scripting.UIChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals globals = new Globals();
            globals.Panel = stackPanel;
            globals.Panel.Children.Add(new Button() { Content = "Hoo" });
            var options = ScriptOptions.Default.WithReferences(typeof(Button).Assembly);

            CSharpScript.RunAsync("Panel.Children.Add(new System.Windows.Controls.Button() { Content = \"Hoo\" });", options: options, globals: globals, globalsType: typeof(Globals));
        }
    }

    public class Globals
    {
        public StackPanel Panel { get; set; }
    }
}
