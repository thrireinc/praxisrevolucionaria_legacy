namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using ScriptableObjects;
    
    public class ControladorPuzzleGenius : ControladorPuzzle
    {
        [Space]
        [Header("Genius")]
        [SerializeField] private int numeroSequencias;
        [SerializeField] private float tempoEntreEmocoes;
        [SerializeField] private GameObject pnlInput;
        [SerializeField] private GeniusObject[] emocoes;
        [SerializeField] private Image imagemEmocaoAtual;
        
        private int _indexAtual, _sequenciasRealizadas;
        private List<GeniusObject> _sequencia;
        
        public void CriarSequencia()
        {
            _sequencia = new List<GeniusObject>();
            _indexAtual = 0;
            
            for (var i = 0; i < numeroSequencias+1; i++)
                _sequencia.Add(emocoes[Random.Range(0, emocoes.Length)]);
            
            StartCoroutine(ExibirSequencia(3, true));
        }
        private IEnumerator ExibirSequencia(float delayInicial, bool reproduzirDelayInicial)
        {
            int componenteAtual;
            
            if (reproduzirDelayInicial)
                yield return new WaitForSeconds(delayInicial);
            
            _indexAtual = componenteAtual = 0;
            pnlInput.SetActive(true);
            
            foreach (var componente in _sequencia)
            {
                var emocaoAtual = imagemEmocaoAtual.gameObject;
                imagemEmocaoAtual.sprite = componente.Icone;

                emocaoAtual.SetActive(true);
                yield return new WaitForSeconds(tempoEntreEmocoes);
                emocaoAtual.SetActive(false);
                yield return new WaitForSeconds(tempoEntreEmocoes);

                if (componenteAtual == _sequenciasRealizadas)
                    break;

                componenteAtual++;
            }
            
            pnlInput.SetActive(false);
        }
        public void CompararEmocao(int id)
        {
            if (id != _sequencia[_indexAtual].Id)
            {
                ControladorGameOver.Gameover(false);
                return;
            }
            _indexAtual++;
            if (_indexAtual != _sequenciasRealizadas+1) return;
            if (_sequenciasRealizadas != numeroSequencias)
            {
                _sequenciasRealizadas++;
                StartCoroutine(ExibirSequencia(0, false));
                return;
            }
            ControladorGameOver.Gameover(true);
        }
    }
}