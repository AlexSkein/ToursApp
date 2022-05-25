using System;
using System.Windows;
using System.IO;
using ToursApp.DBModel;
using System.Linq;



namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new HotelPage());
            ImportTours();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Zver\source\repos\ToursApp\ToursApp\import\tours.txt");
            var images = Directory.GetFiles(@"C:\Users\Zver\source\repos\ToursApp\ToursApp\import\hotelImages");

            foreach(var line in fileData)
            {
                var data = line.Split('\t');

                var tempTour = new Tour
                {
                    Name = data[0],
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };

                foreach (var TourType in data[5].Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = ToursBaseEntities.GetContext().Type.ToList().FirstOrDefault(p => p.Name == TourType);
                    if (currentType != null) tempTour.Type.Add(currentType);
                }

                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Name)));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                ToursBaseEntities.GetContext().Tour.Add(tempTour);
                ToursBaseEntities.GetContext().SaveChanges();
            }
        
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            } 
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
