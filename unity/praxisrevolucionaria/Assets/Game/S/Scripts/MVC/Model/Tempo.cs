namespace Game.S.Scripts.MVC.Model
{
    using System;
    using System.Collections;
    using UnityEngine;
    
    public static class Tempo
    {
        public static void ExecutarAcaoAposTemporizador(this MonoBehaviour mono, Action acaoParaExecutar, float tempoParaEsperarAntesDeExecutarAcao)
        {
            mono.StartCoroutine(ExecutarAcaoAposTemporizadorCoroutine(acaoParaExecutar, tempoParaEsperarAntesDeExecutarAcao));
        }
        public static void ExecutarAcaoAposTemporizador<T>(this MonoBehaviour mono, Action<T> acaoParaExecutar, float tempoParaEsperarAntesDeExecutarAcao, T parametroDaAcao)
        {
            mono.StartCoroutine(ExecutarAcaoAposTemporizadorCoroutine(acaoParaExecutar, tempoParaEsperarAntesDeExecutarAcao, parametroDaAcao));
        }
        private static IEnumerator ExecutarAcaoAposTemporizadorCoroutine(Action acaoParaExecutar, float tempoParaEsperarAntesDeExecutarAcao)
        {
            yield return new WaitForSeconds(tempoParaEsperarAntesDeExecutarAcao);
            acaoParaExecutar();
        }
        private static IEnumerator ExecutarAcaoAposTemporizadorCoroutine<T>(Action<T> acaoParaExecutar, float tempoParaEsperarAntesDeExecutarAcao, T parametroDaAcao)
        {
            yield return new WaitForSeconds(tempoParaEsperarAntesDeExecutarAcao);
            acaoParaExecutar(parametroDaAcao);
        }
    }
}