namespace Game.S.Scripts.MVC.Controlador.Puzzles
{
    using UnityEngine;
    using View;
    
    public class ControladorPuzzleLabirinto : ControladorPuzzle
    {
        [SerializeField] private ObjetoParaMovimentar rato;
        [SerializeField] private Joystick joystick;

        private void Update()
        {
            rato.movimento = AlterarDirecao();
        }
        private Vector3 AlterarDirecao()
        {
            if (joystick.Vertical < -0.5 || joystick.Vertical > 0.5)
                return Vector3.up * Mathf.Sign(joystick.Vertical);
            
            if (joystick.Horizontal < -0.5 || joystick.Horizontal > 0.5)
                return Vector3.right * Mathf.Sign(joystick.Horizontal);

            return rato.movimento;
        }
    }
}