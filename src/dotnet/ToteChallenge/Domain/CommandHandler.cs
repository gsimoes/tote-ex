namespace ToteChallenge.Domain
{
    public class CommandHandler
    {
        private readonly ICommandParser _commandParser;
        private readonly Tote _context;

        public CommandHandler(ICommandParser commandParser, Tote context)
        {
            _commandParser = commandParser;
            _context = context;
        }

        public void Execute(string input)
        {
            var command = _commandParser.Parse(input);

            command.Execute(_context);
        }
    }
}