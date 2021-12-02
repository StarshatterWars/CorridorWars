using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    private RangerWars grGlobals;
    private float calcDistPercent;
    private float calcDist;

    public Text gameDist;

    void Awake()
    {
        grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
    }

    // Use this for initialization
    void Start()
    {
        calcDist = grGlobals.m_missionLength - grGlobals.displayDist;
        if (calcDist <= 0) calcDist = 0;
        gameDist.text = Mathf.RoundToInt(calcDist).ToString();
        calcDistPercent = (grGlobals.m_missionLength - grGlobals.displayDist) / grGlobals.m_missionLength;

        if (calcDistPercent > 0.66f) gameDist.color = Color.red;
        else if (calcDistPercent > 0.33f && calcDistPercent <= 0.66f) gameDist.color = Color.yellow;
        else gameDist.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        calcDist = grGlobals.m_missionLength - grGlobals.displayDist;
        if (calcDist <= 0) calcDist = 0;
        gameDist.text = Mathf.RoundToInt(calcDist).ToString();

        calcDistPercent = (grGlobals.m_missionLength - grGlobals.displayDist) / grGlobals.m_missionLength;

        if (calcDistPercent > 0.66f) gameDist.color = Color.red;
        else if (calcDistPercent > 0.33f && calcDistPercent <= 0.66f) gameDist.color = Color.yellow;
        else gameDist.color = Color.green;
    }
}
