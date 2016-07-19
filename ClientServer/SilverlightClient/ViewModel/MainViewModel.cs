using System.Collections.Generic;
using ClientServer.Common;
using GalaSoft.MvvmLight;
using SilverlightClient.Services;

namespace SilverlightClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Privates

        private List<Manufacturer> _manufacturers;
        private Manufacturer _selectedManufacturer;
        private List<Model> _models;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            DataService.GetManufacturers(ManufacturersDownloadHandler);
        }

        #endregion

        #region Properties

        public List<Manufacturer> Manufacturers
        {
            get
            {
                return _manufacturers;
            }
            set
            {
                Set(() => Manufacturers, ref _manufacturers, value);              
            }
        }

        public List<Model> Models
        {
            get { return _models; }
            set { Set(() => Models, ref _models, value); }
        }

        public Manufacturer SelectedManufacturer
        {
            get { return _selectedManufacturer; }
            set
            {
                Set(() => SelectedManufacturer, ref _selectedManufacturer, value);

                if (value != null)
                    DataService.GetModels(ModelsDownloadHandler, SelectedManufacturer.Id);
            }
        }

        #endregion

        #region Methods

        private void ManufacturersDownloadHandler(List<Manufacturer> manufacturers)
        {
            Manufacturers = manufacturers;
        }

        private void ModelsDownloadHandler(List<Model> models)
        {
            Models = models;
        }

        #endregion
    }
}
