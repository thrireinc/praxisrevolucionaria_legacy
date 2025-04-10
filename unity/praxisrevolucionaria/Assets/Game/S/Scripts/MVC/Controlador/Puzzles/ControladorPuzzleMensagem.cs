namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Model;

    public class ControladorPuzzleMensagem : ControladorPuzzle
    {
        [SerializeField] private int numeroDeMensagensParaInstanciar;
        [SerializeField] private float valorDeSubtracaoDoSlider;
        [SerializeField] private Button btnEnviar;
        [SerializeField] private TextMeshProUGUI placeholderTexto;
        [SerializeField] private TMP_InputField inputJogador;
        [SerializeField] private RectTransform scroll;

        [Space] [Header("Temporizador")]
        [SerializeField] private GameObject imgPreenchimentoSlider;
        [SerializeField] private Slider sldrTemporizadorParaDigitarMensagem;
        
        [Space] [Header("NPC")]
        [SerializeField] private Image caixaTextoNpc;
        [SerializeField] private string[] mensagensDosNpcs;

        [Space] [Header("Player")]
        [SerializeField] private Image caixaTextoPlayer;
        [SerializeField] private string[] mensagensDoPlayer;

        private int _indexRandomizado, _mensagensEnviadas;
        private float _tempoTemporizador;
        private bool _podeChecar, _isMensagemEnviada;
        private TextMeshProUGUI _textoInput;

        private void Start()
        {
            _textoInput = inputJogador.GetComponent<TextMeshProUGUI>();
            _tempoTemporizador = sldrTemporizadorParaDigitarMensagem.value;
            this.ExecutarAcaoAposTemporizador(InstanciarMensagem, 2);
            btnEnviar.onClick.AddListener(() => EnviarMensagem());
        }
        private void Update()
        {
            if (_podeChecar)
                btnEnviar.interactable = ChecarTexto();
        }
        private void InstanciarMensagem()
        {
            _indexRandomizado = Random.Range(0, mensagensDoPlayer.Length);
            ConfigurarCaixaDeTexto(caixaTextoNpc, mensagensDoPlayer[_indexRandomizado]).text = mensagensDosNpcs[_indexRandomizado];
            StartCoroutine(TemporizadorDigitarMensagem());
        }
        private void EnviarMensagem()
        {
            ConfigurarCaixaDeTexto(caixaTextoPlayer, "Digite uma mensagem...").text = _textoInput.text;
            _textoInput.text = inputJogador.text = string.Empty;
            sldrTemporizadorParaDigitarMensagem.value = _tempoTemporizador;
            imgPreenchimentoSlider.SetActive(false);
            _mensagensEnviadas++;

            if (_mensagensEnviadas == numeroDeMensagensParaInstanciar)
            {
                ControladorGameOver.Gameover(true);
                return;
            }
            this.ExecutarAcaoAposTemporizador(InstanciarMensagem, 2);
        }
        private bool ChecarTexto()
        {
            var numeroCaracteres = 0;

            if (_textoInput.text.Length - 1 != mensagensDoPlayer[_indexRandomizado].Length)
                return false;

            for (var i = 0; i < _textoInput.text.Length - 1; i++)
                if (_textoInput.text.ToLower()[i] == mensagensDoPlayer[_indexRandomizado].ToLower()[i])
                    numeroCaracteres++;

            return numeroCaracteres == mensagensDoPlayer[_indexRandomizado].Length;
        }
        private TextMeshProUGUI ConfigurarCaixaDeTexto(Image caixaTexto, string textoPlaceholder)
        {
            var instanciaCaixa = Instantiate(caixaTexto, scroll.transform);
            var transformInstanciaCaixaTexto = instanciaCaixa.transform;
            var objetoMensagem = transformInstanciaCaixaTexto.GetChild(0);
            placeholderTexto.text = textoPlaceholder;
            _podeChecar = caixaTexto == caixaTextoNpc;
            _isMensagemEnviada = !(caixaTexto == caixaTextoNpc);
            
            return objetoMensagem.GetComponent<TextMeshProUGUI>();
        }
        private IEnumerator TemporizadorDigitarMensagem()
        {
            imgPreenchimentoSlider.SetActive(true);
            
            while (sldrTemporizadorParaDigitarMensagem.value > 0)
            {
                if (_isMensagemEnviada)
                    yield break;

                yield return new WaitForSeconds(valorDeSubtracaoDoSlider);
                sldrTemporizadorParaDigitarMensagem.value -= valorDeSubtracaoDoSlider;
            }
            
            ControladorGameOver.Gameover(false);
        }
    }
}