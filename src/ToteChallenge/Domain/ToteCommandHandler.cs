namespace ToteChallenge.Domain
{
    public class ToteCommandHandler
    {
        private readonly ICommandParser _commandParser;
        private readonly Tote _context;

        public ToteCommandHandler(ICommandParser commandParser, Tote context)
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