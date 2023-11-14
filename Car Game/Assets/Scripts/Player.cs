using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Slider gasSlider;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;
    public float gasLostPerSecond = 0.33f;
    public GameObject compass;
    public GameObject target;
    
    float overlapRadius = 3.0f;
    float money = 0.0f;
    float gasMax = 15.0f;
    float gas = 15.0f;
    PlayerMovement playerMovement;
    bool hasPassenger = false;
    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        compass.SetActive(false);
    }

    void Update()
    {
        //AddMoney(0.01f);
        if(target != null)
            UpdateCompass();
    }
    void OnInteract()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, overlapRadius))
        {
            if(collider.gameObject == gameObject)
                continue;
            if(collider.gameObject.tag == "Passenger" && !hasPassenger)
            {
                target = collider.gameObject.GetComponent<Passenger>().Pickup().gameObject;
                Destroy(collider.gameObject);
                compass.SetActive(true);
                hasPassenger = true;
            }
            if(collider.gameObject.tag == "Destination" && hasPassenger)
            {
                collider.gameObject.GetComponent<Destination>().Dropoff(this);
                compass.SetActive(false);
                hasPassenger = false;
            }
            if(collider.gameObject.tag == "GasPump")
            {
                collider.gameObject.GetComponent<GasPump>().BuyGas(this);
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
        moneyText.text = "$" + money.ToString("F2");
        moneyText2.text = "$" + money.ToString("F2");
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
    public float GetGas()
    {
        return gas;
    }
    public float GetGasMax()
    {
        return gasMax;
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
        gasSlider.value = gas/gasMax;
    }
}
