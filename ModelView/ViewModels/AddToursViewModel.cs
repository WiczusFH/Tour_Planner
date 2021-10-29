using System;
using log4net;
using Model;
using System.ComponentModel;
using System.Text;

namespace ViewModel
{
    public class AddToursViewModel : Observable
    {
        #region Singleton
        public NotifyUser notifyUser = new NotifyUser();

        private static AddToursViewModel _address = new AddToursViewModel();
        public static AddToursViewModel address { get { return _address; } }

        private log4net.ILog log;

        #endregion

        #region Inputs
        string _inputName;
        public string inputName { get { return _inputName; } set { _inputName = value; AddTourCommand.RaiseCanExecuteChanged(); } }
        public string inputDescription { get; set; }
        public string inputInformation { get; set; }
        public float inputDistance { get; set; }
        string _inputStartLocation;
        public string inputStartLocation { get { return _inputStartLocation; } set { _inputStartLocation = value; SearchAddressCommand.RaiseCanExecuteChanged(); AddTourCommand.RaiseCanExecuteChanged(); } }
        string _inputEndLocation;
        public string inputEndLocation { get { return _inputEndLocation; } set { _inputEndLocation = value; SearchAddressCommand.RaiseCanExecuteChanged(); AddTourCommand.RaiseCanExecuteChanged(); } }
        public RelayCommand AddTourCommand { get; }
        public RelayCommand SearchAddressCommand { get; }
        Repository repository = Repository.address;
        #endregion

        #region Constructor
        public AddToursViewModel() 
        {
            log = LogManager.GetLogger(GetType());
            log.Info("Tours View Model instantiated. ");
            AddTourCommand = new RelayCommand(addTour, addTourPredicate);
            SearchAddressCommand = new RelayCommand(searchTour, searchTourPredicate);

        }
        #endregion

        #region Predicates
        bool searchTourPredicate(object obj)
        {
            log.Info("Using SearchTourPredicate. ");

            if (string.IsNullOrEmpty(inputEndLocation) && string.IsNullOrEmpty(inputStartLocation)) { return false; }
            return true;
        }
        bool addTourPredicate(object obj)
        {
            log.Info("Using AddTourPredicate. ");

            if (string.IsNullOrEmpty(inputName)) { return false; }
            if (string.IsNullOrEmpty(inputStartLocation)) { return false; }
            if (string.IsNullOrEmpty(inputEndLocation)) { return false; }
            return true;
        }
        #endregion

        #region Button Actions
        public void searchTour()
        {
            if (!String.IsNullOrEmpty(inputStartLocation) && !String.IsNullOrEmpty(inputEndLocation))
            {
                string[] locations = { inputStartLocation, inputEndLocation };
                repository.updateMap(inputStartLocation, inputEndLocation );
            }
            if (!String.IsNullOrEmpty(inputStartLocation) && String.IsNullOrEmpty(inputEndLocation))
            {
                string[] locations = { inputStartLocation, inputStartLocation };
                repository.updateMap(inputStartLocation, inputStartLocation);
            }
            if (String.IsNullOrEmpty(inputStartLocation) && !String.IsNullOrEmpty(inputEndLocation))
            {
                string[] locations = { inputEndLocation, inputEndLocation };
                repository.updateMap(inputEndLocation, inputEndLocation);
            }
        }
        public void addTour()
        {
            repository.addTour(inputName,inputDescription,inputInformation,inputStartLocation,inputEndLocation);
        }
        #endregion
    }
}
