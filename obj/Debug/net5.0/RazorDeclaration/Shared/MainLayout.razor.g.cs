// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TomeKop.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using TomeKop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using TomeKop.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/ma/Desktop/TomeKop/TomeKop/_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using Npgsql;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using Serilog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using TomeKop.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
using Blazored.Toast.Configuration;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 48 "/Users/ma/Desktop/TomeKop/TomeKop/Shared/MainLayout.razor"
       
    private bool Waiting = true;
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(10);

        // await sessionStorage.SetItem<Uye>(key, forecasts);
        // await localStorage.SetItem<WeatherForecast[]>(key, forecasts);
        // var fromLocal = await localStorage.GetItem<WeatherForecast[]>(key);
    }

    private async Task LogOut()
    {
        Program.uye = null;
        await localStorage.RemoveItemAsync("uyeJsonString");
        uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Log.Information("OnAfterRenderAsync");
        if (firstRender)
        {
            Log.Information("firstRender");
            try
            {
                Program.uye = JsonSerializer.Deserialize<Uye>(await localStorage.GetItemAsync<string>("uyeJsonString"));
                Log.Information("try fromSession sessionStorage");
            }
            catch (System.Exception)
            {
                Log.Information("catch fromSession Exception");

                if (Program.DbCon.State == System.Data.ConnectionState.Closed)
                    Program.DbCon.Open();
                using var cmd = new NpgsqlCommand(SqlCommands.CheckIfUyelerTableExist, Program.DbCon);

                try
                {
                    Log.Information("try NpgsqlCommand CheckIfUyelerTableExist");
                    var version = cmd.ExecuteScalar().ToString();
                    Log.Information($"try NpgsqlCommand CheckIfUyelerTableExist {version}");
                }
                catch (System.Exception)
                {
                    Log.Information("catch CreateUyeTable");
                    using var cmd2 = new NpgsqlCommand(SqlCommands.CreateUyeTable, Program.DbCon);
                    cmd2.ExecuteNonQuery();
                }
                if (Program.DbCon.State == System.Data.ConnectionState.Open)
                    Program.DbCon.Close();
            }
            Waiting = false;
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591
