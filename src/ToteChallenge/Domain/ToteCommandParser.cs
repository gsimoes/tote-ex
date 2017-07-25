using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ToteChallenge.Domain
{
    public class ToteCommandParser
    {
        private IDictionary<string, Func<string[], ToteCommand>> _commandFactory;

        public ToteCommandParser()
        {
            _commandFactory = new Dictionary<string, Func<string[], ToteCommand>>()
            {
                { "bet", CreateAddBetCommand },
                { "result", CreateResultCommand }
            };
        }

        public ToteCommand Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            var matchResult = Regex.Match(input.ToLower().Trim(),
                @"^(?<command>bet)\:(?<betType>W|P|E)\:((?<runners>\d{1,2})|(?<runners>\d{1,2}[,]\d{1,2}))\:(?<stake>\d{1,8})|(?<command>result)\:(?<first>\d{1,2})\:(?<second>\d{1,2})\:(?<third>\d{1,2})$",
                RegexOptions.IgnoreCase);

            if (!matchResult.Success)
            {
                return null;
            }

            var command = matchResult.Groups["command"].Value;
            return _commandFactory[command](null);
        }

        private static AddBetCommand CreateAddBetCommand(string[] args)
        {
            return new AddBetCommand();
        }

        private static ResultCommand CreateResultCommand(string[] args)
        {
            return new ResultCommand();
        }
    }
}