using System.Collections.ObjectModel;

namespace WPFChartLabelEvents
{
    public class ViewModel
    {
        public ObservableCollection<Model> DataSource { get; set; }

        public ViewModel()
        {
            DataSource = new ObservableCollection<Model>
            {
                new Model { Company = "Apple", Revenue = 382 },
                new Model { Company = "Microsoft", Revenue = 237 },
                new Model { Company = "Amazon", Revenue = 591 },
                new Model { Company = "Alphabet", Revenue = 318 },
                new Model { Company = "Nvidia", Revenue = 200 },
                new Model { Company = "Meta", Revenue = 143 },
                new Model { Company = "Samsung", Revenue = 201 }
            };
        }
    }
}
