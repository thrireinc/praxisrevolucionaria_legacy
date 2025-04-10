namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;
    using Model;

    public class ControladorCriptografia : MonoBehaviour
    {
        private void Start()
        {
            this.ExecutarAcaoAposTemporizador(AtualizarChave, 3);
        }
        private void AtualizarChave()
        {
            Criptografia.AtualizarChaveDeEncriptacao();
            this.ExecutarAcaoAposTemporizador(AtualizarChave, 3);
        }
    }
}