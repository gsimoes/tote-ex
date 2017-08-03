namespace ToteChallenge.Domain
{
    public abstract class Command
    {
        public abstract void Execute(Tote context);
    }
}