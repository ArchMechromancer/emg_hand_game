using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float speed;
    public points pontos;

    void Start()
    {
        pontos = FindObjectOfType<points>();
    }
    void Update()
    {
        speed = PlayerPrefs.GetFloat("CoinSpeed", 2);
        transform.position += Vector3.left *speed * Time.deltaTime;

    }
    
    void OnTriggerEnter(Collider colisor)
    {
        //incrementa pontuação + total de moedas ao colidir com o peixe
        if (colisor.gameObject.name == "fishie")
        {
            pontos.score++;
            pontos.total++;
            pontos.scoreText.text = pontos.score.ToString() + "/" + pontos.total.ToString();
            pontos.precision.text = "Score:" + pontos.score.ToString() + "/" + pontos.total.ToString() + "\n" + ((float)pontos.score / (float)pontos.total).ToString("P");
            pontos.precision2.text = "Score:" + pontos.score.ToString() + "/" + pontos.total.ToString() + "\n" + ((float)pontos.score / (float)pontos.total).ToString("P");
            Destroy(this.gameObject);
        }
        //incrementa apenas o total de moedas ao passar pelo contador
        if (colisor.gameObject.name == "contador")
        {
            
            pontos.total++;
            pontos.scoreText.text = pontos.score.ToString() + "/" + pontos.total.ToString();
            pontos.precision.text = "Score:" + pontos.score.ToString() + "/" + pontos.total.ToString() + "\n" + ((float)pontos.score / (float)pontos.total).ToString("P");
            pontos.precision2.text = "Score:" + pontos.score.ToString() + "/" + pontos.total.ToString() + "\n" + ((float)pontos.score / (float)pontos.total).ToString("P");

        }
    }
}
