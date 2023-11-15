using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int totalPets;
    public int curPets;
    private bool isPlaying;
    public float speedIncrease = 0.5f;
    public GameObject playButton;
    public TextMeshProUGUI curTimeText;

    void Awake()
    {
       // rig = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(!isPlaying)
            return;

        transform.Rotate(Vector3.up * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed += speedIncrease;
            curPets++;
        }
        //float x = Input.GetAxis("Horizontal") * speed;
        //float z = Input.GetAxis("Vertical") * speed;

        //rig.velocity = new Vector3(x, rig.velocity.y, z);

        curTimeText.text = curPets.ToString();
    }


    public void Begin()
    {
        isPlaying = true;
        curPets = 0;
        speed = 0;
        transform.rotation = Quaternion.identity;
        playButton.SetActive(false);
    }

    public void End()
    {
        isPlaying = false;
        playButton.SetActive(true);
        Leaderboard.instance.SetLeaderboardEntry(curPets);
    }

}
