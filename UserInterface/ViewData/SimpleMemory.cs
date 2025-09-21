using UserInterface.ViewModels;

namespace UserInterface.ViewData
{
    public class SimpleMemory
    {
        // single instance for assignment usage
        public static SimpleViewModel CurrentItem { get; set; } = null;
    }
}
