using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
    [SerializeField] private MonsterSpawner _monsterSpawner;
    [SerializeField] private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    public void OnImageChanged (ARTrackedImagesChangedEventArgs args)
    {
        string _name;
        int _nameNum;

        foreach (var a in args.added)
        {
            _name = a.referenceImage.name;
            _nameNum = int.Parse (_name);//画像番号
            Debug.Log(_nameNum);
            Vector3 markerPos = a.transform.position;
            Quaternion qua = a.transform.rotation;
            _monsterSpawner.SpawningObject(_nameNum, markerPos, qua);
            _playerData._imageRead ++;
        }
    }
}