using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyPathFinder : MonoBehaviour
    {
        [SerializeField] private Transform[] _escapePoints;

        public Vector3 FindPath(Transform playerTransform)
        {
            var bestScore = 0f;
            var bestPoint = Vector3.zero;
            
            foreach (var point in _escapePoints)
            {
                var distEnemyToPoint = Math.Abs((transform.position - point.position).sqrMagnitude);
                var distPlayerToPoint = Math.Abs((playerTransform.position - point.position).sqrMagnitude);
                var distEnemyToPlayer = Math.Abs((transform.position - playerTransform.position).sqrMagnitude);
            
                var score = distPlayerToPoint - distEnemyToPoint + distEnemyToPlayer;
                print(score);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestPoint = point.position;
                }
            }
            
            return bestPoint;
        }
    }
}