using Microsoft.AspNetCore.Components;

namespace MyPotion.Components
{
    public partial class Melange<TPotion>
    {
        [Parameter]
        public RenderFragment<TPotion> MelangeBody { get; set; }

        [Parameter]
        public RenderFragment<TPotion> MelangeHeader { get; set; }

        [Parameter]
        public TPotion Potion { get; set; }
    }

}
