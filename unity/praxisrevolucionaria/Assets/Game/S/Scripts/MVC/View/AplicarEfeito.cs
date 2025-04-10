namespace Game.S.Scripts.MVC.View
{
    using UnityEngine;
    using Enumeradores;
    using Interfaces.Efeitos;
    using Model;
    
    public class AplicarEfeito : MonoBehaviour
    {
        public IEfeitos ReferenciaEfeito;
        public Efeitos TipoEfeito => tipoEfeito;
        
        [SerializeField] private Efeitos tipoEfeito;
        [SerializeField] private bool aplicarEfeitoInfinitamente, finalizarCicloEfeito, bloquearRaycasts, executarNoStart;
        [Space]
        [SerializeField] protected Vector2 limitesEfeito, limitesTimer;
        [SerializeField] private float tempoInicio = 1;
        
        private bool _efeitoFinalizado;
        private CanvasGroup _canvasGroup;
        private Vector2 _limitesEfeito;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            _limitesEfeito = limitesEfeito;
            
            if (executarNoStart)
                this.ExecutarAcaoAposTemporizador(ExecutarEfeito, limitesTimer.x);
        }
        public void ExecutarEfeito()
        {
            ReferenciaEfeito.Efeito(_canvasGroup, _limitesEfeito, tempoInicio);
            _canvasGroup.blocksRaycasts = bloquearRaycasts;

            if (finalizarCicloEfeito && !_efeitoFinalizado)
            {
                _efeitoFinalizado = true;
                this.ExecutarAcaoAposTemporizador(ExecutarEfeito, limitesTimer.y);
            }

            if (aplicarEfeitoInfinitamente)
                this.ExecutarAcaoAposTemporizador(ExecutarEfeito, limitesTimer.x);
        }

        // tirar daqui
        public void DesabilitarObjeto(float tempoParaDesabilitar)
        {
            this.ExecutarAcaoAposTemporizador(gameObject.SetActive, tempoParaDesabilitar, false);
        }
        public void DefinirEfeitoX(float x)
        {
            _limitesEfeito = new Vector2(x, _limitesEfeito.y);
        }
        public void DefinirEfeitoY(float y)
        {
            _limitesEfeito = new Vector2(_limitesEfeito.x, y);
        }
    }
}