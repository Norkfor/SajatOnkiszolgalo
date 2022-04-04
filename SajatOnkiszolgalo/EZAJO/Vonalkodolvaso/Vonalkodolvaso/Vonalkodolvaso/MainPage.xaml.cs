using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySqlConnector;
using ZXing.Net.Mobile.Forms;

namespace Vonalkodolvaso
{
    public partial class MainPage : ContentPage
    {
        static bool vasarolhat = false;
        static int pultokID = 0;
        static int arucikkekID = 0;
        static string kapcs = "Server=leventepc.ddns.net; Port=3306; Database=termekek; Uid=norkfor; Pwd=termekek;";
        bool alljMeg;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            alljMeg = false;

            var beolvas = new ZXingScannerPage();
            await Navigation.PushModalAsync(beolvas);

            beolvas.OnScanResult += (olvasottErtek) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    MySqlConnection conn = new MySqlConnection(kapcs);
                    if (!vasarolhat)
                    {
                        try
                        {
                            conn.Open();
                            MySqlCommand parancs = new MySqlCommand($"SELECT id FROM pultok WHERE vonalkod_szam = {Convert.ToInt64(olvasottErtek.Text)};", conn);

                            MySqlDataReader olvaso = parancs.ExecuteReader();
                            if (olvaso.HasRows)
                            {
                                olvaso.Read();
                                pultokID = olvaso.GetInt32(0);
                                vasarolhat = true;
                                await Navigation.PopModalAsync();
                                UzenetKiiras("Sikeres kapcsolódás az önkiszolgálóhoz!");

                            }
                            else
                            {
                                await Navigation.PopModalAsync();
                                UzenetKiiras("Sikertelen kapcsolódás az önkiszolgálóhoz!");
                            }
                        }
                        catch (Exception ex)
                        {
                            await Navigation.PopModalAsync();
                            UzenetKiiras(ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }

                    }

                    else
                    {
                        if (olvasottErtek.ToString()[0] >= 'A' && olvasottErtek.ToString()[0] <= 'Z')
                        {
                            try
                            {
                                conn.Open();
                                MySqlCommand parancs = new MySqlCommand($"SELECT id FROM dolgozok WHERE dolgozok.vonalkod = '{olvasottErtek}';", conn);
                                MySqlDataReader olvaso = parancs.ExecuteReader();
                                if (olvaso.HasRows)
                                {
                                    olvaso.Read();
                                    int dolgozokID = olvaso.GetInt32(0);
                                    conn.Close();
                                    conn.Open();
                                    MySqlCommand parancs1 = new MySqlCommand($"UPDATE `dolgozok` SET `aktiv` = '1' WHERE `dolgozok`.`id` = {dolgozokID};", conn);
                                    parancs1.ExecuteNonQuery();
                                    await Navigation.PopModalAsync();
                                }
                            }
                            catch (Exception ex)
                            {
                                await Navigation.PopModalAsync();
                                UzenetKiiras(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        else
                        {
                            try
                            {
                                conn.Open();
                                MySqlCommand parancs1 = new MySqlCommand($"SELECT aruid FROM arucikkek WHERE vonalkod_szam = {Convert.ToInt64(olvasottErtek.Text)};", conn);
                                MySqlDataReader olvaso1 = parancs1.ExecuteReader();
                                if (olvaso1.HasRows)
                                {
                                    olvaso1.Read();
                                    arucikkekID = olvaso1.GetInt32(0);
                                    conn.Close();
                                    conn.Open();
                                    MySqlCommand parancs2 = new MySqlCommand($"SELECT id, termekDarab FROM vasarlok WHERE arucikkekID = '{arucikkekID}' AND pultokID = '{pultokID}';", conn);
                                    MySqlDataReader olvaso2 = parancs2.ExecuteReader();
                                    if (olvaso2.HasRows)
                                    {
                                        olvaso2.Read();
                                        int id = olvaso2.GetInt32(0);
                                        int darab = olvaso2.GetInt32(1) + 1;
                                        conn.Close();
                                        conn.Open();
                                        MySqlCommand parancs3 = new MySqlCommand($"UPDATE `vasarlok` SET `pultokID` = '{pultokID}', `arucikkekID` = '{arucikkekID}', `termekDarab` = '{darab}', `aktiv` = '1' WHERE `vasarlok`.`id` = '{id}';", conn);
                                        parancs3.ExecuteNonQuery();
                                        await Navigation.PopModalAsync();
                                        UzenetKiiras("A termék hozzáadása sikeresen megtörtént!");
                                        conn.Close();
                                    }
                                    else
                                    {
                                        conn.Close();
                                        conn.Open();
                                        MySqlCommand parancs4 = new MySqlCommand($"INSERT INTO `vasarlok` (`id`, `pultokID`, `arucikkekID`, `termekDarab`, `aktiv`) VALUES (NULL, '{pultokID}', '{arucikkekID}', '1', '1');", conn);
                                        parancs4.ExecuteNonQuery();
                                        await Navigation.PopModalAsync();
                                        UzenetKiiras("A termék hozzáadása sikeresen megtörtént!");
                                        conn.Close();
                                    }
                                }
                                else
                                {
                                    await Navigation.PopModalAsync();
                                    UzenetKiiras("Az adatbázisban nem szerepel ez az árucikk!");
                                }

                            }
                            catch (Exception ex)
                            {
                                await Navigation.PopModalAsync();
                                UzenetKiiras(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                });
            };
        }

        private void UzenetKiiras(string jelenlegSzoveg)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("intro_sound.mp3");
            player.Play();
            szoveg.Text = jelenlegSzoveg;
            szovegresz.IsVisible = true;
            int szamlalas = 7;
            alljMeg = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                szoveg.Text = jelenlegSzoveg;
                szovegresz.IsVisible = true;
                szamlalas--;
                if (szamlalas == 0)
                {
                    alljMeg = false;
                    szovegresz.IsVisible = false;
                }
                return alljMeg;
            });
        }
    }
}