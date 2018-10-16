using UnityEngine;

public class Player : Singleton<Player>
{
    public GameObject self;
    public float speedTimeRemaining = 0f;
    public bool onSpeed = false;
    public float invinceTimeRemaining = 0f;
    public bool invince = false;

    [HideInInspector]
    public float orbSpeedMulti = 1.0f;
    public Transform start;
    public void Start()
    {
        gameObject.transform.position = SpawnPoint.Instance.gameObject.transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y < -5)
        {
            //SceneManager.LoadScene(0, LoadSceneMode.Single);
            Start();
        }

        if (onSpeed)
        {
            speedTimeRemaining -= Time.deltaTime;
            if (speedTimeRemaining < 0)
            {
                speedTimeRemaining = 0;
                onSpeed = false;
                orbSpeedMulti = 1.0f;
            }
        }
        if (invince)
        {
            invinceTimeRemaining -= Time.deltaTime;
            if (invinceTimeRemaining < 0)
            {
                invinceTimeRemaining = 0;
                invince = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            GameControler.Instance.PickupsGathered++;

            if (other.gameObject.transform.Find("InvincBox") != null)
            {
                invinceTimeRemaining = 5;
                invince = true;


                GameObject explosion = (GameObject)GameObject.Instantiate(other.gameObject.GetComponent<OnDestroyCreate>().destroyCreate);
                explosion.transform.position = other.gameObject.transform.position;
            }

            if (other.gameObject.transform.Find("SpeedBox") != null)
            {
                speedTimeRemaining = 5;
                onSpeed = true;
                orbSpeedMulti = 1.5f;

                GameObject explosion = (GameObject)GameObject.Instantiate(other.gameObject.GetComponent<OnDestroyCreate>().destroyCreate);
                explosion.transform.position = other.gameObject.transform.position;
            }

            other.gameObject.SetActive(false);
        }
    }
}
