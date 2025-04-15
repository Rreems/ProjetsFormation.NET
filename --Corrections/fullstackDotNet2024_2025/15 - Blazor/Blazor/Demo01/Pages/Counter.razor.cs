using Microsoft.AspNetCore.Components;

namespace Demo01.Pages
{
    //public class CounterBase : ComponentBase
    public partial class Counter
    {
        [Parameter]
        public int CurrentCount { get; set; } = 0;

        private void IncrementCount()
        {
            CurrentCount += 10;
        }

        private void DecrementCount()
        {
            CurrentCount -= 10;
        }
    }
}
