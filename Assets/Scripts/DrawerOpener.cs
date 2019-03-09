using UnityEngine;

public class DrawerOpener : MonoBehaviour
{
    public GameObject drawerToUse;
    public bool drawerIsOpen;
    Animator drawerAnimator;
    AudioSource drawerSound;

    public delegate void clickAction(bool drawerState);
    public event clickAction OnClicked;

    void Start()
    {
        drawerAnimator = drawerToUse.GetComponent<Animator>();
        drawerSound = drawerToUse.GetComponent<AudioSource>();
        drawerIsOpen = false;
    }

    public void OpenDrawer()
    {
        drawerIsOpen = true;
        OperateDrawer();
    }

    public void CloseDrawer()
    {
        drawerIsOpen = false;
        OperateDrawer();
    }

    public void ToggleDrawer()
    {
        drawerIsOpen = !drawerIsOpen;
        OperateDrawer();
    }

    public void OperateDrawer()
    {
        drawerAnimator.SetTrigger("OpenDrawer");
        drawerSound.Play();
        if (OnClicked != null)
        {
            OnClicked(drawerIsOpen);
        }
    }
}
