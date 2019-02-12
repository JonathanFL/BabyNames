using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BabyNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BabyName> _babyNames = new List<BabyName>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1900; i < 2000; i+=10)
            {
                ListBoxItem decadeItem = new ListBoxItem();
                decadeItem.Content = i;
                DecadeListBox.Items.Add(decadeItem);
            }
        }

        private void BabyNameListBox_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                // ListBox item clicked - do some cool things here
                if (item.Content.Equals("2000"))
                {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = 
                }
            }
        }
    }
}

/*
 * try
            {
                using (var sr = new StreamReader("BabyNames.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var instans = new BabyName(line);
                        _babyNames.Add(instans);
                        //var item = new ListBoxItem();
                        //item.Content = line;
                        //ResultListBox.Items.Add(item);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                var item = new ListBoxItem
                {
                    Content = ex.Message
                };
                BabyNameListBox.Items.Add(item);
            }
 */
