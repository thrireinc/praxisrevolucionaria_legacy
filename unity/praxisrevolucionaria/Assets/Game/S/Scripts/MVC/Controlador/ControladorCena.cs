namespace Game.S.Scripts.MVC.Controlador
{   
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Model;

    public class ControladorCena : MonoBehaviour
    {
        [SerializeField] private float temporizadorPassarCenaAutomaticamente;
        [SerializeField] private bool passarCenaAutomaticamente, passarCenaEspecifica, carregarCenaSalva;
        [SerializeField] private int indexCenaEspecifica, numeroDialogosTela, indexDadoSalvo;
        [SerializeField] private ControladorDados controladorDados;

        private Scene _cenaAtual;

        private void Start()
        {
            PlayerPrefs.SetInt("DialogosFeitos", 0);
            _cenaAtual = SceneManager.GetActiveScene();
            
            if (passarCenaAutomaticamente)
                StartCoroutine(DecidirComportamento());
        }
        private IEnumerator DecidirComportamento()
        {
            do
            {
                yield return new WaitForSeconds(0.05f);
            } while (PlayerPrefs.GetInt("DialogosFeitos") != numeroDialogosTela);
            
            PassarCena(carregarCenaSalva && controladorDados.CarregarObjetoRetornar(indexDadoSalvo) != null ? Convert.ToInt32(controladorDados.CarregarObjetoRetornar(indexDadoSalvo)) : passarCenaEspecifica ? indexCenaEspecifica : _cenaAtual.buildIndex + 1);
        }
        public void PassarCena(int index)
        {
            this.ExecutarAcaoAposTemporizador(SceneManager.LoadScene, temporizadorPassarCenaAutomaticamente, index);
        }
        public void PassarCena()
        {
            this.ExecutarAcaoAposTemporizador(SceneManager.LoadScene, temporizadorPassarCenaAutomaticamente, passarCenaEspecifica ? indexCenaEspecifica : _cenaAtual.buildIndex + 1);
        }
    }
}