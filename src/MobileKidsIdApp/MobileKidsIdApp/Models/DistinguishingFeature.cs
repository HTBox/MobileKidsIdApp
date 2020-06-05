namespace MobileKidsIdApp.Models
{
    public class DistinguishingFeature : NotifyPropertyChanged
    {
        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public FileReference FileReference { get; set; }
    }
}
