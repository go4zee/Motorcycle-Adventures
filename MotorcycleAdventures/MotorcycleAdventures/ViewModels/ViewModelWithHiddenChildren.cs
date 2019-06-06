namespace MotorcycleAdventures.ViewModels
{
    public abstract class ViewModelWithHiddenChildren
    {
        protected ViewModelWithHiddenChildren()
        {
            AreChildrenVisible = false;
        }

        public bool AreChildrenVisible { get; set; }
        public string ArrowIconSource => AreChildrenVisible ? "ArrowUp.png" : "ArrowDown.png";
    }
}