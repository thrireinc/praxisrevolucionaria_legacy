namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using ScriptableObjects;
    
    public class ControladorPuzzleQuebraCabeca : ControladorPuzzle
    {
        [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;
        [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
        [SerializeField] private QuebraCabecaObject[] pecasParaInstanciar;
        private int _offset;
        private bool _isPecaSelecionada;
        private Image _pecaGuardada;
        private List<QuebraCabecaObject> _listaDeObjetosParaRandomizar, _listaRandomizada;
        private List<Image> _ordemAtual;
        private List<Sprite> _ordemCerta;
        
        private void Start()
        {
            _listaDeObjetosParaRandomizar = _listaRandomizada = new List<QuebraCabecaObject>();
            _ordemAtual = new List<Image>();
            _ordemCerta = new List<Sprite>();

            foreach (var pecaParaInstanciar in pecasParaInstanciar)
            {
                _listaDeObjetosParaRandomizar.Add(pecaParaInstanciar);
                _ordemCerta.Add(pecaParaInstanciar.Icone);
            }

            foreach (var unused in pecasParaInstanciar)
                RandomizarSequencia();

            for (var i = 0; i < pecasParaInstanciar.Length / 2; i++)
            {
                InstanciarLayout(i);
                _offset = i + 1;
            }
        }
        private void RandomizarSequencia()
        {
            while (true)
            {
                var index = Random.Range(0, _listaDeObjetosParaRandomizar.Count);
                _listaRandomizada.Add(_listaDeObjetosParaRandomizar[index]);
                _listaDeObjetosParaRandomizar.Remove(_listaDeObjetosParaRandomizar[index]);

                var queryPecasNasPosicoesIniciais = pecasParaInstanciar.Where((t, i) => _listaRandomizada[i].Id == t.Id);
                if (queryPecasNasPosicoesIniciais.Count() > 1) continue;
                break;
            }
        }
        private void InstanciarLayout(int index)
        {
            var instanciaLayout = Instantiate(horizontalLayoutGroup, verticalLayoutGroup.transform);
            var transformInstanciaLayout = instanciaLayout.transform;

            for (var i = 0; i < transformInstanciaLayout.childCount; i++)
            {
                var pecaAtual = transformInstanciaLayout.GetChild(i);
                var imagemPecaAtual = pecaAtual.GetComponent<Image>();
                _ordemAtual.Add(imagemPecaAtual);
                var botaoPecaAtual = pecaAtual.GetComponent<Button>();
                
                imagemPecaAtual.sprite = _listaRandomizada[index + i + _offset].Icone;
                botaoPecaAtual.onClick.AddListener(() => ClicarPeca(imagemPecaAtual));
            }
        }
        private void ClicarPeca(Image pecaClicada)
        {
            // Ativar highlight

            if (!_isPecaSelecionada)
            {
                _isPecaSelecionada = true;
                _pecaGuardada = pecaClicada;
                return;
            }
            if (pecaClicada.sprite == _pecaGuardada.sprite)
            {
                _isPecaSelecionada = false;
                return;
            }

            // Não trocar caso a peça já esteja no lugar certo
            
            var iconeTmp = pecaClicada.sprite;
            pecaClicada.sprite = _pecaGuardada.sprite;
            _pecaGuardada.sprite = iconeTmp;
            _isPecaSelecionada = false;
            
            
            if (_ordemCerta.Where((t, i) => _ordemAtual[i].sprite != t).Any())
                return;

            ControladorGameOver.Gameover(true);
        }
    }
}