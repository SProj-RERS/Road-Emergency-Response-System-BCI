using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EmotivUnityPlugin;
using Zenject;

namespace dirox.emotiv.controller
{
    /// <summary>
    /// Responsible for subscribing and displaying data
    /// we support for eeg, performance metrics, motion data at this version.
    /// </summary>
    public class DataSubscriber : BaseCanvasView
    {
        DataStreamManager _dataStreamMgr = DataStreamManager.Instance;

        [SerializeField] private Text  eegHeader;     // header of eeg data exclude MARKERS
        [SerializeField] private Text  eegData;      // eeg data stream
        [SerializeField] private Text  motHeader;    // header of motion data
        [SerializeField] private Text  motData;      // motion data 
        [SerializeField] private Text  pmHeader;     // header of performance metric data
        [SerializeField] private Text  pmData;       // performance metric data
        StringBuilder sb = new StringBuilder();

        float _timerDataUpdate = 0;
        const float TIME_UPDATE_DATA = 1f;
        
        void Start()
        {
            
            string header = 
                "Timestamp"+","+
                "EEG.AF3"+","+
                "EEG.F7"+","+
                "EEG.F3"+","+
                "EEG.FC5"+","+
                "EEG.T7"+","+
                "EEG.P7"+","+
                "EEG.O1"+","+
                "EEG.O2"+","+
                "EEG.P8"+","+
                "EEG.T8"+","+
                "EEG.FC6"+","+
                "EEG.F4"+","+
                "EEG.F8"+","+
                "EEG.AF4";

            sb.AppendLine(header);
            File.WriteAllText(@"C:\Users\omeri\Desktop\Road-Emergency-Response-System-BCI\Assets\_brain_visualizer\recording.csv",sb.ToString());
        }
        void Update() 
        {
            if (!this.isActive) {
                return;
            }

            _timerDataUpdate += Time.deltaTime;
            if (_timerDataUpdate < TIME_UPDATE_DATA) 
                return;

            _timerDataUpdate -= TIME_UPDATE_DATA;

            // update EEG data
            if (DataStreamManager.Instance.GetNumberEEGSamples() > 0) {
                string eegHeaderStr = "EEG Header: ";
                string eegDataStr   = "EEG Data: ";
                foreach (var ele in DataStreamManager.Instance.GetEEGChannels()) {
                    string chanStr  = ChannelStringList.ChannelToString(ele);
                    double[] data     = DataStreamManager.Instance.GetEEGData(ele);
                    eegHeaderStr    += chanStr + ", ";
                    if (data != null && data.Length > 0)
                        eegDataStr      +=  data[0].ToString() + ", ";
                    else
                        eegDataStr      +=  "null, "; // for null value
                }
                eegHeader.text  = eegHeaderStr;
                eegData.text    = eegDataStr;
                eegDataStr = eegDataStr.Remove(0,10);
                string[] result = eegDataStr.Split(',');
                string new_result = result[0]+","+result[3]+","+result[4]+","+result[5]+","+result[6]+","+result[7]+","+result[8]+","+result[9]+","+result[10]+","+result[11]+","+result[12]+","+result[13]+","+result[14]+","+result[15]+","+result[16];
                
                sb.AppendLine(new_result);
                File.WriteAllText(@"C:\Users\omeri\Desktop\Road-Emergency-Response-System-BCI\Assets\_brain_visualizer\recording.csv",sb.ToString());
            }

            // update motion data
            if (DataStreamManager.Instance.GetNumberMotionSamples() > 0) {
                string motHeaderStr = "Motion Header: ";
                string motDataStr   = "Motion Data: ";
                foreach (var ele in DataStreamManager.Instance.GetMotionChannels()) {
                    string chanStr  = ChannelStringList.ChannelToString(ele);
                    double[] data     = DataStreamManager.Instance.GetMotionData(ele);
                    motHeaderStr    += chanStr + ", ";
                    if (data != null && data.Length > 0)
                        motDataStr      +=  data[0].ToString() + ", ";
                    else
                        motDataStr      +=  "null, "; // for null value
                }
                motHeader.text  = motHeaderStr;
                motData.text    = motDataStr;
            }
            // update pm data
            if (DataStreamManager.Instance.GetNumberPMSamples() > 0) {
                string pmHeaderStr = "Performance metrics Header: ";
                string pmDataStr   = "Performance metrics Data: ";
                bool hasPMUpdate = true;
                foreach (var ele in DataStreamManager.Instance.GetPMLists()) {
                    string chanStr  = ele;
                    double data     = DataStreamManager.Instance.GetPMData(ele);
                    if (chanStr == "TIMESTAMP" && (data == -1))
                    {
                        // has no new update of performance metric data
                        hasPMUpdate = false;
                        break;
                    }
                    pmHeaderStr    += chanStr + ", ";
                    pmDataStr      +=  data.ToString() + ", ";
                }
                if (hasPMUpdate) {
                    pmHeader.text  = pmHeaderStr;
                    pmData.text    = pmDataStr;
                }
                
            }
        }

        public override void Activate()
        {
            Debug.Log("DataSubscriber: Activate");
            base.Activate ();
        }

        /// <summary>
        /// Subscribe EEG data
        /// </summary>
        public void onEEGSubBtnClick() {
            Debug.Log("onEEGSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.EEG};
            _dataStreamMgr.SubscribeMoreData(dataStreamList);
        }

        /// <summary>
        /// UnSubscribe EEG data
        /// </summary>
        public void onEEGUnSubBtnClick() {
            Debug.Log("onEEGUnSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.EEG};
            _dataStreamMgr.UnSubscribeData(dataStreamList);
            // clear text
            eegHeader.text  = "EEG Header: ";
            eegData.text    = "EEG Data: ";
        }

        /// <summary>
        /// Subscribe Motion data
        /// </summary>
        public void onMotionSubBtnClick() {
            Debug.Log("onMotionSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.Motion};
            _dataStreamMgr.SubscribeMoreData(dataStreamList);
        }

        /// <summary>
        /// UnSubscribe Motion data
        /// </summary>
        public void onMotionUnSubBtnClick() {
            Debug.Log("onMotionUnSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.Motion};
            _dataStreamMgr.UnSubscribeData(dataStreamList);
            // clear text
            motHeader.text  = "Motion Header: ";
            motData.text    = "Motion Data: ";
        }

        /// <summary>
        /// Subscribe Performance metrics data
        /// </summary>
        public void onPMSubBtnClick() {
            Debug.Log("onPMSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.PerformanceMetrics};
            _dataStreamMgr.SubscribeMoreData(dataStreamList);
        }

        /// <summary>
        /// UnSubscribe Performance metrics data
        /// </summary>
        public void onPMUnSubBtnClick() {
            Debug.Log("onPMUnSubBtnClick");
            List<string> dataStreamList = new List<string>(){DataStreamName.PerformanceMetrics};
            _dataStreamMgr.UnSubscribeData(dataStreamList);
            // clear text
            pmHeader.text  = "Performance metrics Header: ";
            pmData.text    = "Performance metrics Data: ";
        }
    }
}

