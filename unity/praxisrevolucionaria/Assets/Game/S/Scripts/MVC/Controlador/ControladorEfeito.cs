namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;
    using Interfaces.Efeitos;
    using Enumeradores;
    using View;
    
    public class ControladorEfeito : MonoBehaviour
    {
        [SerializeField] private AplicarEfeito[] itensParaAplicarEfeito;

        private void Start()
        {
            foreach (var itemParaAplicarEfeito in itensParaAplicarEfeito)
                DefinirTipoEfeito(itemParaAplicarEfeito);
        }
        private void DefinirTipoEfeito(AplicarEfeito itemParaAplicarEfeito)
        {
            var gameObjectObjetoParaAplicarEfeito = itemParaAplicarEfeito.gameObject;
            
            itemParaAplicarEfeito.ReferenciaEfeito = itemParaAplicarEfeito.TipoEfeito switch
            {
                Efeitos.Glow => gameObjectObjetoParaAplicarEfeito.AddComponent<Glow>(),
                Efeitos.Fade => gameObjectObjetoParaAplicarEfeito.AddComponent<Fade>(),
                Efeitos.Expand => gameObjectObjetoParaAplicarEfeito.AddComponent<Expand>(),
                Efeitos.Move => gameObjectObjetoParaAplicarEfeito.AddComponent<Move>(),
                _ => itemParaAplicarEfeito.ReferenciaEfeito
            };
        }
    }
}