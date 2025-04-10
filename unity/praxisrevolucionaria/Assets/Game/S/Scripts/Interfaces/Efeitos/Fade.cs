namespace Game.S.Scripts.Interfaces.Efeitos
{
    using System;
    using UnityEngine;
    
    public class Fade : MonoBehaviour, IEfeitos
    {
        public void Efeito(CanvasGroup canvasGroupParaAplicarEfeito, Vector2 limitesDeEfeito, float tempoDeExecucacaoDaAcao)
        {
            var proximoAlfa = Math.Abs(canvasGroupParaAplicarEfeito.alpha - limitesDeEfeito.x) < 0.01f ? limitesDeEfeito.y : limitesDeEfeito.x;
            var objetoComEfeito = LeanTween.alphaCanvas(canvasGroupParaAplicarEfeito, proximoAlfa, tempoDeExecucacaoDaAcao);
            
            objetoComEfeito.setEaseInOutSine();
            objetoComEfeito.setIgnoreTimeScale(true);
        }
    }
}