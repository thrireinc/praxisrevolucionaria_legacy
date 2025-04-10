using System;
using System.Collections;
using System.Collections.Generic;
using Game.S.Scripts.MVC.Controlador;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorFinancas : MonoBehaviour
{
    [SerializeField] private int indexDado;
    [SerializeField] private TextMeshProUGUI txtFinancas;
    [SerializeField] private ControladorDados controladorDados;
    [SerializeField] private float tempoEfeito;
    
    private void Start()
    {
        StartAtualizarFinancas();
    }

    public void StartAtualizarFinancas()
    {
        StartCoroutine(AtualizarFinancas());
    }

    private IEnumerator AtualizarFinancas()
    {
        yield return new WaitForSeconds(tempoEfeito);
        var financasAtuais = Convert.ToInt32(controladorDados.CarregarObjetoRetornar(indexDado));

        for (var i = 1; i <= financasAtuais; i++)
        {
            txtFinancas.text = i.ToString();
            yield return new WaitForSeconds(0.085f);
        }
    }
}
