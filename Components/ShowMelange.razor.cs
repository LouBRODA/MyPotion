using Microsoft.AspNetCore.Components;

namespace MyPotion.Components
{
    public partial class ShowMelange<TMelange>
    {
        [Parameter]
        public List<TMelange> Melanges { get; set; }

        [Parameter]
        public RenderFragment<TMelange> ShowTemplate { get; set; }
    }
}
