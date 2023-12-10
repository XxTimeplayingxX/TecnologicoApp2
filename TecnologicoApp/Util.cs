using CommunityToolkit.Maui.Alerts;
using System.Text.RegularExpressions;

namespace TecnologicoApp;

public static class Util
{
    public static async  Task ShowToastAsync(string message)
    {
        var toast = Toast.Make(message);
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));
        await toast.Show(cts.Token);
    }
    public static bool IsAValidEmail(string email)
    {

        return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }
}
