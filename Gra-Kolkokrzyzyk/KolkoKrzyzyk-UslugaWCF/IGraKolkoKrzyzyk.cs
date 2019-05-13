using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KolkoKrzyzyk_UslugaWCF
{
[ServiceContract]
    public interface IGraKolkoKrzyzyk
    {
        [OperationContract]
        void Start();

        [OperationContract]
        bool MakeMove(int wiersz, int kolumna,
            out int wierszServer, out int kolumnaServer);

        [OperationContract] int CheckVictory(int wiersz, int kolumna);
    }

[DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
