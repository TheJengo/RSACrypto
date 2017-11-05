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
            int[] arr = base.ToBinary(PrivateKey);
            double x=1;
            double m = p * q;
            double temp = Word;
            double power = Math.Pow(temp,2) % m;
            if(arr[0] == 1)
            {
                power = temp % m;
            }
            foreach (int i in arr)
            {
                if(i == 1)
                {
                    x = (x * power) % m;
                    power = Math.Pow(temp, 2) % m;
                    temp = power;
                }
                else
                {
                    power = Math.Pow(temp, 2) % m;
                    temp = power;
                }
            }
            return Respond(PrivateKey,p,q,Word);
        }
    }
}
