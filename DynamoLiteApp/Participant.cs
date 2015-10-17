using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoLiteApp
{
    public class Participant
    {
        public Participant()
        {
            _identifier = Helpers.s4();
        }

        private string _identifier;

        public void ReceiveMessage() { }

        public void RelayMessage() { }

    }
}
