using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IWriterMessageService : IGenericService<WriterMessage>
    {
        //buraya özel metodlar
        List<WriterMessage> GetListSendMessage(string send); //gönderdigimiz mesajlar listesi
        List<WriterMessage> GetListReceiverMessage(string receiver); //aldığımız mesajlar listesi
    }
}
