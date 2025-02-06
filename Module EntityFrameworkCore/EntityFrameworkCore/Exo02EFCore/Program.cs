using Exo01EFCore.Data;
using Exo02EFCore.Models;
using Exo02EFCore.Repositories;
using Exo02EFCore.UI;

//MainUI.Start();


var ui = new MainUI(); // ici on précise que l'on fait le CRUD dans MainUI avec des Repositories EF Core;

ui.Start();