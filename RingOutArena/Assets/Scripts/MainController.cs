using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MainController : MonoBehaviour
{
    public GameObject playerInfoPrefab, playerPointsArea;
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
        gameObject.GetComponent<TextMeshProUGUI>().text = ""+player.playerPoints;
    } 
}
