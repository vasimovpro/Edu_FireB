using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerScripts
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private float _towerSize;
        [SerializeField] private Transform _buildPoint;
        [SerializeField] private Block _block;

        private List<Block> _blocks;

        public List<Block> Build()
        {
            _blocks = new List<Block>();
            Transform currentPoint = _buildPoint;

            for (int i = 0; i < _towerSize; i++)
            {
                Block newBlock = BuildBlock(currentPoint);
                _blocks.Add(newBlock);
                currentPoint = newBlock.transform;
            }

            return _blocks;
        }

        private Block BuildBlock(Transform currentBuildPoint)
        {
            return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
        }

        private Vector3 GetBuildPoint(Transform currentSegment)
        {
            return new Vector3(_buildPoint.position.x,
                currentSegment.position.y +
                currentSegment.localScale.y / 2 +
                _block.transform.localScale.y / 2, _buildPoint.position.z);
        }
    }
}
