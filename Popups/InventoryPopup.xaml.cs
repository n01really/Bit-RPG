using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class InventoryPopup : Popup
{
    public InventoryPopup(Player player)
    {
        InitializeComponent();
        BindingContext = player;
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
