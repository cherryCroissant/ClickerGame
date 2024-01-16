using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMove : MonoBehaviour
{
    public Vector2 point;
    TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = transform.GetComponentInChildren<TextMeshProUGUI>();

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        txt.text = "+" + gm.moneyIncreaseAmount.ToString("###,###");

        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 5f);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);

        txt = transform.GetComponentInChildren<TextMeshProUGUI>();
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - 0.01f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }
}
