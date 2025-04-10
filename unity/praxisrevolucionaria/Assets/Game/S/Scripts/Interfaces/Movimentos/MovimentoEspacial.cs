namespace Game.S.Scripts.Interfaces.Movimentos
{
    using UnityEngine;

    public class MovimentoEspacial : MonoBehaviour, IMovimentos
    {
        public void Movimento(Rigidbody2D rigidbodyParaMovimentar, Vector2 movimento)
        {
            rigidbodyParaMovimentar.position += movimento;
        }
    }
}