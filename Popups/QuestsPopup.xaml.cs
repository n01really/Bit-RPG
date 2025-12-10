using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class QuestsPopup : Popup
{
    public QuestsPopup(Player player)
    {
        InitializeComponent();
        BindingContext = player;
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
