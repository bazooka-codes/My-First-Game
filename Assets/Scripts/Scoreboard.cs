using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI speed;

    public float timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        score.text = timer.ToString("#.00");

        speed.text = player.velocity.x.ToString("#.00");
    }

    public void SetRecordTime(float newTime)
    {
        PlayerPrefs.SetFloat("RecordTime", newTime);
    }

    public float GetRecordTime()
    {
        return PlayerPrefs.GetFloat("RecordTime");
    }
}
