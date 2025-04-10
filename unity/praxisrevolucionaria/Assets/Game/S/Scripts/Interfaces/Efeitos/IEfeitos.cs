namespace Game.S.Scripts.Interfaces.Efeitos
{
    using UnityEngine;
    
    public interface IEfeitos
    {
        public void Efeito(CanvasGroup canvasGroupParaAplicarEfeito, Vector2 limitesDeEfeito, float tempoDeExecucacaoDaAcao);
    }
}