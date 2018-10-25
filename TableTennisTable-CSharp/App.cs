﻿using System;

namespace TableTennisTable_CSharp
{
    public class App
    {
        private League _league;
        private ILeagueRenderer _leagueRenderer;
        private IFileService _fileService;

        public App(League initialLeague, ILeagueRenderer leagueRenderer, IFileService fileService)
        {
            _league = initialLeague;
            _leagueRenderer = leagueRenderer;
            _fileService = fileService;
        }

        public string SendCommand(string command)
        {
            try
            {
                if (command.StartsWith("add player"))
                {
                    string player = command.Substring(11);
                    _league.AddPlayer(player);
                    return $"Added player {player}";
                }

                if (command.StartsWith("record win"))
                {
                    string playersString = command.Substring(11);
                    var players = playersString.Split(' ');
                    string winner = players[0];
                    string loser = players[1];
                    _league.RecordWin(winner, loser);
                    return $"Recorded {winner} win against {loser}";
                }

                if (command.StartsWith("forfeit"))
                {
                    string playersString = command.Substring(11);
                    var players = playersString.Split(' ');
                    string forfeit = players[0];
                    string winner = players[1];
                    _league.RecordForfeit(forfeit, winner);
                    return $"Recorded {forfeit} forfeit against {winner}";
                }

                if (command == "print")
                {
                    return _leagueRenderer.Render(_league);
                }

                if (command == "winner")
                {
                    return _league.GetWinner();
                }

                if (command.StartsWith("save"))
                {
                    var name = command.Substring(5);
                    _fileService.Save(name, _league);
                    return $"Saved {name}";
                }

                if (command.StartsWith("load"))
                {
                    var name = command.Substring(5);
                    _league = _fileService.Load(name);
                    return $"Loaded {name}";
                }

                return $"Unknown command: {command}";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}
