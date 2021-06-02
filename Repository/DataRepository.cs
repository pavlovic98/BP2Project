using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataRepository
    {
        private static DataRepository instance = null;
        private Model1Container data;

        private static object obj = new object();

        private DataRepository()
        {
            data = new Model1Container();
        }


        public static DataRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataRepository();
                }
                return instance;
            }
        }
        #region clubs 
        public List<BasketballClub> GetClubs()
        {
            return data.BasketballClubs.ToList();
        }

        public bool AddClub(BasketballClub club)
        {
            bool retVal = true;
            BasketballClub find = data.BasketballClubs.Where(item => item.Name == club.Name).FirstOrDefault();

            if (find == null)
            {
                data.BasketballClubs.Add(club);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditClub(BasketballClub club)
        {
            bool retVal = true;
            BasketballClub find = data.BasketballClubs.Where(item => item.Id == club.Id).FirstOrDefault();

            if (find != null)
            {
                find.Name = club.Name;
                find.SupperiorClub = find.SupperiorClub;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public BasketballClub GetClub(int id)
        {
            return data.BasketballClubs.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteCLub(int id)
        {
            var find = data.BasketballClubs.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.BasketballClubs.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion

        #region players
        public List<Player> GetPlayers()
        {
            return data.Players.ToList();
        }

        public bool AddPlayer(Player player)
        {
            bool retVal = true;
            Player find = null;

            if (find == null)
            {
                data.Players.Add(player);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public Player GetPlayer(int id)
        {
            return data.Players.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeletePlayer(int id)
        {
            var find = data.Players.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Players.Remove(find);
                data.SaveChanges();
            }
        }

        public bool EditPlayer(Player player)
        {
            bool retVal = true;
            Player find = data.Players.Where(item => item.Id == player.Id).FirstOrDefault();

            if (find != null)
            {
                find.FirstName = player.FirstName;
                find.LastName = player.LastName;
                find.Age = player.Age;
                find.Salary = player.Salary;
                find.BasketballClub = player.BasketballClub;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }
        #endregion

        #region positions
        public List<Position> GetPositions()
        {
            return data.Positions.ToList();
        }

        public bool AddPosition(Position position)
        {
            bool retVal = true;
            Position find = data.Positions.Where(item => item.Name.ToLower() == position.Name.ToLower()).FirstOrDefault();

            if (find == null)
            {
                data.Positions.Add(position);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditPosition(Position position)
        {
            bool retVal = true;
            Position find = data.Positions.Where(item => item.Id == position.Id).FirstOrDefault();

            if (find != null)
            {
                find.Name = position.Name;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public Position GetPosition(int id)
        {
            return data.Positions.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeletePosition(int id)
        {
            var find = data.Positions.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Positions.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion

        #region playerspositions
        public List<PlayerPosition> GetPlayerPositions()
        {
            return data.PlayerPositions.ToList();
        }

        public bool AddPlayerPosition(PlayerPosition position)
        {
            bool retVal = true;
            PlayerPosition find = data.PlayerPositions.Where(item => item.Player.Id == position.Player.Id && item.Position.Id == position.Position.Id).FirstOrDefault(); 
            if (find == null)
            {
                data.PlayerPositions.Add(position);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditPlayerPosition(PlayerPosition position)
        {
            bool retVal = true;
            PlayerPosition find = data.PlayerPositions.Where(item => item.Id == position.Id).FirstOrDefault();

            if (find != null)
            {
                find.Player = position.Player;
                find.Position = position.Position;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public PlayerPosition GetPlayerPosition(int id)
        {
            return data.PlayerPositions.Where(item => item.Id == id).FirstOrDefault();
        }


        public void DeletePlayerPosition(int id)
        {
            var find = data.PlayerPositions.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.PlayerPositions.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion

        #region leagues
        public List<League> GetLeagues()
        {
            return data.Leagues.ToList();
        }

        public bool AddLeague(League league)
        {
            bool retVal = true;
            PlayerPosition find = null;
            if (find == null)
            {
                data.Leagues.Add(league);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditLeague(League league)
        {
            bool retVal = true;
            League find = data.Leagues.Where(item => item.Id == league.Id).FirstOrDefault();

            if (find != null)
            {
                find.Name = league.Name;
                find.NumberOfClubs = league.NumberOfClubs;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public League GetLeague(int id)
        {
            return data.Leagues.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteLeague(int id)
        {
            var find = data.Leagues.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Leagues.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion

        #region licenses
        public List<License> GetLicenses()
        {
            return data.Licenses.ToList();
        }

        public bool AddLicense(License license)
        {
            bool retVal = true;
            License find = data.Licenses.Where(item => item.BasketballClubId == license.BasketballClub.Id && item.LeagueId == license.League.Id).FirstOrDefault(); 
            if (find == null)
            {
                data.Licenses.Add(license);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditLicense(License license)
        {
            bool retVal = true;
            License find = data.Licenses.Where(item => item.Id == license.Id).FirstOrDefault();

            if (find != null)
            {
                find.NameOfTeam = license.NameOfTeam;
                find.NameOfLeague = license.NameOfLeague;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public License GetLicense(int id)
        {
            return data.Licenses.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteLicense(int id)
        {
            var find = data.Licenses.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Licenses.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion

        #region clubleagues
        public List<ClubLeague> GetClubLeagues()
        {
            return data.ClubLeagues.ToList();
        }

        public bool AddClubLeague(ClubLeague cl)
        {
            bool retVal = true;
            ClubLeague find = data.ClubLeagues.Where(item => item.League.Id == cl.League.Id && item.BasketballClub.Id == cl.BasketballClub.Id).FirstOrDefault(); 
            if (find == null)
            {
                data.ClubLeagues.Add(cl);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditClubLeague(ClubLeague cl)
        {
            bool retVal = true;
            ClubLeague find = data.ClubLeagues.Where(item => item.Id == cl.Id).FirstOrDefault();

            if (find != null)
            {
                find.BasketballClub = cl.BasketballClub;
                find.League = cl.League;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public ClubLeague GetClubLeague(int id)
        {
            return data.ClubLeagues.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteClubLeague(int id)
        {
            var find = data.ClubLeagues.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.ClubLeagues.Remove(find);
                data.SaveChanges();

            }
        }
        #endregion

        #region facilities
        public List<Facility> GetFacilities()
        {
            return data.Facilities.ToList();
        }

        public bool AddFacility(Facility facility)
        {
            bool retVal = true;
            if(facility is Arena)
            {
                Arena a = (Arena)facility;
                data.Facilities.Add(a);
                data.SaveChanges();
            }
            else if(facility is MedicalCenter)
            {
                MedicalCenter mc = (MedicalCenter)facility;
                data.Facilities.Add(mc);
                data.SaveChanges();
            }
            else
            {
                Shop s = (Shop)facility;
                data.Facilities.Add(s);
                data.SaveChanges();
            }
           
            return retVal;
        }

        public bool EditFacility(Facility facility)
        {
            bool retVal = true;
            Facility find = data.Facilities.Where(item => item.Id == facility.Id).FirstOrDefault();

            if (find != null)
            {
                find.Name = facility.Name;
                find.Address = facility.Address;
                find.Type = facility.Type;
                find.BasketballClub = facility.BasketballClub;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public Facility GetFacility(int id)
        {
            return data.Facilities.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteFacility(int id)
        {
            var find = data.Facilities.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Facilities.Remove(find);
                data.SaveChanges();

            }
        }
        #endregion

        #region matches
        
        public List<Match> GetMatches()
        {
            return data.Matches.ToList();
        }

        public bool AddMatch(Match match)
        {
            bool retVal = true;
            data.Matches.Add(match);
            data.SaveChanges();
            
            return retVal;
        }

        public bool EditMatch(Match match)
        {
            bool retVal = true;
            Match find = data.Matches.Where(item => item.Id == match.Id).FirstOrDefault();

            if (find != null)
            {
                find.Arena = match.Arena;
                find.Date = match.Date;
                find.Guest = match.Guest;
                find.Host = match.Host;
                find.Result = match.Result;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public Match GetMatch(int id)
        {
            return data.Matches.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteMatch(int id)
        {
            var find = data.Matches.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Matches.Remove(find);
                data.SaveChanges();

            }
        }
        #endregion

        #region employees
        public List<Employee> GetEmployees()
        {
            return data.Employees.ToList();
        }

        public bool AddEmployee(Employee employee)
        {
            bool retVal = true;
            if (employee is Seller)
            {
                Seller s = (Seller)employee;
                data.Employees.Add(s);
                data.SaveChanges();
            }
            else if (employee is MedicalStaff)
            {
                MedicalStaff mc = (MedicalStaff)employee;
                data.Employees.Add(mc);
                data.SaveChanges();
            }
            else
            {
                Economist e = (Economist)employee;
                data.Employees.Add(e);
                data.SaveChanges();
            }

            return retVal;
        }

        public bool EditEmployee(Employee employee)
        {
            bool retVal = true;
            Employee find = data.Employees.Where(item => item.Id == employee.Id).FirstOrDefault();

            if (find != null)
            {
                employee.FirstName = employee.FirstName;
                employee.LastName = employee.LastName;
                employee.Salary = employee.Salary;
                employee.Type = employee.Type;
                employee.BasketballClub = employee.BasketballClub;
                if(employee is Seller)
                {
                    ((Seller)employee).Shop = ((Seller)employee).Shop;
                }
                else if(employee is Economist)
                {
                    ((Economist)employee).Arena = ((Economist)employee).Arena;
                }
                else
                {
                    ((MedicalStaff)employee).MedicalCenter = ((MedicalStaff)employee).MedicalCenter;
                }
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public Employee GetEmployee(int id)
        {
            return data.Employees.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeleteEmployee(int id)
        {
            var find = data.Employees.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.Employees.Remove(find);
                data.SaveChanges();

            }
        }
        #endregion

        #region playerCenters
        public List<PlayerCenter> GetPlayerCenters()
        {
            return data.PlayerCenters.ToList();
        }

        public bool AddPlayerCenter(PlayerCenter pc)
        {
            bool retVal = true;
            PlayerCenter find = data.PlayerCenters.Where(item => item.MedicalCenter.Id == pc.MedicalCenter.Id && item.Player.Id == pc.Player.Id).FirstOrDefault();
            if (find == null)
            {
                data.PlayerCenters.Add(pc);
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public bool EditPlayerCenter(PlayerCenter pc)
        {
            bool retVal = true;
            PlayerCenter find = data.PlayerCenters.Where(item => item.Id == pc.Id).FirstOrDefault();

            if (find != null)
            {
                find.Player = pc.Player;
                find.MedicalCenter = pc.MedicalCenter;
                data.SaveChanges();
            }
            else
            {
                retVal = false;
            }
            return retVal;

        }

        public PlayerCenter GetPlayerCenter(int id)
        {
            return data.PlayerCenters.Where(item => item.Id == id).FirstOrDefault();
        }

        public void DeletePlayerCenter(int id)
        {
            var find = data.PlayerCenters.Where(item => item.Id == id).FirstOrDefault();
            if (find != null)
            {
                data.PlayerCenters.Remove(find);
                data.SaveChanges();
            }
        }
        #endregion
    }
}
