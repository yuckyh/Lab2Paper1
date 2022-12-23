namespace Lab2Paper1
{
    public interface IHasInput
    {
        HasParent HasParent { get; }

        void InitInputs();
        void UpdateInputValues();

        bool IsValidInput(Session1Entities entity);
    }
}