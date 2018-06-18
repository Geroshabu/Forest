using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    public class FewMatchPriorityGenerator : Generator, IGameGenerator
    {
        protected override (List<Person> players, List<Person> breakPersons) DecideBreakPersons(int breakPersonsNumber, IReadOnlyList<Person> attendPersons)
        {
            //参加者のリストをコピーする
            var playerList = new List<Person>(attendPersons);
            var breakPersons = new List<Person>();

            //参加者の中からシステムを起動してからの参加回数が多い人を休憩者にする
            //参加回数が同じ人の公平さのため、まずリストをシャッフル
            //シャッフルした後に回数の多い順に並び替え
            playerList = ProcessList.Shuffle(playerList)
                .OrderByDescending(person => GameRecorder.GetTimes(person))
                .ToList();
            //試合の回数の多い人から順に休憩者にする
            //休憩者リストに入れる
            breakPersons.AddRange(playerList.Select(person => person).Take(breakPersonsNumber));
            //試合には参加できないのでリストから消す
            playerList.RemoveRange(0, breakPersonsNumber);

            return (players: playerList, breakPersons: breakPersons);

        }

        protected override (List<Person> remainPlayers, List<Person> team1, List<Person> team2) DecideOpponent(List<Person> players, int accommodateNumber)
        {
            //まずリストをシャッフル
            var playerList = ProcessList.Shuffle(players).ToList();

            //対戦相手を決める
            var team1 = new List<Person>();
            var team2 = new List<Person>();
            //まずは一人入れる
            var team1Person = playerList.First();
            team1.Add(team1Person);
            playerList.Remove(team1Person);
            //残りの参加者の中から一番対戦回数が少ない人を対戦相手に入れる
            var team2Person = playerList.OrderBy(person => GameRecorder.GetTimes(person, team1Person)).First();
            team2.Add(team2Person);
            playerList.Remove(team2Person);

            return (remainPlayers: playerList, team1: team1, team2: team2);
        }
    }
}
