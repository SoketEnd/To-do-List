using System.Threading.Channels;
using To_do_List.View;
using To_do_List.ViewModel;

namespace To_do_List
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Viev viev = new Viev();

            await viev.Show();
        }
    }
}
