using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : Singleton<GameControler>
{

    public GameObject CubePickup;
    public int pickuprate = 60;

    public int spawnX = 0;
    public int spawnY = 0;
    public int spawnZ = 0;

    private float _timeRemaining;
    public float TimeRemaining { get { return _timeRemaining; } set { _timeRemaining = value; } }

    private int _pickupsGathered;
    public int PickupsGathered { get { return _pickupsGathered; } set { _pickupsGathered = value; } }

    private float maxTime = 10;

    // Use this for initialization
    void Start()
    {
        TimeRemaining = maxTime;
        PickupsGathered = 0;
        CreatePickup();
        Player.Instance.Start();

    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining <= 0)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Start();
        }
    }

    void FixedUpdate()
    {
        if (Time.frameCount % pickuprate == 0) // create new pickup every 2nd update
            CreatePickup();
    }

    private void CreatePickup()
    {

        //GameObject newPickup = (GameObject)GameObject.Instantiate(CubePickup);

        //newPickup.transform.position = new Vector3(spawnX, spawnZ, spawnZ);
        PoolControl.Instance.SpawnFromPool("Pickup", new Vector3(spawnX, spawnZ, spawnZ), Quaternion.identity);

    }
}
