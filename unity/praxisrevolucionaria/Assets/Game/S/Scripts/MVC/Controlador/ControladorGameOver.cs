namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ControladorGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject painelGameover;
        [SerializeField] private Text txtFinal;
        [SerializeField] private Button btnGanhou, btnPerdeu;

        public void Gameover(bool ganhouPuzzle)
        {
            painelGameover.SetActive(true);
        
            if (ganhouPuzzle)
            {
                btnGanhou.gameObject.SetActive(true);
                txtFinal.text = "Vitória!";
                return;
            }

            btnPerdeu.gameObject.SetActive(true);
            txtFinal.text = "Derrota!";
        }
    }
}