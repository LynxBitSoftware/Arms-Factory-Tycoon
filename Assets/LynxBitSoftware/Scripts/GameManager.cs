using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // static instance of the GameManager
    public static GameManager instance;

    


    void Awake()
    {
        // if the instance variable is not set
        if (instance == null)
        {
            // set the instance variable to this object
            instance = this;
            // keep the object alive between scene changes
            DontDestroyOnLoad(gameObject);
        }
        // if the instance variable is already set to an object
        else
        {
            // destroy this object, as there can only be one instance of the GameManager
            Destroy(gameObject);
        }
    }
    [SerializeField]
    private bool canGetPaid = false;
    [SerializeField]
    private CurrencyController currency;
    [SerializeField]
    public float wins, loses, profit;
    [SerializeField]
    public int itemsStock, timeToPayPlayer;

    [SerializeField]
    private GameObject item_ui_gameobject;

    // Start is called before the first frame update
    void Start()
    {
        profit = 0;
        FindCurrencyController();
        //Test of salary
        //StartCoroutine(CoroutineToPayPlayer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DetermineWins()
    {

    }

    public void DetermineLoses() 
    { 
    
    }
    public void GivePlayerSalary() 
    {
        profit = wins - loses;
        currency.AddCurrencyCash(profit);
    }
    IEnumerator CoroutineToPayPlayer()
    {
        while (canGetPaid) 
        {
            GivePlayerSalary();
            yield return new WaitForSeconds(timeToPayPlayer);
        }

    }
    public void FindCurrencyController()
    {
        if (SceneManager.GetActiveScene().name == "TestScene") 
        {
            canGetPaid = true;
        }
    
    }
    /*
    public int GetIncomePerMin()
    {
        int conversion = profit * (60 / timeToPayPlayer);
        return conversion;
    }
    */
    //Por ahora solo convertimos hasta el B nos faltaria encontrar la manera de llegar mucho más lejos de manera más efectivas en un futuro
    public string ConvertValueForUI(float number) 
    {
        if (number >= 1000000000) // si el número es mayor o igual a 1.000.000.000 (1 mil millones)
        {
            return (number / 1000000000f).ToString("0.#") + "B"; // abreviamos a billones y retornamos
        }
        else if (number >= 1000000) // si el número es mayor o igual a 1.000.000 (1 millón)
        {
            return (number / 1000000f).ToString("0.#") + "M"; // abreviamos a millones y retornamos
        }
        else if (number >= 1000) // si el número es mayor o igual a 1.000 (1 mil)
        {
            return (number / 1000f).ToString("0.#") + "K"; // abreviamos a miles y retornamos
        }
        else // si el número es menor a 1.000
        {
            return Mathf.RoundToInt(number).ToString(); // retornamos el número sin abreviar
        }
    }
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

        public void itemUI()
    {
        if (item_ui_gameobject.activeSelf)
        {
            item_ui_gameobject.SetActive(false);
        }
        else
        {
            item_ui_gameobject.SetActive(true);
        }
    }
}
