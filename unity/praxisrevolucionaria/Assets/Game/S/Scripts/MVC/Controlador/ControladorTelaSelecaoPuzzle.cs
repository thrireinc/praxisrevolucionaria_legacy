namespace Game.S.Scripts.MVC.Controlador
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControladorTelaSelecaoPuzzle : MonoBehaviour

    {
        public int IndexPuzzle {get; set;}
        [SerializeField] private Button btnIniciarPuzzle;
        [SerializeField] private ControladorCena controladorCena;
        [SerializeField] private TextMeshProUGUI txtsaude, txtlazer;

        private void Start()
        {
            btnIniciarPuzzle.onClick.RemoveAllListeners();
            btnIniciarPuzzle.onClick.AddListener(() => controladorCena.PassarCena(IndexPuzzle));
        }
        public void AlterarTextoSaude(int valor)
        {
            txtsaude.text = valor.ToString();
        }
        public void AlterarTextoLazer(int valor)
        {
            txtlazer.text = valor.ToString();
        }
    }
}