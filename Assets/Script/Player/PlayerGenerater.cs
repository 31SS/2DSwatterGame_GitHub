using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerater : MonoBehaviour
{
    [SerializeField] private List<GameObject> criterrionList;
    [SerializeField] private List<GameObject> blockList;
    private GameObject criterrion;
    private GameObject block;
    private int blockNumber;

    private void Awake()
    {
        blockNumber = 0;
        criterrion = criterrionList[0];
        block = blockList[0];
    }

    public void GenerateBlock()
    {
        Instantiate(block, transform.position, criterrion.transform.rotation);
    }

    public void ChangeBlock()
    {
        criterrionList[blockNumber].SetActive(false);
        if (blockNumber < blockList.Count - 1)
        {
            blockNumber++;
        }
        else
        {
            blockNumber = 0;
        }
        criterrionList[blockNumber].SetActive(true);
        criterrion = criterrionList[blockNumber];
        block = blockList[blockNumber];
    }
}
