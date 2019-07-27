using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public ScrollRect scrollRc;
    float mapXSize = 100;
    float mapYSize = 100;
    public GameObject Player;
    public Image Monster;
    public RectTransform mobTr;

    // Start is called before the first frame update
    void Start()
    {
        scrollRc.normalizedPosition = new Vector2(0.5f, 0.5f);
        //mobTr.sizeDelta = new Vector2(20, 20);
        mobTr.anchoredPosition = new Vector2(20, 20);
    }

    Vector2 Get2DMapPosition()
    {
        Vector3 temp = Player.transform.position;
        temp.x += 50;
        temp.z += 50;
        float xRatio = temp.x / mapXSize;
        float zRatio = temp.z / mapYSize;

        Vector2 minimapPos = Vector2.zero;
        minimapPos.Set(xRatio, zRatio);
        return minimapPos;
    }
    // Update is called once per frame
    void Update()
    {
        scrollRc.normalizedPosition = Get2DMapPosition();
    }
}
