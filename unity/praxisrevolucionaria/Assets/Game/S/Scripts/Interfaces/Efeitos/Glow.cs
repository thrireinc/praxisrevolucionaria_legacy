namespace Game.S.Scripts.Interfaces.Efeitos
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class Glow : MonoBehaviour, IEfeitos
    {
        public void Efeito(CanvasGroup canvasGroupParaAplicarEfeito, Vector2 limitesDeEfeito, float tempoDeExecucacaoDaAcao)
        {
            var imagemCanvas = canvasGroupParaAplicarEfeito.GetComponent<Image>();
            var transformCanvas = canvasGroupParaAplicarEfeito.GetComponent<RectTransform>();
            var corImagemCanvas = imagemCanvas.color; 
            var cor = Math.Abs(corImagemCanvas.r - limitesDeEfeito.x) < 0.01f ? limitesDeEfeito.y : limitesDeEfeito.x;
            var proximaCor = new Color(cor, cor, cor);
            var objetoComEfeito = LeanTween.color(transformCanvas, proximaCor, tempoDeExecucacaoDaAcao);
            
            objetoComEfeito.setEaseInOutSine();
            objetoComEfeito.setIgnoreTimeScale(true);
        }
    }
}