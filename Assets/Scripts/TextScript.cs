using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject tile;
    public Tile tileScript;
    public TextMesh countText;

    private void Awake()
    {
        countText = GetComponent<TextMesh>();
        tileScript = tile.GetComponent<Tile>();
    }

    private void Update()
    {
        //폭탄의 개수가 0보다 큼 && 해당 타일에 폭탄 x && 해당 타일이 이미 열린 상태일 때 폭탄 개수 표현
        if (tileScript.flagCount > 0 && !tileScript.isBomb && tileScript.isOpen)
        {
            countText.text = tileScript.flagCount.ToString();
        }
    }
}
