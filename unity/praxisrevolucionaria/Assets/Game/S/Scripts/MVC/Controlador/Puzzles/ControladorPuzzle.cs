namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System.Collections;
    using UnityEngine.Events;
    using UnityEngine;
    using TMPro;
    
    public class ControladorPuzzle : MonoBehaviour
    {
        protected ControladorGameOver ControladorGameOver => controladorGameover;
        
        [Header("Gameover")]
        [SerializeField] private ControladorGameOver controladorGameover;

        [Space]
        [Header("Timer")]
        [SerializeField] private float tempoTimer, tempoAntesDoTimer, tempoAntesDoEfeito;
        [SerializeField] private GameObject imgTimer;
        [SerializeField] private TextMeshProUGUI txtTimer;
        [SerializeField] private UnityEvent acaoParaExecutarAposTimer;

        private IEnumerator ExecutarTimer()
        {
            var timerPassado = 0;
            
            yield return new WaitForSeconds(tempoAntesDoTimer);
            imgTimer.SetActive(true);
            yield return new WaitForSeconds(tempoAntesDoEfeito);
            
            while (timerPassado < tempoTimer)
            {
                txtTimer.text = $"{tempoTimer - timerPassado}";
                yield return new WaitForSeconds(1);
                timerPassado++;
            }
            
            imgTimer.SetActive(false);
            acaoParaExecutarAposTimer?.Invoke();
        }
    } 
}