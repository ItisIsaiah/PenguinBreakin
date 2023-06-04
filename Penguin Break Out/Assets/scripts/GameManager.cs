using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public int mCaught;
    public int mTot;
    public TMP_Text monkeyCount;
    public GameObject EndGameUI;
    public Slider s; 
    public PlayerMove player;

    LevelScriptableObject myLev;
    // Start is called before the first frame update


    #region SingleTon
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion


    void Start()
    {
        mCaught = 0;
        mTot = 3;
      //  mTot = myLev.monkeysRequired;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        EndGameUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mCaught == mTot)
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel()
    {
        EndGameUI.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        myLev.Completed = true;
        SuperGameManager.Instance.copyData(myLev);
        SceneManager.LoadScene("HubWorld");
    }

    private void FixedUpdate()
    {
        s.value = player.health;
    }

    public void UpdateUI()
    {
        s.value = player.health;
        monkeyCount.text = mCaught + "/" + mTot;
    }

    public void AddScore(string monName)
    {
        mCaught++;
       /* if(!myLev.uniqueMonkeys.Contains(monName))
            myLev.uniqueMonkeys.Add(monName);
            myLev.uniqueCaughtNum = myLev.uniqueMonkeys.Count;
        UpdateUI();
       */
    }
}
