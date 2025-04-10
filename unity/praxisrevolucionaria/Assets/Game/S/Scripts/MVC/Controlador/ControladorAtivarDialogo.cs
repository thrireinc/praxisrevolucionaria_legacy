namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;

    public class ControladorAtivarDialogo : MonoBehaviour
    {
        [SerializeField] private string nomeDialogoAutomatico;
        [SerializeField] private ControladorDialogo controladorDialogo;

        private void Start()
        {
            controladorDialogo.NomeDialogo = nomeDialogoAutomatico;
        }
    }
}