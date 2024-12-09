using CodeBase.Generics;
using UnityEngine;

namespace CodeBase.Player
{
    public class Player : MonoBehaviour, ITeamable
    {
        [field: SerializeField]
        public Team Team { get; private set; }
    }
}