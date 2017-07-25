using System.Text.RegularExpressions;

namespace ToteChallenge.Domain
{
    public interface ICommandParser
    {
        Command Parse(string input);
    }

    public class ToteCommandParser : ICommandParser
    {
        public Command Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new ErrorCommand();
            }

            var matchResult = Regex.Match(input.ToLower().Trim(),
                @"^(?<command>bet)\:(?<betType>W|P|E)\:((?<runners>\d{1,2})|(?<runners>\d{1,2}[,]\d{1,2}))\:(?<stake>\d{1,8})|(?<command>result)\:(?<first>\d{1,2})\:(?<second>\d{1,2})\:(?<third>\d{1,2})$",
                RegexOptions.IgnoreCase);

            if (!matchResult.Success)
            {
                return new ErrorCommand();
            }

            var command = matchResult.Groups["command"].Value;

            if (command == "bet")
            {
                return new AddBetCommand
                {
                    Type = matchResult.Groups["betType"].Value,
                    Runner = matchResult.Groups["runners"].Value,
                    Stake = decimal.Parse(matchResult.Groups["stake"].Value)
                };
            }

            return new ResultCommand
            {
                First = int.Parse(matchResult.Groups["first"].Value),
                Second = int.Parse(matchResult.Groups["second"].Value),
                Third = int.Parse(matchResult.Groups["third"].Value)
            };
        }
    }
}