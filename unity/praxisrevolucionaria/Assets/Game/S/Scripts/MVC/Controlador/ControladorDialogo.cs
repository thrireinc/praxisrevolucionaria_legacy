namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;
    using Model;

    public class ControladorDialogo : MonoBehaviour
    { 
        public string NomeDialogo {get; set;}
        
        [SerializeField] private float delayParaIniciarDialogo;
        [SerializeField] private bool iniciarDialogoAutomaticamente;
        [SerializeField] private ControladorVide controladorDialogo;

        private void Awake()
        {
            PlayerPrefs.SetInt("DialogoAcontecendo", 1);
        }
        private void Start()
        {
            if (iniciarDialogoAutomaticamente)
                this.ExecutarAcaoAposTemporizador(IniciarDialogo, delayParaIniciarDialogo, NomeDialogo);
        }
        public void IniciarDialogo(string nomeDialogo)
        {
            controladorDialogo.Begin(NomeDialogo);
        }
    }
}