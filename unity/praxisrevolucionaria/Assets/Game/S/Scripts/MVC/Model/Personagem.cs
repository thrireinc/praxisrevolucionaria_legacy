namespace Game.S.Scripts.MVC.Model
{
    using UnityEngine;

    public class Personagem : MonoBehaviour
    {
        public static string[] Personagens = {"Douglas", "Gislene"};
        
        public static void Alterar(int indexPersonagem)
        {
            PlayerPrefs.SetInt("PersonagemAtual", indexPersonagem);
        }
    }
}