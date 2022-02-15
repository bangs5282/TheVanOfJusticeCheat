using UnityEngine;

namespace Gamename_Hack
{
    class Main : MonoBehaviour
    {
        string debug = "Made by Github bangs5282";

        bool menu = true;

        bool god_mode = false;

        bool infinitRPG = false;

        int SpeedCheat = -1;

        GameObject gb;
        Movement mv;
        Combat cb;

        GameObject rocketlaunch;
        RPG7 rpg;

        public void Start()
        {
            //mv.speed = 0;
        }
        public void Update()
        {
            gb = GameObject.FindGameObjectWithTag("Player");
            mv = gb.GetComponent<Movement>();
            cb = gb.GetComponent<Combat>();

            try
            {
                rocketlaunch = GameObject.Find("Toy Rocket Launccher(Clone)");
                rpg = rocketlaunch.GetComponent<RPG7>();
            }
            catch { }

            if (Input.GetKeyDown(KeyCode.End))
            {
                if (menu)
                {
                    menu = false;
                }
                else
                {
                    menu = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Loader.Unload();
            }

            if (Input.GetKeyDown(KeyCode.PageUp))
            {
                if (god_mode)
                {
                    god_mode = false;
                }
                else
                {
                    god_mode = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.PageDown))
            {
                if (infinitRPG)
                {
                    infinitRPG = false;
                }
                else
                {
                    infinitRPG = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Insert))
            {
                Movement.currentMoney = 999999;
            }

            if (Input.GetKeyDown(KeyCode.Home))
            {
                SpeedCheat *= -1;
            }

            if (SpeedCheat == 1)
            {
                mv.speed = 50f;
            }
            else if (SpeedCheat == -1)
            {
                mv.speed = 8.2f;
            }

            if (god_mode)
            {
                cb.hp = 100;
            }
            else
            {
                cb.fullHp = 100;
            }

            if (infinitRPG)
            {
                rpg.amount = 9;
            }


        }
        public void OnGUI()
        {
            if (menu)
            {
                float offsetx = 340f;
                float offsety = 0f;

                GUI.Box(new Rect(10f + offsetx, 10f + offsety, 265f, 115f), "Press [End] to Close Menu");


                GUI.Label(new Rect(15f + offsetx, 30f + offsety, 300f, 50f), "[Insert] - Money");
                GUI.Label(new Rect(15f + offsetx, 45f + offsety, 300f, 50f), "[Home] - Speed");
                GUI.Label(new Rect(15f + offsetx, 60f + offsety, 300f, 50f), "[PgUp] - GodMode");
                GUI.Label(new Rect(15f + offsetx, 75f + offsety, 300f, 50f), "[PgDn] - Infinite Rocket");
                GUI.Label(new Rect(15f + offsetx, 95f + offsety, 300f, 50f), debug);
            }
        }


    }
    public class Loader
    {
        static GameObject _Load;

        public static void Init()
        {
            _Load = new GameObject();
            _Load.AddComponent<Main>();
            GameObject.DontDestroyOnLoad(_Load);
        }
        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            GameObject.Destroy(_Load);
        }
        private GameObject _gameObject;
    }
}
