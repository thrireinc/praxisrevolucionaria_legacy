namespace Game.S.Scripts.ScriptableObjects
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "QuebraCabecaObject", menuName = "ScriptableObjects/QuebraCabecaObject", order = 1)]
    public class QuebraCabecaObject : ScriptableObject
    {
        public int Id => id;
        public Sprite Icone
        {
            get => icone;
            set => icone = value;
        }

        [SerializeField] private int id;
        [SerializeField] private Sprite icone;
    }
}