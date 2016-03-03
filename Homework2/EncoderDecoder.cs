using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2
{
    class EncoderDecoder
    {
     
    public string getencodedOrder(Order oo)
    {
     
        {
            String encodedString = String.Format("{0}##{1}##{2}##{3}##{4}##{5}", oo.getSenderid(),oo.getRecieverId(),oo.getCardNo(),oo.getOrderPrice(),oo.getTime(),oo.getAmount());
            return encodedString;
        }
    
    }

    public Order getDecodedOrder(String s)
    {
        
             Order decodedobj = new Order();
            string[] parts = s.Split(new string[] { "##" }, StringSplitOptions.None);
            decodedobj.setOrderPrice(Int32.Parse(parts[3]));
            decodedobj.setTime(Convert.ToDateTime(parts[4]));
            decodedobj.setDataMembers(parts[0], Int32.Parse(parts[2]), parts[1], Int32.Parse(parts[5]));
            return decodedobj;
     
    }
    }
}
