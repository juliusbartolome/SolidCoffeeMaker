namespace SolidCoffeeMaker
{
    public interface IOpenCloseDevice
    {
        void Open();
        void Close();
        bool IsOpen();
    }
}
