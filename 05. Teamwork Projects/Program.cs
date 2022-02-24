using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{

    class Team
    {
        public Team()
        {
            this.Members = new List<string>();
        }
        public string Leader { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int countOfTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] team = Console.ReadLine().Split("-",StringSplitOptions.RemoveEmptyEntries);
                Team team1 = new Team { Leader = team[0], Name = team[1] };
                if (IsTeamExist(teams, team1.Name))
                {   
                    Console.WriteLine($"Team {team1.Name} was already created!");
                    continue;
                }
                if (IsLeaderExist(teams,team1.Leader))
                {
                    Console.WriteLine($"{team1.Leader} cannot create another team!");
                    continue;
                }
                teams.Add(team1);
                Console.WriteLine($"Team {team1.Name} has been created by {team1.Leader}!");
            }
            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] cmd = command.Split("->",StringSplitOptions.RemoveEmptyEntries);
                string player = cmd[0];
                string team = cmd[1];
                
                if (!IsTeamExist(teams,team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }
                
                if (isMemberExist(teams,player))
                {
                    Console.WriteLine($"Member {player} cannot join team {team}!");
                    continue;
                }
                    int temp = teams.FindIndex(t => t.Name == team);
                    if (temp != -1)
                    {
                    teams[temp].Members.Add(player);
                    }
            }
            List<Team> passed = new List<Team>();
            List<Team> disbanded = new List<Team>();
            foreach (Team team in teams)
            {
                if (team.Members.Count > 0)
                {
                    passed.Add(team);
                }
                if (team.Members.Count == 0)
                {
                    disbanded.Add(team);
                }
            }
            List<Team> passedOrdered = passed.OrderByDescending(team => team.Members.Count).ThenBy(team=>team.Name).ToList();
            foreach (Team passedTeam in passedOrdered)
            {
                Console.WriteLine($"{passedTeam.Name}");
                Console.WriteLine($"- {passedTeam.Leader}");
                passedTeam.Members.Sort();
                foreach (string member in passedTeam.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            List<Team> disbandOrdered = disbanded.OrderBy(team => team.Name).ToList();
            foreach (Team disbandedTeam in disbandOrdered)
            {
                Console.WriteLine(disbandedTeam.Name);
            }
        }
        static bool IsTeamExist(List<Team> teams, string name)
        {
            foreach (Team team in teams)
            {
                if (team.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsLeaderExist(List<Team> teams, string leader)
        {
            foreach (Team team in teams)
            {
                if (team.Leader == leader)
                {
                    return true;
                }
            }
            return false;
        }
        static bool isMemberExist(List<Team> teams, string newMember)
        {
            foreach (Team team in teams)
            {
                if (team.Leader == newMember)
                {
                    return true;
                }
                foreach (string member in team.Members)
                {
                    if (member == newMember)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
