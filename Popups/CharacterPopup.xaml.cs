using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class CharacterPopup : Popup
{
    public CharacterPopup(Player player)
    {
        InitializeComponent();
        BindingContext = player;
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
