namespace ToteChallenge.Domain
{
    public class ResultCommand : Command
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }

        public override void Execute(Tote context)
        {
            throw new System.NotImplementedException();
        }
    }
}