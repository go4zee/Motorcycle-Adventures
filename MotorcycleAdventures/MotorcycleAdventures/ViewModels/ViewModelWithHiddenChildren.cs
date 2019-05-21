namespace MotorcycleAdventures.ViewModels
{
    public abstract class ViewModelWithHiddenChildren
    {
        public ViewModelWithHiddenChildren()
        {
            AreChildrenVisible = false;
        }

        public bool AreChildrenVisible { get; set; }
        public string ArrowIconSource => AreChildrenVisible ? "Down.png" : "Right.png";
    }
}