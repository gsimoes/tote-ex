namespace ToteChallenge.Domain
{
    public class AddBetCommand : Command
    {
        public override void Execute(Tote context)
        {
            throw new System.NotImplementedException();
        }

        public string Type { get; set; }

        public string Runners { get; set; }

        public decimal TotalStake { get; set; }
    }
}