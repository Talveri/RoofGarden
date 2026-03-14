using UnityEngine;
using UnityEngine.UIElements;

public class PaperNavigation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button nextButton;
    private UIDocument uiDocument;
    public Camera mainCamera;
    public Transform cameraPosition;
    void Start()
    {
        //Configure Button
        uiDocument = GetComponent<UIDocument>();
        nextButton = uiDocument.rootVisualElement.Q<Button>("nextDayButton");
        nextButton.clicked += nextDay;

        // Set Cameraposition
        cameraPosition.position = new Vector3(cameraPosition.position.x,
                                      cameraPosition.position.y,
                                      mainCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void nextDay()
    {
        moveCamera();
    }

    void moveCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition.position;
        }
    }
}
