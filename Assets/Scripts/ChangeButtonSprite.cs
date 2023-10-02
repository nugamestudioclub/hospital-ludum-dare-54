using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    
    [SerializeField] private RoomSystem _roomSystem;
    [Space]
    [SerializeField] private Button _giveRoomButton;
    [SerializeField] private Image _giveRoomImage;
    [SerializeField] private Sprite _giveRoomX;
    [SerializeField] private Sprite _giveRoomEmpty;
    [Space]
    [SerializeField] private Button _waitlistButton;
    [SerializeField] private Image _waitlistImage;
    [SerializeField] private Sprite _waitlistX;
    [SerializeField] private Sprite _waitlistEmpty;


    private void Update()
    {
        Debug.Log(_roomSystem.getWaitlist().Count);
        if (_roomSystem.hasVacantRoom() == null)
        {
            _giveRoomImage.sprite = _giveRoomX;
            _giveRoomButton.interactable = false;

            if (_roomSystem.getWaitlist().Count > 4)
            {
                _waitlistImage.sprite = _waitlistX;
                _waitlistButton.interactable = false;
            }
        }
        else
        {
            _giveRoomImage.sprite = _giveRoomEmpty;
            _giveRoomButton.interactable = true;
        }

        if (_roomSystem.getWaitlist().Count < 5)
        {
            _waitlistImage.sprite = _waitlistEmpty;
            _waitlistButton.interactable = true;
        }
    }

}
