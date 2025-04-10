namespace Game.S.Scripts.MVC.Controlador
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;
     
    public class ControladorAtivacaoPuzzle : MonoBehaviour
    {
        [SerializeField] private float temporizadorExecutarAcao;
        [SerializeField] private int numeroDePuzzlesNaCena;
        [SerializeField] private ControladorDados controladorDados;
        [SerializeField] private UnityEvent acaoParaExecutarCasoPuzzlesTenhamAcabado;

        private void Start()
        {
            StartCoroutine(DetectarEstadoDosPuzzles());
        }
        private IEnumerator DetectarEstadoDosPuzzles()
        {
            for (var i = 0; i < numeroDePuzzlesNaCena; i++)
                if (!Convert.ToBoolean(controladorDados.CarregarObjetoRetornar(i)))
                    yield break;

            yield return new WaitForSeconds(temporizadorExecutarAcao);
            acaoParaExecutarCasoPuzzlesTenhamAcabado?.Invoke();
        }
    }
}