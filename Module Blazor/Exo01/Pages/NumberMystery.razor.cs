using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exo01.Pages;

public partial class NumberMystery
{
    [Parameter]
    public int EssaisRestants { get; set; } 

    public string EssaisRestantsCoeur { get; set; } = "";

    public int NombreMysterieux { get; set; } = 0;

    private int? _inputValue;

    public bool GameWin = false;
    public bool GameLost {
        get
        {
            return EssaisRestants > 0 ?  false : true;
        }
    }


    private void Try()
    {
        if (EssaisRestants > 0)
        {

            if (_inputValue != NombreMysterieux)
            {
                EssaisRestants--;
                
            }
            else
            {
                GameWin = true;
                
            }

        AfficherCoeurs();
        }
    }
    private void Restart()
    {
        OnInitializedAsync();
    }

    private void AfficherCoeurs()
    {
        EssaisRestantsCoeur = "";
        for (int i = 0; i < EssaisRestants; i++)
        {
            EssaisRestantsCoeur += "❤️";
        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (EssaisRestants == 0) EssaisRestants = 4;

        AfficherCoeurs();

        NombreMysterieux = new Random().Next(19)+1;

    }
}
