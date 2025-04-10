namespace Game.S.Scripts.Interfaces.Efeitos
{
    using UnityEngine;

    public class Move : MonoBehaviour, IEfeitos
    {
        public void Efeito(CanvasGroup canvasGroupParaAplicarEfeito, Vector2 limitesDeEfeito, float tempoDeExecucacaoDaAcao)
        {
            var transformCanvasGroupParaAplicarEfeito = canvasGroupParaAplicarEfeito.GetComponent<RectTransform>();
            var objetoParaAplicarEfeito = LeanTween.move(transformCanvasGroupParaAplicarEfeito, limitesDeEfeito, tempoDeExecucacaoDaAcao);

            objetoParaAplicarEfeito.setEaseInOutSine();
            objetoParaAplicarEfeito.setIgnoreTimeScale(true);
        }
    }
}