using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace Pokedex.Droid
{
    [Activity(Theme ="@style/MyTheme.Splash",MainLauncher =true,NoHistory =true)]
    public class SplashActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        //Executa a tarefa de startup

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        async void SimulateStartup()
        {
            Log.Debug(TAG, "Executando um trabalho de inicio isso pode levar algum tempo.");

            await Task.Delay(100);

            Log.Debug(TAG, "Trabalho de Inicio está completo - iniciando o MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}