using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int mCaught;
    public int mTot;
    public TMP_Text monkeyCount;
    public Slider s; 
    public PlayerMove player;
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
        mTot = 5;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
