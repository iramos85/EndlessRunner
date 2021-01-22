﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] int lowerLimit = -2;
    [SerializeField] float offset = 2;

    void Update()
    {
        if (player.position.y >= lowerLimit)
        {
            //transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }
        }
    }
}
