using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    public class Decrypt :RSA
    {
        public Decrypt()
        {

        }
        public Decrypt(int p, int q, int PublicKey, int Word)
            : base(p, q, PublicKey, Word)
        {

        }
        public override int RSAOutput()
        {
            return Respond(PrivateKey,p,q,Word);
        }
    }
}
