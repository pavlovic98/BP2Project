using Baze_projekat.ViewModels;
using NetworkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze_projekat
{
    public class MainWIndowViewModel : BindableBase
    {
        private ClubsViewModel clubsViewModel;
        private PlayersViewModel playersViewModel;
        private PositionsViewModel positionsViewModel;
        private PlayersPositionsViewModel playersPositionsViewModel;
        private LeagueViewModel leagueViewModel;
        private LicenseViewModel licenseViewModel;
        private ClubLeagueViewModel clubLeagueViewModel;
        private FacilityViewModel facilityViewModel;
        private MatchsVIewModel matchsVIewModel;
        private EmployeesVIewModel employeesVIewModel;
        private PlayerCentarViewModel playerCentarViewModel;
        public MyICommand<string> NavCommand { get; private set; }

        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public MainWIndowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            clubsViewModel = new ClubsViewModel();
            playersViewModel = new PlayersViewModel();
            positionsViewModel = new PositionsViewModel();
            playersPositionsViewModel = new PlayersPositionsViewModel();
            leagueViewModel = new LeagueViewModel();
            licenseViewModel = new LicenseViewModel();
            clubLeagueViewModel = new ClubLeagueViewModel();
            facilityViewModel = new FacilityViewModel();
            matchsVIewModel = new MatchsVIewModel();
            employeesVIewModel = new EmployeesVIewModel();
            playerCentarViewModel = new PlayerCentarViewModel();
            CurrentViewModel = clubsViewModel;
        }

        private void OnNav(string arg)
        {
            if(arg == "clubs")
            {
                CurrentViewModel = clubsViewModel;
            }
            else if(arg == "players")
            {
                CurrentViewModel = playersViewModel;
            }
            else if(arg == "positions")
            {
                CurrentViewModel = positionsViewModel;
            }
            else if(arg == "playerposition")
            {
                CurrentViewModel = playersPositionsViewModel;
            }
            else if(arg == "leagues")
            {
                CurrentViewModel = leagueViewModel;
            }
            else if(arg == "licenses")
            {
                CurrentViewModel = licenseViewModel;
            }
            else if(arg == "clubleagues")
            {
                CurrentViewModel = clubLeagueViewModel;
            }
            else if(arg == "facilities")
            {
                CurrentViewModel = facilityViewModel;
            }
            else if(arg == "matches")
            {
                CurrentViewModel = matchsVIewModel;
            }
            else if(arg == "employees")
            {
                CurrentViewModel = employeesVIewModel;
            }
            else if(arg == "pc")
            {
                CurrentViewModel = playerCentarViewModel;
            }
        }
    }
}
