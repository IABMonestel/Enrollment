using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Schedule
    {
        //Atributos
        private int id;
        private int openSubjectCode;
        private char dia;
        private string startTime;
        private string endTime;
        private bool exists;
        //Constructor
        public Schedule()
        {
            openSubjectCode = 0;
            dia = ' ';
            startTime = string.Empty;
            endTime = string.Empty;
            exists = false;
        }
        //Constructor
        public Schedule(int id, int openSubjectCode, char dia, string startTime, string endTime, bool exists)
        {
            this.id = id;
            this.openSubjectCode = openSubjectCode;
            this.dia = dia;
            this.startTime = startTime;
            this.endTime = endTime;
            this.exists = exists;
        }
        //Properties
        public int Id { get => id; set => id = value; }
        public int OpenSubjectCode { get => openSubjectCode; set => openSubjectCode = value; }
        public char Dia { get => dia; set => dia = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
        public bool Exists { get => exists; set => exists = value; }

        //toString()
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} ", openSubjectCode, dia, startTime, endTime);
        }
    }
}
