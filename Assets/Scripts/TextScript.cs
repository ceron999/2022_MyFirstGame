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
        //��ź�� ������ 0���� ŭ && �ش� Ÿ�Ͽ� ��ź x && �ش� Ÿ���� �̹� ���� ������ �� ��ź ���� ǥ��
        if (tileScript.flagCount > 0 && !tileScript.isBomb && tileScript.isOpen)
        {
            countText.text = tileScript.flagCount.ToString();
        }
    }
}
