namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Model;
    using View;
    using Random = UnityEngine.Random;
    
    public class ControladorPuzzleSenha : ControladorPuzzle
    {
        [SerializeField] private int numeroDeBotoesParaFormarSenha;
        [SerializeField] private GameObject botaoParaPassar;
        [SerializeField] private BotaoSenha botaoParaApertar;
        [SerializeField] private TextMeshProUGUI txtFeedbackSenhaDigitada;
        [SerializeField] private HorizontalLayoutGroup layoutHorizontalDosBotoes;
        private string _senha;
        private int _indexAtual;
        private List<Button> _botoes;
        
        private void Start()
        {
            _botoes = new List<Button>();
            CriarSenha();
            
            for (var i = 0; i < numeroDeBotoesParaFormarSenha; i++)
                InstanciarBotao(i + 1);
        }
        private void InstanciarBotao(int indexBotao)
        {
            var instanciaBotao = Instantiate(botaoParaApertar, layoutHorizontalDosBotoes.transform);
            var btnInstanciaBotao = instanciaBotao.GetComponent<Button>();
            var clickedEvent = btnInstanciaBotao.onClick;

            instanciaBotao.txtDigito.text = indexBotao.ToString();
            _botoes.Add(btnInstanciaBotao);
            clickedEvent.AddListener(() => DetectarClique(btnInstanciaBotao));
        }
        private void CriarSenha()
        {
            do
            {
                var digitoRandomizado = Random.Range(1, numeroDeBotoesParaFormarSenha + 1);
                _senha += digitoRandomizado.ToString();
            } while (_senha.Length < numeroDeBotoesParaFormarSenha);
        }
        private void DetectarClique(Button btn)
        {
            var id = _botoes.IndexOf(btn) + 1;
            var imagemBotao = btn.GetComponent<Image>();

            if (id == Convert.ToInt32(_senha[_indexAtual].ToString()))
            {
                txtFeedbackSenhaDigitada.text += "*";
                imagemBotao.color = Color.green;
                this.ExecutarAcaoAposTemporizador(ResetarCor, 0.25f, imagemBotao);
                _indexAtual++;

                if (_indexAtual != numeroDeBotoesParaFormarSenha) return;
                foreach (var botao in _botoes)
                    Destroy(botao);
                txtFeedbackSenhaDigitada.text = _senha;
                botaoParaPassar.SetActive(true);
                return;
            }

            txtFeedbackSenhaDigitada.text = "";
            _indexAtual = 0;
            imagemBotao.color = Color.red;
            this.ExecutarAcaoAposTemporizador(ResetarCor, 0.25f, imagemBotao);
        }
        private void ResetarCor(Image imagem)
        {
            imagem.color = Color.white;
        }
    }
}