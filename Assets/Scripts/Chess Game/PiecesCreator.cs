using System;
using System.Collections.Generic;
using UnityEngine;


public class PiecesCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] piecesPrefabs;
    [SerializeField] private GameObject[] catsPrefabs;
    [SerializeField] private GameObject[] dogsPrefabs;

    [SerializeField] private Material blackMaterial;
    [SerializeField] private Material whiteMaterial;
    private Dictionary<string, GameObject> blackNameToPieceDict = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> whiteNameToPieceDict = new Dictionary<string, GameObject>();

    private List<string> pieceTypeList = new List<string> { "Rook", "Knight", "Bishop", "Queen", "King", "Pawn"};

private void Awake()
    {
        //foreach (var piece in piecesPrefabs)
        //{
        //    Debug.Log("piecestring: " + piece.GetComponent<Piece>().GetType().ToString() +  " piece: " + piece);
        //    nameToPieceDict.Add(piece.GetComponent<Piece>().GetType().ToString(), piece);
        //}

        foreach (var pieceType in pieceTypeList)
        {
            Debug.Log(pieceType);
            foreach (var piece in catsPrefabs)
            {
                string pieceString = piece.GetComponent<Piece>().GetType().ToString();
                Debug.Log("piecestring: " + pieceString + " pieceType: " + pieceType + " contains: " + pieceString.Contains(pieceType));
                if (pieceString.Contains(pieceType))
                {
                    blackNameToPieceDict.Add(pieceType, piece);
                }
            }
            foreach (var piece in dogsPrefabs)
            {
                string pieceString = piece.GetComponent<Piece>().GetType().ToString();
                Debug.Log("piecestring: " + pieceString + " pieceType: " + pieceType + " contains: " + pieceString.Contains(pieceType));
                if (pieceString.Contains(pieceType))
                {
                    whiteNameToPieceDict.Add(pieceType, piece);
                }
            }
        }
        Debug.Log(blackNameToPieceDict);
        Debug.Log(whiteNameToPieceDict);
    }

    public GameObject CreatePiece(Type type, TeamColor team)
    {
        if (team == TeamColor.Black)
        {
            GameObject prefab = blackNameToPieceDict[type.ToString()];
            if (prefab)
            {
                GameObject newPiece = Instantiate(prefab);
                return newPiece;
            }
        }
        else
        {
            GameObject prefab = whiteNameToPieceDict[type.ToString()];
            if (prefab)
            {
                GameObject newPiece = Instantiate(prefab);
                return newPiece;
            }
        }
        return null;
    }

    public Material GetTeamMaterial(TeamColor team)
    {
        return team == TeamColor.White ? whiteMaterial : blackMaterial;
    }
}
