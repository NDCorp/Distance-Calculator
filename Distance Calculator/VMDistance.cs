using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Calculator
{
    class VMDistance : INotifyPropertyChanged
    {
        private decimal carSpeed, nbrHours;
        private List<MDist> roadDist;
        private string FOLDER, FILE_NAME;

        //constructor
        public VMDistance()
        {
            roadDist = new List<MDist>();
            FOLDER = "PROG8010";
            FILE_NAME = "as05-output.txt";
        }

        public decimal Speed
        {
            get { return carSpeed; }
            set
            {   //if (decimal.TryParse(value, out carSpeed))
                //        inputErr = false;
                //    else
                //        inputErr = true;
                carSpeed = value;
                OnPropertyChanged();
            }
        }

        public decimal Hours
        {
            get { return nbrHours; }
            set { nbrHours = value; OnPropertyChanged(); }
        }

        public List<MDist> ListDist
        {
            get { return roadDist; }
            set { roadDist = value; OnPropertyChanged(); }
        }

        public void CalculateDistance()
        {
            int nHours = (int)Math.Round(nbrHours);     //convert and round to int
            MDist nDist;

            roadDist.Clear();
            ListDist = new List<MDist>();

            //Create an instance of this object using parameters, Calculate, and Add the object to the list
            for (int i = 1; i <= nHours; i++)   //***** 2hours doesn't work
            {
                nDist = new MDist(string.Concat("After hour ", i.ToString()), carSpeed * i);
                roadDist.Add(nDist);    //add an object MDist to the list
            }
        }

        public void WriteFile()
        {
            string location = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fileLocation = Path.Combine(location, FOLDER);
            Directory.CreateDirectory(fileLocation);

            string fullName = Path.Combine(fileLocation, FILE_NAME);
            File.WriteAllText(fullName, "");    //create or clear the file if already exists
            StreamWriter strWrite = File.AppendText(fullName);

            strWrite.WriteLine("\nSpeed\t\t Time and Distance");
            strWrite.Write("======\t\t====================\n");
            for (int i = 0; i < roadDist.Count; i++)
            {
                strWrite.Write(carSpeed.ToString());
                strWrite.Write("\t\t");
                strWrite.WriteLine(roadDist[i]);
            }

            strWrite.Write("=================================");
            strWrite.Close();
        }
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
