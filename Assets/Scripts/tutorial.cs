using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] GameObject Element0;
    [SerializeField] GameObject Element1;
    [SerializeField] GameObject Element2;
    [SerializeField] GameObject Element3;
    [SerializeField] GameObject Element4;
    // Start is called before the first frame update
    void Start()
    {
        ChangeView(0);
        Invoke(nameof(DelayMethod), 3.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeView(int a)
    {
        if (a == 0)
        {
            Element0.SetActive(true);
            Element1.SetActive(false);
            Element2.SetActive(false);
            Element3.SetActive(false);
            Element4.SetActive(true);
        }
        else if (a == 1)
        {
            Element0.SetActive(false);
            Element1.SetActive(true);
            Element2.SetActive(true);
            Element3.SetActive(false);
            Element4.SetActive(true);
        }
        else if (a == 2)
        {
            Element0.SetActive(false);
            Element1.SetActive(false);
            Element2.SetActive(true);
            Element3.SetActive(true);
            Element4.SetActive(false);
        }
    }
    public void change_button()
    {
        ChangeView(2);
    }
    void DelayMethod()
    {
        ChangeView(1);
    }

    private void OnDestroy()
    {
        // DestroyŽž‚É“o˜^‚µ‚½Invoke‚ð‚·‚×‚ÄƒLƒƒƒ“ƒZƒ‹
        CancelInvoke();
    }
}