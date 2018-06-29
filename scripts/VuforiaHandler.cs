// Source: https://developer.vuforia.com
//        /forum/faq/unity-load-dataset-setup-trackables-runtime

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaHandler : MonoBehaviour {

    public string dataSetName = "";  //  Assets/StreamingAssets/QCAR/DataSetName
    int counter;

    // Use this for initialization
    void Start()
    {
        // Vuforia 6.2+
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(LoadDataSet);
    }

    void LoadDataSet()
    {

        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

        DataSet dataSet = objectTracker.CreateDataSet();

        if (dataSet.Load(dataSetName)) {

            objectTracker.Stop();  // stop tracker so that we can add new dataset

            if (!objectTracker.ActivateDataSet(dataSet)) {
                Debug.Log("<color=yellow>Failed to Activate DataSet: " + dataSetName + "</color>");
            }

            if (!objectTracker.Start()) {
                Debug.Log("<color=yellow>Tracker Failed to Start.</color>");
            }

            IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
            foreach (TrackableBehaviour tb in tbs) {
                if (tb.name == "New Game Object") {
                    // change generic name to include trackable name
                    tb.gameObject.name = tb.TrackableName;

                    tb.transform.localScale = Vector3.one;

                    // add additional script components for trackable
                    tb.gameObject.AddComponent<AromaTrackableEventHandler>();
                    tb.gameObject.AddComponent<TurnOffBehaviour>();

                }
            }
        } else {
            Debug.LogError("<color=yellow>Failed to load dataset: '" + dataSetName + "'</color>");
        }
    }
}
