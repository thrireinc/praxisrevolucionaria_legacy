namespace Game.S.Scripts.MVC.Controlador.Tutorial
{
    using System;
    using UnityEngine;
    using Model;
    
    public class ControladoTutorialDialogo : MonoBehaviour
    {
        [SerializeField] private ControladorAtivarDialogo[] controladorAtivarDialogos;
        
        private void Start()
        {
            var tutorialRealizado = Convert.ToBoolean(Dados.CarregarDado(Diretorios.SavePath + "/tutorial.save", true));
            for (var i = 0; i < 2; i++)
            {
                var objetoControladorAtivarDialogo = controladorAtivarDialogos[i].gameObject;
                objetoControladorAtivarDialogo.SetActive(i == 0 ? !tutorialRealizado : tutorialRealizado);
            }
        }
    }
}