namespace Game.S.Scripts.MVC.Controlador
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControladorAtributo : MonoBehaviour
    {
        private IEnumerator AlterarValor(Slider sliderAtributo, float valorDeAlteracao, float tempoDaAcao)
        {
            var valor = valorDeAlteracao / tempoDaAcao;
            var valorAbsoluto = Mathf.Abs(valor);
            
            for (var x = 0.1f; x < valorAbsoluto; x++)
            {
                sliderAtributo.value += valor;
                yield return new WaitForSeconds(valorAbsoluto);
            }
        }
    }
}