namespace Game.S.Scripts.MVC.Controlador
{
    using System;
    using UnityEngine;
    using View;
    using Enumeradores;
    using Interfaces.Movimentos;

    public class ControladorMovimento : MonoBehaviour
    {
        [SerializeField] private ObjetoParaMovimentar[] objetosParaMovimentar;

        private void Start()
        {
            foreach (var objetoParaMovimentar in objetosParaMovimentar)
                ConfigurarMovimento(objetoParaMovimentar);
        }
        private void ConfigurarMovimento(ObjetoParaMovimentar objetoParaMovimentar)
        {
            var gameObjectObjetoParaAplicarMovimento = objetoParaMovimentar.gameObject;
            
            objetoParaMovimentar.ReferenciaMovimento = objetoParaMovimentar.TipoMovimento switch
            {
                Movimentos.MovimentoEspacial => gameObjectObjetoParaAplicarMovimento.AddComponent<MovimentoEspacial>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}