namespace Game.S.Scripts.MVC.Model
{
    using UnityEngine;

    public class Tela : MonoBehaviour
    {
        [SerializeField] private ScreenOrientation orientacao;

        private void Start()
        {
            Screen.orientation = orientacao;
        }
    }
}