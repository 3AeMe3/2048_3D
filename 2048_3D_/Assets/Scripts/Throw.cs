using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Throw : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] float speed;// Velocidad para el movimiento suave del cubo
    [SerializeField] float force;// Fuerza para el lanzamiento del cubo
    [SerializeField] float maxPosX;// Posición máxima en el eje X para el cubo

    public Cube currentCube;// Referencia al cubo actual


    bool isPressSlider;// para saber si se está presionando el slider
    Vector3 cubePos = Vector3.zero;// Posición objetivo del cubo
    Slider throwSlider;
    private void Awake()
    {
        throwSlider = GetComponent<Slider>();
    }
    private void Start()
    {
        cubePos = currentCube.transform.position;// Inicializar la posición objetivo del cubo
    }

    private void Update()
    {
        //Si se está presionando el slider
        if (isPressSlider && cubePos != Vector3.zero)
        {
            //Suavizar el movimiento del cubo hacia la posición objetivo
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, cubePos , speed * Time.deltaTime);
        }
    }
   
    /// <summary>
    /// Metodo para detectar cuando se presione el slider
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressSlider = true;   //se activa el booleano
    }

    /// <summary>
    /// Metodo para el lanzamiento del cubo
    /// </summary>
    /// <param name="value"> valor usado para la posicion en el eje X </param>
    public void DragSlider(float value)
    {
        cubePos = currentCube.transform.position;
        cubePos.x = value * maxPosX;//calcular la nueva posicion en el eje X
    }

    /// <summary>
    /// Metodo que detecta el momento en el que se suelta el slider 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressSlider = false; //desactiva el booleano
        currentCube.Throw(force); //lanza el cubo con la fuerza indicada
    }
}
