namespace Game.S.Scripts.Interfaces.Efeitos
{
    using UnityEngine;

    public class Expand : MonoBehaviour, IEfeitos
    {
        public void Efeito(CanvasGroup canvasGroupParaAplicarEfeito, Vector2 limitesDeEfeito, float tempoDeExecucacaoDaAcao)
        {
            var transformCanvasGroupParaAplicarEfeito = canvasGroupParaAplicarEfeito.GetComponent<RectTransform>();
            var objetoComEfeito = LeanTween.scale(transformCanvasGroupParaAplicarEfeito, limitesDeEfeito, tempoDeExecucacaoDaAcao); 
            objetoComEfeito.setEaseInOutSine();
            objetoComEfeito.setIgnoreTimeScale(true);
        }
    }
}