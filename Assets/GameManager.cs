using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;                                                 // EventSystems를 다룰 경우 네임스페이스에 선언
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public long money;                                                          // 소지금 변수 선언
    public long moneyIncreaseAmount;                                            // 소지금 증가값 변수 선언
    public TextMeshProUGUI textMoney;                                           // 소지금 증가값 텍스트 변수 선언

    public long moneyIncreaseLevel;                                             // 레벨 증가값 변수 선언
    public long moneyIncreasePrice;                                             // 업그레이드 가격 비용 변수 선언
    public TextMeshProUGUI textPrice;                                           // 업그레이드 비용 텍스트 변수 선언

    public Button buttonPrice;                                                  // 단가 업그레이드 버튼 변수 선언

    public GameObject prefabMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0))                                        // 마우스 버튼을 눌렀을 	
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)         // UI 위에 있지 않을 	
            {
                money += moneyIncreaseAmount;                                   // 소지금을 소지금 증가량만큼 증가시키기
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(prefabMoney, mousePosition, Quaternion.identity);
            }
        }
    }

    void UpdatePanelText()
    {
        textPrice.text = "Lv." + moneyIncreaseLevel + " 단가 상승\n\n";
        textPrice.text += "외주 당 단가>\n";
        textPrice.text += moneyIncreaseAmount.ToString("###,###") + " 원\n";
        textPrice.text += "업그레이드 가격>\n";
        textPrice.text += moneyIncreasePrice.ToString("###,###") + " 원";
    }

    public void UpgradePrice()
    {
        if(money >= moneyIncreasePrice)
        {
            money -= moneyIncreasePrice;
            moneyIncreaseLevel += 1;
            moneyIncreaseAmount += moneyIncreaseLevel * 100;
            moneyIncreasePrice += moneyIncreaseLevel * 500;
        }
    }

    void ButtonActiveCheck()
    {
        if(money >= moneyIncreasePrice)
        {
            buttonPrice.interactable = true;
        }
        else
        {
            buttonPrice.interactable = false;
        }
    }

    void ShowInfo()
    {
        if(money == 0)
            textMoney.text = "0;";

        else
            textMoney.text = money.ToString("###,###") + "원";
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
        MoneyIncrease();
        UpdatePanelText();
        ButtonActiveCheck();
    }
}
