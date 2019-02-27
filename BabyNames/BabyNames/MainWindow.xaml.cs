using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private string[,] _rankMatrix = new string[2001, 10];
        private List<BabyName> _babyNames = new List<BabyName>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1900; i <= 2000; i+=10)
                DecadeListBox.Items.Add(i);

            AddBabyNamesToArray();

            foreach (BabyName babyName in _babyNames)
            {
                for (int decade = 1900; decade <= 2000; decade += 10)
                {
                    int rank = babyName.Rank(decade);
                    int decadeIndex = decade;
                    if (0 < rank && rank <= 10)
                        if (_rankMatrix[decadeIndex, rank - 1] == null)
                        {
                            _rankMatrix[decadeIndex, rank - 1] = babyName.Name;
                        }
                        else
                        {
                            _rankMatrix[decadeIndex, rank - 1] += " and " + babyName.Name;
                        }
                }
            }
        }

        private void DecadeListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BabyNameListBox.Items.Clear();
            object selectedItem = DecadeListBox.SelectedItem;
            ListBoxItem selectedListBoxItem = DecadeListBox.ItemContainerGenerator.ContainerFromItem(selectedItem) as ListBoxItem;

            if (selectedListBoxItem != null)
            {
                int decade = Convert.ToInt32(selectedListBoxItem.Content);
                for (int i = 1; i < 11; ++i)
                {
                    BabyNameListBox.Items.Add($"{i,2} {_rankMatrix[decade, i - 1]}");
                }
            }
        }




        private void AddBabyNamesToArray()
        {
            try
            {
                using (var sr = new StreamReader("BabyNames.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        _babyNames.Add(new BabyName(line));
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
        }
        
        private void SearchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SearchListBox.Items.Clear();
            string searchedName = NameTextBox.Text;
            var found = false;
            foreach (var babyName in _babyNames)
            {
                if (babyName.Name.Equals(searchedName))
                {
                    found = true;
                    //TODO add Year and Rank to SearchListBox
                    for (int i = 1900; i <= 2000; i+=10)
                    {
                        SearchListBox.Items.Add($" {i}  {babyName.Rank(i), 11}");
                    }

                    RankTextBox.Text = babyName.AverageRank().ToString();

                    TrendTextBox.Text = babyName.Trend().ToString();
                }
            }
            if (!found)
            {
                    MessageBox.Show("Name does not exist in the statistic");
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SmallFont_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 8;
        }
        private void NormalFont_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 12;
        }

        private void LargeFont_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 18;
        }


        private void Huge_OnClick(object sender, RoutedEventArgs e)
        {
            FontSize = 36;
        }
    }
}
