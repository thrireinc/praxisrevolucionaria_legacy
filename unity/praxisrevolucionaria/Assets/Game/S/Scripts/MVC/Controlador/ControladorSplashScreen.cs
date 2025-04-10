namespace Game.S.Scripts.MVC.Controlador
{
    using UnityEngine;
    using Model;

    public class ControladorSplashScreen : MonoBehaviour
    {
        [SerializeField] private GameObject[] objetosParaNaoDestruir;
        
        private void Start()
        {
            Diretorios.CriarDiretoriosEssenciais();

            foreach (var objetoParaNaoDestruir in objetosParaNaoDestruir)
                DontDestroyOnLoad(objetoParaNaoDestruir);
            
            if (!PlayerPrefs.HasKey("PersonagemAtual"))
                PlayerPrefs.SetInt("PersonagemAtual", 0);
        }
    }
}