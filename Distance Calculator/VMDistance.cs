﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Distance_Calculator
{
    class VMDistance : INotifyPropertyChanged
    {
        private decimal carSpeed;
        private decimal nbrHours;
        private bool errSpeed, errNbrHours;
        private List<MDist> roadDist;
        private string FOLDER, FILE_NAME;
        private string msgInfo;

        //constructor
        public VMDistance()
        {
            FOLDER = "PROG8010";
            FILE_NAME = "as05-output.txt";
            errSpeed = true;
            errNbrHours = true;
        }

        #region public members
        //lblSpeed
        public string Speed
        {
            get
            {
                return carSpeed.ToString();
            }
            set
            {
                if (decimal.TryParse(value, out carSpeed))
                    errSpeed = false;   //false if no errors
                else
                    errSpeed = true;

                OnPropertyChanged();
            }
        }

        //lblTime
        public string Hours
        {
            get
            {
                return nbrHours.ToString();
            }
            set
            {
                if (decimal.TryParse(value, out nbrHours))
                    errNbrHours = false;    //false if no errors
                else
                    errNbrHours = true;

                OnPropertyChanged();
            }
        }

        //lbxDistance
        public List<MDist> ListDist
        {
            get
            {
                return roadDist;
            }
            set
            {
                roadDist = value;
                OnPropertyChanged();
            }
        }

        //lblMessage
        public string Message
        {
            get
            {
                return msgInfo;
            }

            set
            {
                msgInfo = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region CalculateDistance
        //Calculate the Distance
        public void CalculateDistance(ref string sysMsg)
        {
            MDist nDist;
            int nHours;
            decimal distance;

            distance = carSpeed * nbrHours;
            roadDist = new List<MDist>();

            if (!errSpeed && !errNbrHours)
            {
                if (distance != 0)
                {
                    nHours = (int)Math.Round(nbrHours);     //convert and round to int

                    //Create an instance of this object using parameters, Calculate, and Add the object to the list
                    for (int i = 1; i <= nHours; i++)
                    {
                        nDist = new MDist(string.Concat("After hour ", i.ToString()), carSpeed * i);
                        roadDist.Add(nDist);                //add an object MDist to the list
                        nDist = null;
                    }

                    ListDist = roadDist;
                    sysMsg = "";
                }
                else
                    sysMsg = "The distance is 0.";
            }
            else
            {
                sysMsg = "Please write valid number(s). Decimals are accepted.";
            }

            Message = sysMsg; //the label, to show the user a message
        }
        #endregion

        #region WriteFile
        //Write content
        public void WriteFile(string outputText)
        {
            //string outputText = "";
            string location = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fileLocation = Path.Combine(location, FOLDER);
            Directory.CreateDirectory(fileLocation);

            string fullName = Path.Combine(fileLocation, FILE_NAME);

            //If empty, not error: write the distance
            if (string.IsNullOrEmpty(outputText))
            {
                outputText = "\nSpeed\t Time and Distance\n" +
                             "======\t====================\n";
                for (int i = 0; i < roadDist.Count; i++)
                {
                    outputText += "\n" + carSpeed.ToString() + "\t\t" + roadDist[i];
                }
                outputText += "\n=================================";
            }
            else
                outputText = "*************************************************\n" +
                             outputText +
                             "\n*************************************************";    //If not empty, error: get the message to write in the file

            File.WriteAllText(fullName, outputText);    //create/write the file if already exists
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion
    }
}
