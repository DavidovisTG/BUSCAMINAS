using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [SerializeField] private int x, y;
    [SerializeField] private bool bomb, seen;

    public void setX(int x) { this.x = x; }

    public void setY(int y) { this.y = y; }

    public void setBomb(bool hasBomb) { this.bomb = hasBomb; }

    public int getX() { return this.x; }
    public int getY() { return this.y; }
    public bool hasBomb() { return this.bomb; }

    public bool isSeen() { return this.seen; }
    public void setSeen(bool seen) { this.seen = seen; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.gameOver)
            DrawBomb();
    }



    //Dibujar bandera con clic secundario
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Poner banderita en casilla
        }
    }


    public void DrawBomb()
    {
        if (!isSeen())
        {
            setSeen(true);
            if (hasBomb())
            {
                GetComponent<SpriteRenderer>().material.color = Color.red;
                transform.GetChild(1).gameObject.SetActive(true);
                
                //Añadir sprite de bomba

                //Terminar juego
                GameManager.instance.gameOver = true;
            }
            else
            {
                //Cambiar a color oscuro
                GetComponent<SpriteRenderer>().material.color = Color.grey;
                int bombs = Generator.instance.GetBombsAround(x, y);
                if (bombs == 0)
                    Generator.instance.CheckPiecesAround(x, y);
                else
                    transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bombs.ToString();

            }
        }
            
    }

    /*/ Update is called once per frame
    void Update()
    {
        
    }*/
}
