using System;

namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using System.Collections;
    using UnityEngine;
    using TMPro;

    public class ControladorPuzzleDaytrade : ControladorPuzzle
    {
        [SerializeField] private int numeroLimite, numeroRodadas;
        [SerializeField] private TextMeshProUGUI txtNumeroRandomizado, txtHigh, txtLow, txtResultado, txtAviso, txtPlaceholderBotaoAposta, txtFundosJogador, txtValorAposta;
        [SerializeField] private GameObject btVoltarHigh, btVoltarLow;

        private int _numeroHigh, _numeroLow, _numeroRandomizado, _valorAposta, _rodadasFeitas, _fundosAtuais;
        private float _chanceVitoria;
        
        private void Start()
        {
            _fundosAtuais = 200;
            txtFundosJogador.text = $"R$ {_fundosAtuais}.00";
            AtualizarValorAposta(20 > _fundosAtuais ? _fundosAtuais : 20);
            _chanceVitoria = 47.5f;
            ConfigurarValores();
        }
        private void ConfigurarValores()
        {
            _numeroHigh = (int)(numeroLimite -  numeroLimite / 100f * _chanceVitoria);
            _numeroLow = (int) (numeroLimite / 100f * _chanceVitoria);
            
            txtHigh.text = $"↑{_numeroHigh}";
            txtLow.text = $"↓{_numeroLow}";
        }
        private void DefinirResultado(int tipoNumero)
        {
            switch (tipoNumero)
            {
                case 0:
                    if (_numeroRandomizado < _numeroHigh)
                    {
                        _fundosAtuais -= Convert.ToInt32(_valorAposta);
                        txtResultado.color = Color.red;
                        txtResultado.gameObject.SetActive(true);
                        txtResultado.text = $"Você apostou HIGH, então perdeu {txtValorAposta.text}";
                        break;
                    }
                    _fundosAtuais += Convert.ToInt32(_valorAposta);
                    txtResultado.color = Color.green;
                    txtResultado.gameObject.SetActive(true);
                    txtResultado.text = $"Você apostou HIGH, então ganhou {txtValorAposta.text}";
                    break;
                case 1:
                    if (_numeroRandomizado >= _numeroLow)
                    {
                        _fundosAtuais -= Convert.ToInt32(_valorAposta);
                        txtResultado.color = Color.red;
                        txtResultado.gameObject.SetActive(true);
                        txtResultado.text = $"Você apostou LOW, então perdeu {txtValorAposta.text}";
                        break;
                    }
                    _fundosAtuais += Convert.ToInt32(_valorAposta);
                    txtResultado.color = Color.green;
                    txtResultado.gameObject.SetActive(true);
                    txtResultado.text = $"Você apostou LOW, então ganhou {txtValorAposta.text}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoNumero), tipoNumero, null);
            }
            
            txtFundosJogador.text = $"R$ {_fundosAtuais}.00";
            _rodadasFeitas++;
        }
        private void AtualizarValorAposta(int valor)
        {
            _valorAposta = valor;
            txtPlaceholderBotaoAposta.text = $"R${_valorAposta}.00";
        }
        public void AlterarAposta(int valorAumento)
        {
            txtAviso.gameObject.SetActive(true);
            if (_valorAposta == 1 && valorAumento < 0)
            {
                txtAviso.color = Color.red;
                txtAviso.text = "Sua aposta não pode ser menor do que 1.";
                return;
            }
            if (_valorAposta > _fundosAtuais && valorAumento > 0)
            {
                txtAviso.color = Color.red;
                txtAviso.text = "Sua aposta não pode ser maior do que seu saldo.";
                return;
            }
            
            txtAviso.gameObject.SetActive(false);
            AtualizarValorAposta(_valorAposta + valorAumento);
        }
        public void StartRandomizarNumero(int tipoNumero)
        {
            txtResultado.gameObject.SetActive(false);
            if (_fundosAtuais < 0)
                txtFundosJogador.text = $"R$ 0.00";
            
            if (_rodadasFeitas < numeroRodadas - 1 && _fundosAtuais > 0)
            {
               StartCoroutine(RandomizarNumero(tipoNumero));
               return;
            }
            btVoltarHigh.SetActive(true);
            btVoltarLow.SetActive(true);
        }
        private IEnumerator RandomizarNumero(int tipoNumero)
        {
            for (var i = 0; i < Random.Range(50, 100); i++)
            {
                var numeroRandomizado = Random.Range(0, numeroLimite);
                txtNumeroRandomizado.text = numeroRandomizado.ToString();
                yield return new WaitForSeconds(0.0075f);
            }

            do
            {
                _numeroRandomizado = Random.Range(0, numeroLimite);
            } while ((tipoNumero == 0 && _numeroRandomizado > _numeroHigh) || (tipoNumero == 1 && _numeroRandomizado < _numeroLow));
            txtNumeroRandomizado.text = _numeroRandomizado.ToString();

            DefinirResultado(tipoNumero);
        }
    }
}