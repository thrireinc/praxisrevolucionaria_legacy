namespace Game.S.Scripts.MVC.Controlador.Tutorial
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using Model;
    using View;

    public class ControladorTutorialPuzzles : MonoBehaviour
    {
        [SerializeField] private AplicarEfeito[] ativadoresPuzzle;
        [SerializeField] private ControladorTelaSelecaoPuzzle controladorTelaSelecaoPuzzle;
        [SerializeField] private GameObject painelTutorialTutorial;
        [SerializeField] private GameObject btPassarTutorialDouglas, btPassarTutorialGislene;

        private void Awake()
        {
            var tutorialTutorialRealizado = Convert.ToBoolean(Dados.CarregarDado(Diretorios.SavePath + "/TutorialTutorial.save", true));
            var tutorialRealizado = Convert.ToBoolean(Dados.CarregarDado(Diretorios.SavePath + "/Tutorial.save", true));

            if (tutorialTutorialRealizado)
                painelTutorialTutorial.SetActive(false);

            for (var i = 0; i < ativadoresPuzzle.Length; i++)
            {
                var trigger = ativadoresPuzzle[i].GetComponent<EventTrigger>();
                var triggers = trigger.triggers;
                var entry = new EventTrigger.Entry {eventID = EventTriggerType.PointerDown};
                var callback = entry.callback;
                var i1 = i;

                if (tutorialRealizado)
                {
                    callback.AddListener((data) => {OnPointerDownDelegate(i1 + 9);});
                    triggers.Add(entry);
                    btPassarTutorialGislene.SetActive(true);
                    continue;
                }
            
                callback.AddListener((data) => {OnPointerDownDelegate(i1 + 6);});
                triggers.Add(entry);
                btPassarTutorialDouglas.SetActive(true);
            }
        }
        private void OnPointerDownDelegate(int index)
        {
            var gameObjectControladorTelaSelecaoPuzzle = controladorTelaSelecaoPuzzle.gameObject;
            controladorTelaSelecaoPuzzle.IndexPuzzle = index;
            gameObjectControladorTelaSelecaoPuzzle.SetActive(true);
        }
    }  
}