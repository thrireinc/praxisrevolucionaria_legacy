namespace Game.S.Scripts.MVC.Controlador
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControladorStatus : MonoBehaviour
    {
        [SerializeField] private int indexDadoSaude, indexDadoLazer;
        [SerializeField] private Sprite[] emocoesDouglas, emocoesGislene;
        [SerializeField] private Image imgEmocao;
        [SerializeField] private Slider sldrLazer, sldrSaude;
        [SerializeField] private ControladorDados controladorDados;
        private Sprite[][] _emocoes;

        private void Start()
        {
            _emocoes = new[] {emocoesDouglas, emocoesGislene};
        }

        private void OnEnable()
        {
            Configurar();
        }

        private void Configurar()
        {
            var valorSaude = Convert.ToInt32(controladorDados.CarregarObjetoRetornar(indexDadoSaude));
            var valorLazer = Convert.ToInt32(controladorDados.CarregarObjetoRetornar(indexDadoLazer));

            if (valorSaude > sldrSaude.maxValue)
                sldrSaude.maxValue = valorSaude;

            if (valorLazer > sldrLazer.maxValue)
                sldrLazer.maxValue = valorLazer;
            
            sldrSaude.value = valorSaude;
            sldrLazer.value  = valorLazer;

            var mediaSaudeLazer = (sldrLazer.value + sldrSaude.value) / 2;
            var indexEmocao = mediaSaudeLazer < 25 ? 0 : mediaSaudeLazer >= 25 && mediaSaudeLazer < 50 ? 1 : mediaSaudeLazer >= 50 && mediaSaudeLazer < 75 ? 2 : 3;
            imgEmocao.sprite = _emocoes[PlayerPrefs.GetInt("Personagem Atual")][indexEmocao];
        }
    }
}