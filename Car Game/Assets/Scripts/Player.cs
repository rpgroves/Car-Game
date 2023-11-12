using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] Slider gasSlider;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI moneyText2;
    [SerializeField] float gasLostPerSecond = 0.33f;
    [SerializeField] GameObject compass;
    [SerializeField] GameObject target;
    float overlapRadius = 3.0f;
    float money = 0.0f;
    float gasMax = 100.0f;
    float gas = 100.0f;
    float gasTimer = 0.0f;
    PlayerMovement playerMovement;
    bool hasRider = false;
    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        compass.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(gas);
        //AddMoney(0.01f);
        if(target != null)
            UpdateCompass();
    }
    void OnInteract()
    {
        Debug.Log("scanning!");
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, overlapRadius))
        {
            if(collider.gameObject == gameObject)
                continue;
            if(collider.gameObject.tag == "Rider" && !hasRider)
            {
                target = collider.gameObject.GetComponent<Rider>().Pickup().gameObject;
                Destroy(collider.gameObject);
                compass.SetActive(true);
                hasRider = true;
            }
            if(collider.gameObject.tag == "Destination" && hasRider)
            {
                collider.gameObject.GetComponent<Destination>().Dropoff(this);
                compass.SetActive(false);
                hasRider = false;
            }
        }
    }
    void UpdateCompass()
    {
        Vector3 direction = target.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        compass.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    public void ToggleCompass(bool b)
    {
        compass.SetActive(b);
    }
    public float GetMoney()
    {
        return money;
    }
    public void AddMoney(float m)
    {
        money += m;
        moneyText.text = "$" + money.ToString("F2");
        moneyText2.text = "$" + money.ToString("F2");
    }
    public void SubtractMoney(float m)
    {
        money -= m;
    }
    public void DecrementGas()
    {
        gas -= gasLostPerSecond;
        if(gas <= 0)
        {
            gas = 0;
            playerMovement.SetIsThereGas(false);
        }
        gasSlider.value = gas/gasMax;
    }
    public void FillGas(float g)
    {
        if(gas <= 0)
        {
            playerMovement.SetIsThereGas(true);
        }
        gas += g;
        if(gas > gasMax)
        {
            gas = gasMax;
        }
    }
}