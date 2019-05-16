using UnityEngine;
using UnityEngine.SceneManagement;

namespace AirStrikeKit
{
    public class Mainmeu : MonoBehaviour
    {

        public GUISkin skin;
        public Texture2D Logo;

        void Start()
        {

        }

        public void OnGUI()
        {
            if (skin)
                GUI.skin = skin;

            GUI.DrawTexture(new Rect(Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Classic"))
            {
                SceneManager.LoadScene("Classic");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Modern"))
            {
                SceneManager.LoadScene("Modern");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 40), "Invasion"))
            {
                SceneManager.LoadScene("Invasion");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 200, 300, 40), "Star Fighter"))
            {
                SceneManager.LoadScene("StarFighter");
            }

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(0, Screen.height - 90, Screen.width, 50), "Air strike starter kit. by Rachan Neamprasert\n www.hardworkerstudio.com");
        }
    }
}