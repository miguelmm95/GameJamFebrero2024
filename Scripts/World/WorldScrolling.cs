using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terranTiles;

    [SerializeField] int tileHorizontalCount;
    [SerializeField] int tileVerticalCount;

    [SerializeField] int fielOfVisionHeight;
    [SerializeField] int fielOfVisionWidth;

    private void Awake()
    {
        terranTiles = new GameObject[tileHorizontalCount,tileVerticalCount];
    }

    private void Start()
    {
        UpdateTilesOnScreen();
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if(currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % tileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = tileHorizontalCount - 1 + currentValue % tileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % tileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = tileVerticalCount - 1 + currentValue % tileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    private void UpdateTilesOnScreen()
    {
        for(int pov_x = -(fielOfVisionWidth/2); pov_x <= fielOfVisionWidth/2; pov_x++)
        {
            for (int pov_y = -(fielOfVisionHeight/2); pov_y <= fielOfVisionHeight/2; pov_y++)
            {
                int tileToUpdate_X = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_Y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terranTiles[tileToUpdate_X, tileToUpdate_Y];
                tile.transform.position = CalculateTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    internal void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terranTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
