namespace ElegantLib.Validate
{
    public interface ICatcher<out T>
    {
        void Execute();
    }
}