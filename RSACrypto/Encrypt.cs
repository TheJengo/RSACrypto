using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACrypto
{
    public class Encrypt:RSA
    {
        public Encrypt()
        {

        }
        public Encrypt(int p, int q, int PublicKey, int Word) : base(p,q,PublicKey,Word)
        {

        }
        public override int RSAOutput()
        {
            return base.Respond(PublicKey, p, q, Word);
        }
    }
}
