using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEditor;

public class MainController : MonoBehaviour
{
    public GameObject playerInfoPrefab, playerPointsArea;
    public int pointsToWin = 5;
    [HideInInspector] public bool gameStart = false;
    [HideInInspector] public List<PlayerInfo> players;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void OnPlayerJoined(PlayerInput player)
    {
        PlayerInfo p = player.gameObject.GetComponent<PlayerInfo>();
        p.playerID = PlayerInputManager.instance.playerCount - 1;
        p.playerName = "P" + (p.playerID + 1);
        GameObject playerInfo = Instantiate(playerInfoPrefab, playerPointsArea.transform);
        playerInfo.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = p.playerName;
        OrganizePlayerInfos();
        p.main = this;
        players.Add(p);
        switch (players.Count)
        {
            case 1:
                p.bodyMaterial.material.color = Color.red;
                break;
            case 2:
                p.bodyMaterial.material.color = Color.blue;
                break;
            case 3:
                p.bodyMaterial.material.color = Color.green;
                break;
            case 4:
                p.bodyMaterial.material.color = Color.yellow;
                break;
        }
    }

    void OrganizePlayerInfos()
    {
        switch (playerPointsArea.transform.childCount)
        {
            case 1:
                playerPointsArea.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 0;
                break;
            case 2:
                playerPointsArea.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 200;
                playerPointsArea.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = Vector2.left * -200;
                break;
            case 3:
                playerPointsArea.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 400;
                playerPointsArea.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 0;
                playerPointsArea.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = Vector2.left * -400;
                break;
            case 4:
                playerPointsArea.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 600;
                playerPointsArea.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = Vector2.left * 200;
                playerPointsArea.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = Vector2.left * -200;
                playerPointsArea.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = Vector2.left * -600;
                break;
            default:
                break;
        }
    }

    public void UpdatePlayerScore(PlayerInfo player)
    {
        playerPointsArea.transform.GetChild(player.playerID).GetChild(0).GetChild(1).
        gameObject.GetComponent<TextMeshProUGUI>().text = "" + player.playerPoints;
        if (player.playerPoints >= pointsToWin) WinGame(player);
    }

    public void bt_BeginGame()
    {
        gameStart = true;
        foreach (PlayerInfo p in players)
        {
            p.ChangeInputMap(0);
        }

        for (int i = 0; i < players.Count; i++)
        {
            float angle = i * Mathf.PI * 2 / players.Count;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 4;
            players[i].transform.position = pos;
        }

    }

    public void WinGame(PlayerInfo player)
    {
        Debug.Log("Vencedor é: " + player.playerName);
        foreach (PlayerInfo p in players)
        {
            Debug.Log("Pontos de " + p.playerName + " : " + p.playerPoints);
        }
    }

    public void bt_SetPlayerClass(PlayerClassInfo classInfo)
    {
        Debug.Log(classInfo.className);
        //chamar playerInfo.UpdateClassValues(classInfo); identificando o playerInfo correto.
        //chamar a imagem da area usando o playerInfo.playerID
    }
}
